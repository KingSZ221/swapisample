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

            _swApp.Sw.CloseDoc("");

            return RespVo.genOk();
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
            var doc = _swApp.Sw.IActiveDoc2;
            if (doc == null)
            {
                return RespVo.genError("没有打开的文档"); ;
            }

            //保存当前文档
            int errors = 0;
            int warnings = 0;
            bool oOk = doc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_Silent, ref errors, ref warnings);
            if (!oOk)
            {
                return RespVo.genError($"当前文档保存失败，错误代码： {errors}");
            }

            return RespVo.genOk();
        }

        /// <summary>
        /// 另存当前文档
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo saveAsCurDoc()
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

            //保存当前文档
            int errors = 0;
            int warnings = 0;
            bool oOk = doc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_Silent, ref errors, ref warnings);
            if (!oOk)
            {
                return RespVo.genError($"当前文档保存失败，错误代码： {errors}");
            }

            return RespVo.genOk();
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
    }
}
