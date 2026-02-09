using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.sketch.vo.compose.cube;
using swapilib.bu.sketch.vo.draw.rect;
using swapilib.bu.sketch.vo.entity;
using swapilib.bu.feature.vo.feature.extrusion;
using swapilib.bu.sketch.vo.sketch;
using swapilib.basic.io;

namespace swapilib.bu.sketch.action.compose.cube
{
    /// <summary>
    /// 创建立方体
    /// </summary>
    public class CreateCubeAction : SwSketchActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateCubeAction() : base()
        {

        }

        #endregion

    //    protected override RespVo onExecute()
    //    {
    //        return createWithSteps();
    //    }


    //    protected RespVo createWithSteps()
    //    {
    //        // 获取绘制参数
    //        CreateCubeInVo oInVo = this.actionInVo<CreateCubeInVo>();
    //        if (oInVo == null)
    //        {
    //            return RespVoLogExt.genError("获取绘制参数错误");
    //        }

    //        // 构造返回结果参数
    //        CreateCubeOutVo oOutVo = new CreateCubeOutVo();

    //        #region Step1 绘制俯视草图

    //        //1.俯视图截面
    //        RespVo oRespVo = this.step1(oInVo, oOutVo);
    //        if (!oRespVo.ok)
    //        {
    //            return oRespVo;
    //        }

    //        Task.Delay(1); // 短暂延迟，让UI更新

    //        #endregion

    //        #region Step2 绘制立方体

    //        //1.绘制立方体
    //        oRespVo = this.step2(oInVo, oOutVo);
    //        if (!oRespVo.ok)
    //        {
    //            return oRespVo;
    //        }
    //        else
    //        {
    //            return RespVoLogExt.genOk("绘制立方体成功", oOutVo);
    //        }

    //        #endregion
    //    }

    //    /// <summary>
    //    /// Step1 绘制草图
    //    /// 1.俯视图截面矩形
    //    /// </summary>
    //    private RespVo step1(CreateCubeInVo oInVo, CreateCubeOutVo oOutVo)
    //    {
    //        //Step1 绘制右视草图
    //        //1.俯视图截面矩形

    //        //Step1 绘制草图1
    //        SwBuLogService.SInfo("Step1 绘制俯视草图开始");

    //        //1.创建草图
    //        RespVo oRespVo;
    //        oOutVo.SketchEditInVo = new EditSketchInVo();
    //        oOutVo.SketchEditInVo.SketchName = "俯视草图";
    //        oOutVo.SketchEditInVo.RefPlaneName = "上视基准面";
    //        oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchCmdType.EditSketch, oOutVo.SketchEditInVo);
    //        if (!oRespVo.ok)
    //        {
    //            return oRespVo;
    //        }

    //        //2.俯视截面矩形
    //        // 构造绘制参数
    //        oOutVo.ContourInVo = new CreateCenterRectangleInVo();
    //        oOutVo.ContourInVo.X1 = 0;
    //        oOutVo.ContourInVo.Y1 = 0;
    //        oOutVo.ContourInVo.X2 = oInVo.Length / 2;
    //        oOutVo.ContourInVo.Y2 = oInVo.Width / 2;
    //        // 绘制图形
    //        oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchCmdType.CreateCenterRectangle, oOutVo.ContourInVo);
    //        if (!oRespVo.ok)
    //        {
    //            return oRespVo;
    //        }
    //        // 获取绘制图形
    //        oOutVo.ContourOutVo = oRespVo.resultObj as SketchArcInfo;

    //        //3.退出编辑草图
    //        oOutVo.SketchExitInVo = new ExitSketchInVo();
    //        oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchCmdType.ExitSketch, oOutVo.SketchExitInVo);
    //        if (!oRespVo.ok)
    //        {
    //            return oRespVo;
    //        }

    //        return RespVoLogExt.genOk("Step1 绘制俯视草图成功");
    //    }

    //    /// <summary>
    //    /// Step2 创建立方体
    //    /// 1.拉伸薄壁-立方体
    //    /// </summary>
    //    private RespVo step2(CreateCubeInVo oInVo, CreateCubeOutVo oOutVo)
    //    {
    //        //Step3 创建面管
    //        RespVo oRespVo;
    //        SwBuLogService.SInfo("Step2 创建立方体开始");

    //        //1.拉伸薄壁-立方体
    //        // 获取绘制参数
    //        oOutVo.FeatureCube = new FeatureExtrusionThinInVo();
    //        oOutVo.FeatureCube.SketchName = oOutVo.SketchEditInVo.SketchName;
    //        oOutVo.FeatureCube.ContourName = oOutVo.ContourOutVo.Name;
    //        oOutVo.FeatureCube.FeatrueName = "面管1";
    //        oOutVo.FeatureCube.Sd = false;
    //        oOutVo.FeatureCube.D1 = oInVo.Height / 2;
    //        oOutVo.FeatureCube.D2 = oInVo.Height / 2;
    //        oOutVo.FeatureCube.Thk1 = 0.01;
    //        // 绘制图形
    //        oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchCmdType.FeatureExtrusion, oOutVo.FeatureCube);
    //        if (!oRespVo.ok)
    //        {
    //            return oRespVo;
    //        }

    //        return RespVoLogExt.genOk("Step2 创建立方体成功");
    //    }
    }
}
