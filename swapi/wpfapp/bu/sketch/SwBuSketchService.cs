using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.app;
using wpfapp.bu.log;
using wpfapp.bu.sketch.action;
using wpfapp.bu.sketch.vo;
using wpfapp.bu.vo;
using Xarial.XCad.SolidWorks;

namespace wpfapp.bu.sketch
{
    /// <summary>
    /// 草图服务
    /// </summary>
    public class SwBuSketchService
    {
        #region Fields

        private static SwBuSketchService _instance = new SwBuSketchService();

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuSketchService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuSketchService getInstance()
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

        #region 草图绘制操作

        public RespVo executeSketchAction(EnumSwSketchActionType actionType, object actionInVo)
        {
            return SwSketchActionProvider.getInstance().execute(actionType, actionInVo);
        }
        
        #endregion

        //#region 零件-圆管

        ///// <summary>
        ///// 在当前打开的零件文档中创建草图并绘制一个圆管
        ///// </summary>
        ///// <param name="oCreateCirclePipeInVo"></param>
        ///// <returns>RespVo</returns>
        //public RespVo createCirclePipe(CreateCirclePipeInVo oCreateCirclePipeInVo)
        //{
        //    // 当前激活文档
        //    ModelDoc2 doc = null;

        //    // 检查当前激活文档是否零件
        //    RespVo oRespVo = priCheckPartDoc(ref doc);
        //    if (!oRespVo.ok)
        //    {
        //        return oRespVo;
        //    }

        //    //创建草图，需要先找到一个基准面
        //    var feat = doc.FirstFeature() as IFeature;
        //    IFeature refFeat = default;
        //    while (feat != null)
        //    {
        //        var name = feat.GetTypeName2();
        //        if (name == "RefPlane")
        //        {
        //            refFeat = feat;
        //            break;
        //        }
        //        feat = feat.GetNextFeature() as IFeature;
        //    }

        //    //选中这个基准面
        //    refFeat.Select2(false, 0);

        //    //在这个基准面上插入一个草图
        //    var skeMgr = doc.SketchManager;
        //    skeMgr.InsertSketch(true);

        //    //先获取用户草屋激活捕捉设置是否打开
        //    var hasInference = swApp.Sw.GetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference);
        //    if (hasInference)
        //    {
        //        //用户已经打开了激活捕捉功能，则先关闭激活捕获
        //        swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
        //    }

        //    //绘制一个圆
        //    skeMgr.CreateCircleByRadius(0, 0, 0, oCreateCirclePipeInVo.CircleRadius / 1000);

        //    //还原用户设置
        //    swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, hasInference);

        //    var featMgr = doc.FeatureManager;
        //    //featMgr.FeatureExtrusion3(
        //    //    Sd: true, //单向拉伸
        //    //    Flip: false,
        //    //    Dir: false,
        //    //    T1: (int)swEndConditions_e.swEndCondBlind,
        //    //    T2: (int)swEndConditions_e.swEndCondBlind,
        //    //    D1: Double.Parse(txtBoxLength.Text) / 1000, //拉伸深度
        //    //    D2: 0,
        //    //    //拔模参数
        //    //    Dchk1: false,
        //    //    Dchk2: false,
        //    //    Ddir1: false,
        //    //    Ddir2: false,
        //    //    Dang1: 0,
        //    //    Dang2: 0,
        //    //    //
        //    //    OffsetReverse1: false,
        //    //    OffsetReverse2: false,
        //    //    TranslateSurface1: false,
        //    //    TranslateSurface2: false,
        //    //    //实体和选择
        //    //    Merge: true,
        //    //    UseFeatScope: true,
        //    //    UseAutoSelect: true,
        //    //    //起始条件
        //    //    T0: (int)swStartConditions_e.swStartSketchPlane,
        //    //    StartOffset: 0,
        //    //    FlipStartOffset: false
        //    //    );

        //    featMgr.FeatureExtrusionThin2(
        //        Sd: true, //单向拉伸
        //        Flip: false,
        //        Dir: false,
        //        T1: (int)swEndConditions_e.swEndCondBlind,
        //        T2: (int)swEndConditions_e.swEndCondBlind,
        //        D1: oCreateCirclePipeInVo.Length / 1000, //拉伸深度
        //        D2: 0,
        //        //拔模参数
        //        Dchk1: false,
        //        Dchk2: false,
        //        Ddir1: false,
        //        Ddir2: false,
        //        Dang1: 0,
        //        Dang2: 0,
        //        //
        //        OffsetReverse1: false,
        //        OffsetReverse2: false,
        //        TranslateSurface1: false,
        //        TranslateSurface2: false,
        //        //实体和选择
        //        Merge: true,
        //        Thk1: oCreateCirclePipeInVo.Thickness / 1000, //壁厚
        //        Thk2: 0,
        //        EndThk: 0,
        //        RevThinDir: 0,
        //        CapEnds: 0,
        //        AddBends: false,
        //        BendRad: 0,
        //        UseFeatScope: true,
        //        UseAutoSelect: true,
        //        //起始条件
        //        T0: (int)swStartConditions_e.swStartSketchPlane,
        //        StartOffset: 0,
        //        FlipStartOffset: false
        //        );

        //    return RespVoLogExt.genOk("创建圆管成功");
        //}

        //#endregion
    }
}
