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
using wpfapp.basic.io;

namespace wpfapp.bu.file.export
{
    class SwDocExportUtils
    {

        #region dxf

        public static RespVo exportDxf(ISldWorks swApp, ModelDoc2 doc)
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
                oRespVo = priCreateTempDrawingDoc(swApp, doc, ref drawingDoc);
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
                swApp.CloseDoc(((ModelDoc2)drawingDoc).GetTitle());

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

        #endregion

        #region

        public static RespVo exportSvg(ISldWorks swApp, ModelDoc2 doc)
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
                oRespVo = priCreateTempDrawingDoc(swApp, doc, ref drawingDoc);
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
                swApp.CloseDoc(((ModelDoc2)drawingDoc).GetTitle());

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

        #endregion

        #region iges

        public static RespVo exportIges(ISldWorks swApp, ModelDoc2 doc)
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


        #endregion


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

    }
}
