using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.vo;
using Xarial.XCad.SolidWorks;
using Svg;
using Svg.Pathing;
using netDxf;
using netDxf.Entities;
using wpfapp.bu.utils;

namespace wpfapp.bu
{
    /// <summary>
    /// SwBuAppService
    /// </summary>
    class SwBuAppService
    {
        #region Fields

        private static SwBuAppService _instance = new SwBuAppService();
        private ISwApplication _swApp = null;

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuAppService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuAppService getInstance()
        {
            return _instance;
        }

        #endregion

        #region 连接SolidWorks

        /// <summary>
        /// 连接Sw
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo connectSw()
        {
            var swProcess = Process.GetProcessesByName("SLDWORKS");
            if (!swProcess.Any())
            {
                // 没有打开SolidWorks
                return RespVo.genError("SolidWorks 没有打开，请打开SolidWorks后再试");
            }

            _swApp = SwApplicationFactory.FromProcess(swProcess.First());

            // 如果连接成功，则返回SolidWorks版本
            return RespVo.genOk(_swApp.Version.ToString());
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
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            var template = _swApp.Sw.GetUserPreferenceStringValue((int)docType);
            if (!File.Exists(template))
            {
                return RespVo.genError("未配置默认模板，无法新建文档");
            }

            var doc = _swApp.Sw.INewDocument2(template, 0, 300d, 300d);

            return RespVo.genOk();
        }

        /// <summary>
        /// 打开文档
        /// </summary>
        /// <param name="strDocFileName">文档名称</param>
        /// <param name="docType">文档类型</param>
        public RespVo openDoc(string strDocFileName, swDocumentTypes_e docType)
        {
            string strDocPath = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", strDocFileName);

            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            if (!File.Exists(strDocPath))
            {
                return RespVo.genError($"{strDocPath} 此文件不存在");
            }

            int errors = 0;
            int warnings = 0;

            var doc = _swApp.Sw.OpenDoc6(strDocPath, (int)docType, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            if (doc == null)
            {
                return RespVo.genError($"{strDocPath} 打开失败，错误代码： {errors}");
            }

            return RespVo.genOk();
        }


        /// <summary>
        /// 关闭文档
        /// </summary>
        /// <param name="strDocTitle">文档标题</param>
        /// <returns>RespVo</returns>
        public RespVo closeDoc(string strDocTitle)
        {
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            if(string.IsNullOrEmpty(strDocTitle))
            {
                // 关闭当前文档
                //获取当前打开的文档
                var doc = _swApp.Sw.IActiveDoc2;
                if (doc == null)
                {
                    return RespVo.genError("没有打开的文档"); ;
                }

                //获取当前打开文档标题
                strDocTitle = doc.GetTitle();
            }

            //关闭文档
            _swApp.Sw.CloseDoc(strDocTitle);

            return RespVo.genOk();
        }

        /// <summary>
        /// 关闭当前文档
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo closeCurDoc()
        {
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = _swApp.Sw.IActiveDoc2;
            if (doc == null)
            {
                return RespVo.genError("没有打开的文档"); ;
            }

            //获取当前打开文档标题
            string strDocFileName = doc.GetTitle();

            //关闭文档
            _swApp.Sw.CloseDoc(strDocFileName);

            return RespVo.genOk();
        }

        public string getCurDocPath()
        {
            if (_swApp == null)
            {
                return "";
            }

            //获取当前打开的文档
            var doc = _swApp.Sw.IActiveDoc2;
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
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = _swApp.Sw.IActiveDoc2 as ModelDoc2;
            if (doc == null)
            {
                return RespVo.genError("没有打开的文档"); ;
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
                strDocPath = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", strDocFileName + strDocFileType);
                int errors = 0;
                int warnings = 0;
                bool oOk = doc.Extension.SaveAs3(strDocPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, null, ref errors, ref warnings);
                if (!oOk)
                {
                    return RespVo.genError($"当前文档保存失败，错误代码： {errors}");
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
                    return RespVo.genError($"当前文档保存失败，错误代码： {errors}");
                }
            }

            return RespVo.genOk($"当前文档保存成功： {strDocPath}");
        }

        /// <summary>
        /// 另存当前文档
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo saveAsCurDoc(string strDocFilePath)
        {
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = _swApp.Sw.IActiveDoc2;
            if (doc == null)
            {
                return RespVo.genError("没有打开的文档"); ;
            }

            //如果是已打开的文档
            int errors = 0;
            int warnings = 0;
            bool oOk = doc.Extension.SaveAs3(strDocFilePath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, null, ref errors, ref warnings);
            if (!oOk)
            {
                return RespVo.genError($"当前文档保存失败，错误代码： {errors}");
            }

            return RespVo.genOk($"文档保存成功： {strDocFilePath}");
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo saveDoc(SaveDocInVo oSaveDocInVo)
        {
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            ModelDoc2 doc = null;
            if(string.IsNullOrEmpty(oSaveDocInVo.DocTitle))
            {
                //获取当前打开的文档
                doc = _swApp.Sw.IActiveDoc2;
                
            }
            else
            {
                doc = _swApp.Sw.GetOpenDocument(oSaveDocInVo.DocTitle);
            }

            if (doc == null)
            {
                return RespVo.genError("文档没有打开"); ;
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
                strDocPath = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", strDocFileName + strDocFileType);
                int errors = 0;
                int warnings = 0;
                bool oOk = doc.Extension.SaveAs3(strDocPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, null, ref errors, ref warnings);
                if (!oOk)
                {
                    return RespVo.genError($"文档保存失败，错误代码： {errors}");
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
                    return RespVo.genError($"文档保存失败，错误代码： {errors}");
                }
            }

            return RespVo.genOk($"文档保存成功： {strDocPath}");
        }

        #endregion

        #region 零件-圆管

        /// <summary>
        /// 在当前打开的零件文档中创建草图并绘制一个圆管
        /// </summary>
        /// <param name="oCreateCirclePipeInVo"></param>
        /// <returns>RespVo</returns>
        public RespVo createCirclePipe(NewCirclePipeInVo oCreateCirclePipeInVo)
        {
            //新建一个草图并且绘制一个圆管

            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = _swApp.Sw.IActiveDoc2;
            if (doc == null)
            {
                return RespVo.genError("没有打开的文档"); ;
            }

            //防御文档不是零件
            if (doc.GetType() != (int)swDocumentTypes_e.swDocPART)
            {
                return RespVo.genError("当前打开的不是零件");
            }

            //创建草图，需要先找到一个基准面
            var feat = doc.FirstFeature() as IFeature;
            IFeature refFeat = default;
            while (feat != null)
            {
                var name = feat.GetTypeName2();
                if (name == "RefPlane")
                {
                    refFeat = feat;
                    break;
                }
                feat = feat.GetNextFeature() as IFeature;
            }

            //选中这个基准面
            refFeat.Select2(false, 0);

            //在这个基准面上插入一个草图
            var skeMgr = doc.SketchManager;
            skeMgr.InsertSketch(true);

            //先获取用户草屋激活捕捉设置是否打开
            var hasInference = _swApp.Sw.GetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference);
            if (hasInference)
            {
                //用户已经打开了激活捕捉功能，则先关闭激活捕获
                _swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
            }

            //绘制一个圆
            skeMgr.CreateCircleByRadius(0, 0, 0, oCreateCirclePipeInVo.CircleRadius / 1000);

            //还原用户设置
            _swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, hasInference);

            var featMgr = doc.FeatureManager;
            //featMgr.FeatureExtrusion3(
            //    Sd: true, //单向拉伸
            //    Flip: false,
            //    Dir: false,
            //    T1: (int)swEndConditions_e.swEndCondBlind,
            //    T2: (int)swEndConditions_e.swEndCondBlind,
            //    D1: Double.Parse(txtBoxLength.Text) / 1000, //拉伸深度
            //    D2: 0,
            //    //拔模参数
            //    Dchk1: false,
            //    Dchk2: false,
            //    Ddir1: false,
            //    Ddir2: false,
            //    Dang1: 0,
            //    Dang2: 0,
            //    //
            //    OffsetReverse1: false,
            //    OffsetReverse2: false,
            //    TranslateSurface1: false,
            //    TranslateSurface2: false,
            //    //实体和选择
            //    Merge: true,
            //    UseFeatScope: true,
            //    UseAutoSelect: true,
            //    //起始条件
            //    T0: (int)swStartConditions_e.swStartSketchPlane,
            //    StartOffset: 0,
            //    FlipStartOffset: false
            //    );

            featMgr.FeatureExtrusionThin2(
                Sd: true, //单向拉伸
                Flip: false,
                Dir: false,
                T1: (int)swEndConditions_e.swEndCondBlind,
                T2: (int)swEndConditions_e.swEndCondBlind,
                D1: oCreateCirclePipeInVo.Length / 1000, //拉伸深度
                D2: 0,
                //拔模参数
                Dchk1: false,
                Dchk2: false,
                Ddir1: false,
                Ddir2: false,
                Dang1: 0,
                Dang2: 0,
                //
                OffsetReverse1: false,
                OffsetReverse2: false,
                TranslateSurface1: false,
                TranslateSurface2: false,
                //实体和选择
                Merge: true,
                Thk1: oCreateCirclePipeInVo.Thickness / 1000, //壁厚
                Thk2: 0,
                EndThk: 0,
                RevThinDir: 0,
                CapEnds: 0,
                AddBends: false,
                BendRad: 0,
                UseFeatScope: true,
                UseAutoSelect: true,
                //起始条件
                T0: (int)swStartConditions_e.swStartSketchPlane,
                StartOffset: 0,
                FlipStartOffset: false
                );

            return RespVo.genOk();
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
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            ModelDoc2 doc = null;
            if (string.IsNullOrEmpty(oInVo.DocTitle))
            {
                //获取当前打开的文档
                doc = _swApp.Sw.IActiveDoc2;

            }
            else
            {
                doc = _swApp.Sw.GetOpenDocument(oInVo.DocTitle);
            }

            if(oInVo.ExportFileType == 1)
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
                return RespVo.genError("不支持导出该文件类型");
            }
        }

        /// <summary>
        /// 将当前模型视图导出为二维的dxf文件
        /// </summary>
        /// <returns></returns>
        public RespVo exportDxf()
        {
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = _swApp.Sw.IActiveDoc2;
            return priExportDxf(doc);
        }

        private RespVo priExportDxf(ModelDoc2 doc)
        {
            if (doc == null)
            {
                return RespVo.genError("文档未打开"); ;
            }

            RespVo oRespVo = RespVo.genOk();
            string strDocFilePath = doc.GetPathName();
            string strDocFileName = doc.GetTitle().Split(".".ToCharArray())[0];
            swDocumentTypes_e docType = (swDocumentTypes_e)doc.GetType();

            if (docType == swDocumentTypes_e.swDocPART ||
                docType == swDocumentTypes_e.swDocASSEMBLY)
            {
                // 如果文档类型是零件或装配体，则创建临时工程视图
                // 视图名称，"*当前"、"*上视"、"*正视于"、"*右视"、"*正视于"、"*后视"、"*左视"、"*下视"、"*等轴测"、"*上下二等角轴测"、"*左右二等角轴测"</param>
                IDrawingDoc drawingDoc = null;
                oRespVo = priCreateTempDrawingDoc(_swApp.Sw, doc, ref drawingDoc);
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

                    string strDocPath = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", strDocFileName + "_" + strViewName + ".dxf");

                    // 将工程图视图导出为Dxf
                    oRespVo = priExportToDxf(drawingDoc as ModelDoc2, strDocPath);

                    strDocPathOk = strDocPath;

                    //doc.DeleteSelection
                }

                // 关闭临时工程图
                _swApp.Sw.CloseDoc(((ModelDoc2)drawingDoc).GetTitle());

                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                return RespVo.genOk($"导出成功，{strDocPathOk}");
            }
            else if (doc.GetType() == (int)swDocumentTypes_e.swDocDRAWING)
            {
                // 将工程图视图导出为Dxf
                string strDocPath = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", strDocFileName + ".dxf");
                oRespVo = priExportToDxf(doc as ModelDoc2, strDocPath);

                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                return RespVo.genOk($"导出成功，{strDocPath}");
            }
            else
            {
                return RespVo.genError("不支持的文档类型");
            }
        }

        /// <summary>
        /// 将当前模型视图导出为二维的svg文件
        /// </summary>
        /// <returns></returns>
        public RespVo exportSvg()
        {
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = _swApp.Sw.IActiveDoc2;
            return priExportSvg(doc);
        }

        private RespVo priExportSvg(ModelDoc2 doc)
        {
            if (doc == null)
            {
                return RespVo.genError("文档未打开"); ;
            }

            RespVo oRespVo = RespVo.genOk();
            string strDocFilePath = doc.GetPathName();
            string strDocFileName = doc.GetTitle().Split(".".ToCharArray())[0];
            string strDocPathDxf = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", strDocFileName + ".dxf");
            string strDocPathSvg = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", strDocFileName + ".svg");
            swDocumentTypes_e docType = (swDocumentTypes_e)doc.GetType();

            if (docType == swDocumentTypes_e.swDocPART ||
                docType == swDocumentTypes_e.swDocASSEMBLY)
            {
                // 如果文档类型是零件或装配体，则创建临时工程视图
                IDrawingDoc drawingDoc = null;
                oRespVo = priCreateTempDrawingDoc(_swApp.Sw, doc, ref drawingDoc);
                if (!oRespVo.ok)
                    return oRespVo;

                string strViewName = "正视于";
                IView view = null;
                oRespVo = priCreateTempDrawingViewFromModel(drawingDoc, strDocFilePath, "*" + strViewName, ref view);
                if (!oRespVo.ok)
                {
                    return oRespVo;
                }

                string strDocPath = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", strDocFileName + "_" + strViewName + ".dxf");

                // 将工程图视图导出为Dxf
                oRespVo = priExportToDxf(drawingDoc as ModelDoc2, strDocPathDxf);

                // 关闭临时工程图
                _swApp.Sw.CloseDoc(((ModelDoc2)drawingDoc).GetTitle());

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

                return RespVo.genOk($"导出成功，{strDocPathSvg}");
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

                return RespVo.genOk($"导出成功，{strDocPathSvg}");
            }
            else
            {
                return RespVo.genError("不支持的文档类型");
            }
        }

        /// <summary>
        /// 将当前模型视图导出为二维的svg文件
        /// </summary>
        /// <returns></returns>
        public RespVo exportIges()
        {
            if (_swApp == null)
            {
                return RespVo.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            var doc = _swApp.Sw.IActiveDoc2;
            return priExportIges(doc);
        }

        private RespVo priExportIges(ModelDoc2 doc)
        {
            if (doc == null)
            {
                return RespVo.genError("文档未打开");
            }

            RespVo oRespVo = RespVo.genOk();
            string strDocFileName = doc.GetTitle().Split(".".ToCharArray())[0];
            string strDocPath = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", strDocFileName + ".igs");
            swDocumentTypes_e docType = (swDocumentTypes_e)doc.GetType();

            if (docType == swDocumentTypes_e.swDocPART ||
                docType == swDocumentTypes_e.swDocASSEMBLY)
            {
                // 将文档导出为Dxf
                oRespVo = priExportToIges(doc as ModelDoc2, strDocPath);

                if (!oRespVo.ok)
                    return oRespVo;

                return RespVo.genOk($"导出成功，{strDocPath}");
            }
            else
            {
                return RespVo.genError("不支持的文档类型");
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
            var template = Path.Combine(Path.GetDirectoryName(typeof(MainWindow).Assembly.Location), "Model", "blank_a0.DRWDOT");
            if (!File.Exists(template))
            {
                return RespVo.genError("默认工程模板不存在");
            }

            // 创建临时工程图
            drawingDoc = swApp.NewDocument(template,
                0, 0, 0) as IDrawingDoc;
            if (drawingDoc == null)
            {
                return RespVo.genError("创建临时工程图失败");
            }

            return RespVo.genOk();
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
                return RespVo.genError("添加工程图模型视图失败");
            }

            //设置视图比例和显示模式（可选）
            view.ScaleDecimal = 1.0; // 比例 1:1
            //view.DisplayMode = (int)swViewDisplayMode_e.swViewDisplayMode_HiddenLinesRemoved; // 隐藏线移除

            return RespVo.genOk();
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

            if(bOk)
            {
                return RespVo.genOk();
            }
            else 
            {
                return RespVo.genError($"导出失败，错误代码： {errors}");
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
                return RespVo.genOk();
            }
            else
            {
                return RespVo.genError($"导出失败，错误代码： {errors}");
            }

        }

        #endregion
    }
}
