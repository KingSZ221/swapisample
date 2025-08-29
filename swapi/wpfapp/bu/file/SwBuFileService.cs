using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.app;
using wpfapp.bu.log;
using wpfapp.bu.utils;
using wpfapp.bu.vo;
using Xarial.XCad.SolidWorks;

namespace wpfapp.bu.file
{
    /// <summary>
    /// 文档服务
    /// </summary>
    public class SwBuFileService
    {
        #region Fields

        private static SwBuFileService _instance = new SwBuFileService();

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuFileService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuFileService getInstance()
        {
            return _instance;
        }

        #endregion

        #region app

        private ISwApplication swApp
        {
            get { return SwBuAppService.getInstance().getSwApp(); }
        }

        #endregion

        #region 文档

        /// <summary>
        /// 新建文档
        /// </summary>
        /// <param name="docType">文档类型</param>
        /// <returns></returns>
        public RespVo newDoc(swUserPreferenceStringValue_e docType)
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            var template = swApp.Sw.GetUserPreferenceStringValue((int)docType);
            if (!File.Exists(template))
            {
                return RespVoLogExt.genError("未配置默认模板，无法新建文档");
            }

            var doc = swApp.Sw.INewDocument2(template, 0, 300d, 300d);

            return RespVoLogExt.genOk($"新建文档成功，标题: {doc.GetTitle()}");
        }

        /// <summary>
        /// 打开文档
        /// </summary>
        /// <param name="strDocFileName">文档名称</param>
        /// <param name="docType">文档类型</param>
        public RespVo openDoc(string strDocFileName, swDocumentTypes_e docType)
        {
            string strDocPath = SwBuAppService.getAppResFilePath(strDocFileName);

            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            if (!File.Exists(strDocPath))
            {
                return RespVoLogExt.genError($"此文件不存在 {strDocPath}");
            }

            int errors = 0;
            int warnings = 0;

            var doc = swApp.Sw.OpenDoc6(strDocPath, (int)docType, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            if (doc == null)
            {
                return RespVoLogExt.genError($"打开文档失败, {strDocPath} ，错误代码： {errors}");
            }
            return RespVoLogExt.genOk($"打开文档成功, {strDocPath}");
        }


        /// <summary>
        /// 关闭文档
        /// </summary>
        /// <param name="strDocTitle">文档标题</param>
        /// <returns>RespVo</returns>
        public RespVo closeDoc(string strDocTitle)
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            if (string.IsNullOrEmpty(strDocTitle))
            {
                // 关闭当前文档
                //获取当前打开的文档
                var doc = swApp.Sw.IActiveDoc2;
                if (doc == null)
                {
                    return RespVoLogExt.genError("没有打开的文档"); ;
                }

                //获取当前打开文档标题
                strDocTitle = doc.GetTitle();
            }

            //关闭文档
            swApp.Sw.CloseDoc(strDocTitle);

            return RespVoLogExt.genOk($"关闭文档成功, {strDocTitle}");
        }

        /// <summary>
        /// 关闭当前文档
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo closeCurDoc()
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = swApp.Sw.IActiveDoc2;
            if (doc == null)
            {
                return RespVoLogExt.genError("没有打开的文档"); ;
            }

            //获取当前打开文档标题
            string strDocFileName = doc.GetTitle();

            //关闭文档
            swApp.Sw.CloseDoc(strDocFileName);

            return RespVoLogExt.genOk($"关闭文档成功, {strDocFileName}");
        }

        public string getCurDocPath()
        {
            if (swApp == null)
            {
                return "";
            }

            //获取当前打开的文档
            var doc = swApp.Sw.IActiveDoc2;
            if (doc == null)
            {
                return "";
            }

            return doc.GetPathName();
        }

        /// <summary>
        /// 保存当前文档
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo saveCurDoc()
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = swApp.Sw.IActiveDoc2 as ModelDoc2;
            if (doc == null)
            {
                return RespVoLogExt.genError("没有打开的文档"); ;
            }

            string strDocPath = doc.GetPathName();
            if (string.IsNullOrEmpty(strDocPath))
            {
                //如果是新建的文档,则调用Save3保存当前文档
                string strDocFileName = doc.GetTitle();
                string strDocFileType = ".sldprt";
                switch ((swDocumentTypes_e)doc.GetType())
                {
                    case swDocumentTypes_e.swDocPART:
                        strDocFileType = ".sldprt";
                        break;
                    case swDocumentTypes_e.swDocASSEMBLY:
                        strDocFileType = ".sldasm";
                        break;
                    case swDocumentTypes_e.swDocDRAWING:
                        strDocFileType = ".slddrw";
                        break;
                    default:
                        strDocFileType = ".sldprt";
                        break;
                }
                strDocPath = SwBuAppService.getAppResFilePath(strDocFileName + strDocFileType);
                int errors = 0;
                int warnings = 0;
                bool oOk = doc.Extension.SaveAs3(strDocPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, null, ref errors, ref warnings);
                if (!oOk)
                {
                    return RespVoLogExt.genError($"文档保存失败，错误代码： {errors}");
                }
            }
            else
            {
                //如果是已打开的文档
                int errors = 0;
                int warnings = 0;
                bool oOk = doc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_Silent, ref errors, ref warnings);
                if (!oOk)
                {
                    return RespVoLogExt.genError($"保存文档失败，错误代码： {errors}");
                }
            }

            return RespVoLogExt.genOk($"保存文档成功, {strDocPath}");
        }

        /// <summary>
        /// 另存当前文档
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo saveAsCurDoc(string strDocFilePath)
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = swApp.Sw.IActiveDoc2;
            if (doc == null)
            {
                return RespVoLogExt.genError("没有打开的文档"); ;
            }

            //如果是已打开的文档
            int errors = 0;
            int warnings = 0;
            bool oOk = doc.Extension.SaveAs3(strDocFilePath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, null, ref errors, ref warnings);
            if (!oOk)
            {
                return RespVoLogExt.genError($"保存文档失败，错误代码： {errors}");
            }

            return RespVoLogExt.genOk($"保存文档成功, {strDocFilePath}");
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo saveDoc(SaveDocInVo oSaveDocInVo)
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            ModelDoc2 doc = null;
            if (string.IsNullOrEmpty(oSaveDocInVo.DocTitle))
            {
                //获取当前打开的文档
                doc = swApp.Sw.IActiveDoc2;

            }
            else
            {
                doc = swApp.Sw.GetOpenDocument(oSaveDocInVo.DocTitle);
            }

            if (doc == null)
            {
                return RespVoLogExt.genError("文档没有打开"); ;
            }

            // 获取文档文件路径
            string strDocPath = doc.GetPathName();
            if (string.IsNullOrEmpty(strDocPath))
            {
                //如果是新建的文档,则调用Save3保存当前文档
                string strDocFileName = doc.GetTitle();
                string strDocFileType = ".sldprt";
                switch ((swDocumentTypes_e)doc.GetType())
                {
                    case swDocumentTypes_e.swDocPART:
                        strDocFileType = ".sldprt";
                        break;
                    case swDocumentTypes_e.swDocASSEMBLY:
                        strDocFileType = ".sldasm";
                        break;
                    case swDocumentTypes_e.swDocDRAWING:
                        strDocFileType = ".slddrw";
                        break;
                    default:
                        strDocFileType = ".sldprt";
                        break;
                }
                strDocPath = SwBuAppService.getAppResFilePath(strDocFileName + strDocFileType);
                int errors = 0;
                int warnings = 0;
                bool oOk = doc.Extension.SaveAs3(strDocPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, null, ref errors, ref warnings);
                if (!oOk)
                {
                    return RespVoLogExt.genError($"保存文档失败，错误代码： {errors}");
                }
            }
            else
            {
                //如果是已打开的文档
                int errors = 0;
                int warnings = 0;
                bool oOk = doc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_Silent, ref errors, ref warnings);
                if (!oOk)
                {
                    return RespVoLogExt.genError($"保存文档失败，错误代码： {errors}");
                }
            }

            return RespVoLogExt.genOk($"保存文档成功, {strDocPath}");
        }

        #endregion

        #region 导出

        /// <summary>
        /// 导出文档
        /// </summary>
        /// <param name="oInVo">导出文档参数</param>
        /// <returns></returns>
        public RespVo exportDoc(ExportDocInVo oInVo)
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            ModelDoc2 doc = null;
            if (string.IsNullOrEmpty(oInVo.DocTitle))
            {
                //获取当前打开的文档
                doc = swApp.Sw.IActiveDoc2;

            }
            else
            {
                doc = swApp.Sw.GetOpenDocument(oInVo.DocTitle);
            }

            if (oInVo.ExportFileType == 1)
            {
                // 导出dxf
                return priExportDxf(doc);
            }
            else if (oInVo.ExportFileType == 2)
            {
                // 导出svg
                return priExportSvg(doc);
            }
            else if (oInVo.ExportFileType == 3)
            {
                // 导出Iges
                return priExportIges(doc);
            }
            else
            {
                return RespVoLogExt.genError("不支持导出该文件类型");
            }
        }

        /// <summary>
        /// 将当前模型视图导出为二维的dxf文件
        /// </summary>
        /// <returns></returns>
        public RespVo exportDxf()
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = swApp.Sw.IActiveDoc2;
            return priExportDxf(doc);
        }

        private RespVo priExportDxf(ModelDoc2 doc)
        {
            if (doc == null)
            {
                return RespVoLogExt.genError("没有打开的文档"); ;
            }

            RespVo oRespVo = new RespVo();
            string strDocFilePath = doc.GetPathName();
            string strDocFileName = doc.GetTitle().Split(".".ToCharArray())[0];
            swDocumentTypes_e docType = (swDocumentTypes_e)doc.GetType();

            if (docType == swDocumentTypes_e.swDocPART ||
                docType == swDocumentTypes_e.swDocASSEMBLY)
            {
                // 如果文档类型是零件或装配体，则创建临时工程视图
                // 视图名称，"*当前"、"*上视"、"*正视于"、"*右视"、"*正视于"、"*后视"、"*左视"、"*下视"、"*等轴测"、"*上下二等角轴测"、"*左右二等角轴测"</param>
                IDrawingDoc drawingDoc = null;
                oRespVo = priCreateTempDrawingDoc(swApp.Sw, doc, ref drawingDoc);
                if (!oRespVo.ok)
                    return oRespVo;

                string strDocPathOk = "";
                //string[] strViewNames = { "当前", "上视", "右视", "正视于", "后视", "左视", "下视", "等轴测", "上下二等角轴测", "左右二等角轴测" };
                string[] strViewNames = { "正视于" };
                for (int i = 0; i < strViewNames.Length; i++)
                {
                    string strViewName = strViewNames[i];
                    IView view = null;
                    oRespVo = priCreateTempDrawingViewFromModel(drawingDoc, strDocFilePath, "*" + strViewName, ref view);
                    if (!oRespVo.ok)
                    {
                        continue;
                    }

                    string strDocPath = SwBuAppService.getAppResFilePath(strDocFileName + "_" + strViewName + ".dxf");

                    // 将工程图视图导出为Dxf
                    oRespVo = priExportToDxf(drawingDoc as ModelDoc2, strDocPath);

                    strDocPathOk = strDocPath;

                    //doc.DeleteSelection
                }

                // 关闭临时工程图
                swApp.Sw.CloseDoc(((ModelDoc2)drawingDoc).GetTitle());

                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                return RespVoLogExt.genOk($"导出文档成功，{strDocPathOk}");
            }
            else if (doc.GetType() == (int)swDocumentTypes_e.swDocDRAWING)
            {
                // 将工程图视图导出为Dxf
                string strDocPath = SwBuAppService.getAppResFilePath(strDocFileName + ".dxf");
                oRespVo = priExportToDxf(doc as ModelDoc2, strDocPath);

                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                return RespVoLogExt.genOk($"导出文档成功，{strDocPath}");
            }
            else
            {
                return RespVoLogExt.genError("不支持的文档类型");
            }
        }

        /// <summary>
        /// 将当前模型视图导出为二维的svg文件
        /// </summary>
        /// <returns></returns>
        public RespVo exportSvg()
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = swApp.Sw.IActiveDoc2;
            return priExportSvg(doc);
        }

        private RespVo priExportSvg(ModelDoc2 doc)
        {
            if (doc == null)
            {
                return RespVoLogExt.genError("没有打开的文档");
            }

            RespVo oRespVo = new RespVo();
            string strDocFilePath = doc.GetPathName();
            string strDocFileName = doc.GetTitle().Split(".".ToCharArray())[0];
            string strDocPathDxf = SwBuAppService.getAppResFilePath(strDocFileName + ".dxf");
            string strDocPathSvg = SwBuAppService.getAppResFilePath(strDocFileName + ".svg");
            swDocumentTypes_e docType = (swDocumentTypes_e)doc.GetType();

            if (docType == swDocumentTypes_e.swDocPART ||
                docType == swDocumentTypes_e.swDocASSEMBLY)
            {
                // 如果文档类型是零件或装配体，则创建临时工程视图
                IDrawingDoc drawingDoc = null;
                oRespVo = priCreateTempDrawingDoc(swApp.Sw, doc, ref drawingDoc);
                if (!oRespVo.ok)
                    return oRespVo;

                string strViewName = "正视于";
                IView view = null;
                oRespVo = priCreateTempDrawingViewFromModel(drawingDoc, strDocFilePath, "*" + strViewName, ref view);
                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                string strDocPath = SwBuAppService.getAppResFilePath(strDocFileName + "_" + strViewName + ".dxf");

                // 将工程图视图导出为Dxf
                oRespVo = priExportToDxf(drawingDoc as ModelDoc2, strDocPathDxf);

                // 关闭临时工程图
                swApp.Sw.CloseDoc(((ModelDoc2)drawingDoc).GetTitle());

                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                // 将Dxf文件转换成Svg文件
                oRespVo = DxfToSvgConverter.Convert(strDocPathDxf, strDocPathSvg);
                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                return RespVoLogExt.genOk($"导出文档成功，{strDocPathSvg}");
            }
            else if (doc.GetType() == (int)swDocumentTypes_e.swDocDRAWING)
            {
                // 将工程图视图导出为Dxf
                oRespVo = priExportToDxf(doc as ModelDoc2, strDocPathDxf);
                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                // 将Dxf文件转换成Svg文件
                oRespVo = DxfToSvgConverter.Convert(strDocPathDxf, strDocPathSvg);
                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                return RespVoLogExt.genOk($"导出文档成功，{strDocPathSvg}");
            }
            else
            {
                return RespVoLogExt.genError("不支持的文档类型");
            }
        }

        /// <summary>
        /// 将当前模型视图导出为二维的svg文件
        /// </summary>
        /// <returns></returns>
        public RespVo exportIges()
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = swApp.Sw.IActiveDoc2;
            return priExportIges(doc);
        }

        private RespVo priExportIges(ModelDoc2 doc)
        {
            if (doc == null)
            {
                return RespVoLogExt.genError("没有打开的文档");
            }

            RespVo oRespVo = new RespVo();
            string strDocFileName = doc.GetTitle().Split(".".ToCharArray())[0];
            string strDocPath = SwBuAppService.getAppResFilePath(strDocFileName + ".igs");
            swDocumentTypes_e docType = (swDocumentTypes_e)doc.GetType();

            if (docType == swDocumentTypes_e.swDocPART ||
                docType == swDocumentTypes_e.swDocASSEMBLY)
            {
                // 将文档导出为Dxf
                oRespVo = priExportToIges(doc as ModelDoc2, strDocPath);

                if (!oRespVo.ok)
                    return oRespVo;

                return RespVoLogExt.genOk($"导出文档成功，{strDocPath}");
            }
            else
            {
                return RespVoLogExt.genError("不支持的文档类型");
            }
        }

        /// <summary>
        /// 从模型创建临时工程图
        /// </summary>
        /// <param name="swApp">ISldWorks</param>
        /// <param name="modelDoc">零件或装配体</param>
        /// <param name="viewName">视图名称，"*当前"、"*上视"、"*正视于"、"*右视"、"*正视于"、"*后视"、"*左视"、"*下视"、"*等轴测"、"*上下二等角轴测"、"*左右二等角轴测"</param>
        /// <returns>是否成功</returns>
        private static RespVo priCreateTempDrawingDoc(ISldWorks swApp, ModelDoc2 modelDoc, ref IDrawingDoc drawingDoc)
        {
            // 获取空白工程图模板路径
            var template = SwBuAppService.getAppResFilePath("blank_a0.DRWDOT");
            if (!File.Exists(template))
            {
                return RespVoLogExt.genError("默认工程模板不存在");
            }

            // 创建临时工程图
            drawingDoc = swApp.NewDocument(template,
                0, 0, 0) as IDrawingDoc;
            if (drawingDoc == null)
            {
                return RespVoLogExt.genError("创建临时工程图失败");
            }

            return RespVoLogExt.genOk("创建临时工程图成功");
        }


        private static RespVo priCreateTempDrawingViewFromModel(IDrawingDoc drawingDoc, string strModelName, string strViewName, ref IView view)
        {
            // 添加模型视图
            view = drawingDoc.CreateDrawViewFromModelView3(
                    strModelName, // 模型路径
                    strViewName,  // 视图名称（*当前表示当前视图方向）"*当前"、"*上视"、"*正视于"、"*右视"、"*正视于"、"*后视"、"*左视"、"*下视"、"*等轴测"、"*上下二等角轴测"、"*左右二等角轴测"
                    0, 0, 0);     // 插入坐标 (0,0)
            if (view == null)
            {
                return RespVoLogExt.genError("添加工程图模型视图失败");
            }

            //设置视图比例和显示模式（可选）
            view.ScaleDecimal = 1.0; // 比例 1:1
            //view.DisplayMode = (int)swViewDisplayMode_e.swViewDisplayMode_HiddenLinesRemoved; // 隐藏线移除

            return RespVoLogExt.genOk("添加工程图模型视图成功");
        }

        /// <summary>
        /// 将工程图导出为Dxf
        /// </summary>
        /// <param name="drawingDoc">工程图</param>
        /// <param name="strFilePathDxf">Dxf文件路径</param>
        /// <returns></returns>
        private static RespVo priExportToDxf(IModelDoc2 drawingDoc, string strFilePathDxf)
        {
            int errors = 0;
            int warnings = 0;

            IModelDocExtension docExt = drawingDoc.Extension;
            bool bOk = docExt.SaveAs(
                strFilePathDxf,
                (int)swSaveAsVersion_e.swSaveAsCurrentVersion,
                (int)swSaveAsOptions_e.swSaveAsOptions_Silent,
                null, ref errors, ref warnings);

            if (bOk)
            {
                return RespVoLogExt.genOk($"导出文档成功，{strFilePathDxf}");
            }
            else
            {
                return RespVoLogExt.genError($"导出文档失败，错误代码： {errors}");
            }

        }

        /// <summary>
        /// 将工程图导出为Dxf
        /// </summary>
        /// <param name="oDoc">零件或装配图</param>
        /// <param name="strFilePathIges">文件保存路径</param>
        /// <returns></returns>
        private static RespVo priExportToIges(IModelDoc2 oDoc, string strFilePath)
        {
            int errors = 0;
            int warnings = 0;

            IModelDocExtension docExt = oDoc.Extension;
            bool bOk = oDoc.Extension.SaveAs3(strFilePath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, null, ref errors, ref warnings);
            if (bOk)
            {
                return RespVoLogExt.genOk($"导出文档成功，{strFilePath}");
            }
            else
            {
                return RespVoLogExt.genError($"导出文档失败，错误代码： {errors}");
            }

        }

        #endregion
    }
}

