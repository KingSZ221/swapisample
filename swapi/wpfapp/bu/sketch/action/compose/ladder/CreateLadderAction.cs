using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.compose.ladder;
using wpfapp.bu.sketch.vo.draw.circle;
using wpfapp.bu.sketch.vo.draw.define;
using wpfapp.bu.sketch.vo.draw.line;
using wpfapp.bu.sketch.vo.entity;
using wpfapp.bu.feature.vo.feature.extrusion;
using wpfapp.bu.sketch.vo.sketch;
using wpfapp.basic.io;
using wpfapp.bu.feature.cmd;
using wpfapp.bu.feature;

namespace wpfapp.bu.sketch.action.compose.ladder
{

    /// <summary>
    /// 绘制扶梯
    /// </summary>
    public class CreateLadderAction : SwSketchComposeActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateLadderAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            return createWith6Steps();
        }

        protected RespVo createWith6Steps()
        {
            // 获取绘制参数
            CreateLadderInVo oInVo = this.actionInVo<CreateLadderInVo>();
            if(oInVo == null)
            {
                return RespVoLogExt.genError("获取绘制参数错误");
            }

            // 构造返回结果参数
            CreateLadderOutVo oOutVo = new CreateLadderOutVo();

            #region Step1 绘制横杆草图

            //1.面管1截面圆
            //2.面管2截面圆
            //3.横杆1截面圆
            //4.横杆2截面圆
            RespVo oRespVo = this.step1(oInVo, oOutVo);
            if(!oRespVo.ok)
            {
                return oRespVo;
            }

            Task.Delay(1); // 短暂延迟，让UI更新

            #endregion

            #region Step2 绘制竖杆草图

            //1.立柱1截面圆
            //2.立柱2截面圆
            //3.竖杆1截面圆
            //4.竖杆1截面圆整列
            oRespVo = this.step2(oInVo, oOutVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            Task.Delay(1); // 短暂延迟，让UI更新

            #endregion

            #region Step3 创建面管

            //1.拉伸薄壁-面管1
            //2.拉伸薄壁-面管2
            oRespVo = this.step3(oInVo, oOutVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            Task.Delay(1); // 短暂延迟，让UI更新

            #endregion

            #region Step4 创建立柱

            //1.拉伸薄壁-立柱1
            //2.拉伸薄壁-立柱2
            oRespVo = this.step4(oInVo, oOutVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            Task.Delay(1); // 短暂延迟，让UI更新

            #endregion

            #region Step5 创建横杆

            //1.拉伸薄壁-横杆1
            //2.拉伸薄壁-横杆2
            oRespVo = this.step5(oInVo, oOutVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            Task.Delay(1); // 短暂延迟，让UI更新

            #endregion

            #region Step6 创建竖杆

            //1.拉伸薄壁-竖杆1
            //2.拉伸薄壁-竖杆N
            oRespVo = this.step6(oInVo, oOutVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }
            else
            {
                return RespVoLogExt.genOk("绘制扶梯成功", oOutVo);
            }

            #endregion
        }

        /// <summary>
        /// Step1 绘制横杆草图
        /// 1.面管1截面圆
        /// 2.面管2截面圆
        /// 3.横杆1截面圆
        /// 4.横杆2截面圆
        /// </summary>
        private RespVo step1(CreateLadderInVo oInVo, CreateLadderOutVo oOutVo)
        {
            //Step1 绘制右视草图
            //1.面管1截面圆
            //2.面管2截面圆
            //3.横杆1截面圆
            //4.横杆2截面圆

            //Step1 绘制草图1
            SwBuLogService.SInfo("Step1 绘制横杆草图开始");

            //0.创建草图
            RespVo oRespVo;
            oOutVo.SketchHengGanEditInVo = new EditSketchInVo();
            oOutVo.SketchHengGanEditInVo.SketchName = "横杆草图";
            oOutVo.SketchHengGanEditInVo.RefPlaneName = "右视基准面";
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.EditSketch, oOutVo.SketchHengGanEditInVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            //1.面管1截面圆
            // 构造绘制参数
            oOutVo.ContourMianGuan1InVo = new CreateCircleInVo();
            oOutVo.ContourMianGuan1InVo.XC = 0;
            oOutVo.ContourMianGuan1InVo.YC = oInVo.LiZhuHeight / 2;
            oOutVo.ContourMianGuan1InVo.XP = 0;
            oOutVo.ContourMianGuan1InVo.YP = oInVo.LiZhuHeight / 2 + oInVo.MianGuanRadius;
            // 绘制图形
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCircle, oOutVo.ContourMianGuan1InVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }
            // 获取绘制图形
            oOutVo.ContourMianGuan1OutVo = oRespVo.resultObj as SketchArcInfo;

            //2.面管2截面圆
            // 构造绘制参数
            oOutVo.ContourMianGuan2InVo = new CreateCircleInVo();
            oOutVo.ContourMianGuan2InVo.XC = 0;
            oOutVo.ContourMianGuan2InVo.YC = -oInVo.LiZhuHeight / 2;
            oOutVo.ContourMianGuan2InVo.XP = 0;
            oOutVo.ContourMianGuan2InVo.YP = -oInVo.LiZhuHeight / 2 + oInVo.MianGuanRadius;
            // 绘制图形
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCircle, oOutVo.ContourMianGuan2InVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }
            // 获取绘制图形
            oOutVo.ContourMianGuan2OutVo = oRespVo.resultObj as SketchArcInfo;

            //3.横杆1截面圆
            // 构造绘制参数
            oOutVo.ContourHengGan1InVo = new CreateCircleInVo();
            oOutVo.ContourHengGan1InVo.XC = 0;
            oOutVo.ContourHengGan1InVo.YC = oInVo.ShuGanHeight / 2;
            oOutVo.ContourHengGan1InVo.XP = 0;
            oOutVo.ContourHengGan1InVo.YP = oInVo.ShuGanHeight / 2 + oInVo.HengGanRadius;
            // 绘制图形
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCircle, oOutVo.ContourHengGan1InVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }
            // 获取绘制图形
            oOutVo.ContourHengGan1OutVo = oRespVo.resultObj as SketchArcInfo;

            //4.横杆2截面圆
            // 构造绘制参数
            oOutVo.ContourHengGan2InVo = new CreateCircleInVo();
            oOutVo.ContourHengGan2InVo.XC = 0;
            oOutVo.ContourHengGan2InVo.YC = -oInVo.ShuGanHeight / 2;
            oOutVo.ContourHengGan2InVo.XP = 0;
            oOutVo.ContourHengGan2InVo.YP = -oInVo.ShuGanHeight / 2 + oInVo.HengGanRadius;
            // 绘制图形
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCircle, oOutVo.ContourHengGan2InVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }
            // 获取绘制图形
            oOutVo.ContourHengGan2OutVo = oRespVo.resultObj as SketchArcInfo;

            // 5.退出编辑草图
            oOutVo.SketchHengGanExitInVo = new ExitSketchInVo();
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.ExitSketch, oOutVo.SketchHengGanExitInVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            return RespVoLogExt.genOk("Step1 绘制横杆草图成功");
        }

        /// <summary>
        /// Step2 绘制草图2
        /// 1.立柱1截面圆
        /// 2.立柱2截面圆
        /// 3.竖杆1截面圆
        /// 4.竖杆N截面圆
        /// </summary>
        private RespVo step2(CreateLadderInVo oInVo, CreateLadderOutVo oOutVo)
        {
            //Step2 绘制竖杆草图
            //1.立柱1截面圆
            //2.立柱2截面圆
            //3.竖杆1截面圆
            //4.竖杆1截面圆整列

            //Step2 绘制草图2
            SwBuLogService.SInfo("Step2 绘制竖杆草图开始");

            //0.创建草图
            RespVo oRespVo;
            oOutVo.SketchShuGanEditInVo = new EditSketchInVo();
            oOutVo.SketchShuGanEditInVo.SketchName = "竖杆草图";
            oOutVo.SketchShuGanEditInVo.RefPlaneName = "上视基准面";
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.EditSketch, oOutVo.SketchShuGanEditInVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            //1.立柱1截面圆
            // 获取绘制参数
            oOutVo.ContourLiZhu1InVo = new CreateCircleInVo();
            oOutVo.ContourLiZhu1InVo.XC = -(oInVo.HengGanWidth / 2);
            oOutVo.ContourLiZhu1InVo.YC = 0;
            oOutVo.ContourLiZhu1InVo.XP = -(oInVo.HengGanWidth / 2) + oInVo.LiZhuRadius;
            oOutVo.ContourLiZhu1InVo.YP = 0;
            // 绘制图形
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCircle, oOutVo.ContourLiZhu1InVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }
            // 获取绘制图形
            oOutVo.ContourLiZhu1OutVo = oRespVo.resultObj as SketchArcInfo;

            //2.立柱2截面圆
            oOutVo.ContourLiZhu2InVo = new CreateCircleInVo();
            oOutVo.ContourLiZhu2InVo.XC = oInVo.HengGanWidth / 2;
            oOutVo.ContourLiZhu2InVo.YC = 0;
            oOutVo.ContourLiZhu2InVo.XP = oInVo.HengGanWidth / 2 + oInVo.LiZhuRadius;
            oOutVo.ContourLiZhu2InVo.YP = 0;
            // 绘制图形
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCircle, oOutVo.ContourLiZhu2InVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }
            // 获取绘制图形
            oOutVo.ContourLiZhu2OutVo = oRespVo.resultObj as SketchArcInfo;

            //3.竖杆截面圆
            oOutVo.ContourShuGanListInVo = new List<CreateCircleInVo>();
            oOutVo.ContourShuGanListOutVo = new List<SketchArcInfo>();
            double xMin = -(oInVo.HengGanWidth / 2) + 100;
            double xMax = oInVo.HengGanWidth / 2 - 100;
            double xSpace = (xMax - xMin) / (oInVo.ShuGanCount - 1);
            for (int i = 0; i < oInVo.ShuGanCount; i++)
            {
                CreateCircleInVo oCreateCircleInVo = new CreateCircleInVo();
                oCreateCircleInVo.XC = xMin + i * xSpace;
                oCreateCircleInVo.YC = 0;
                oCreateCircleInVo.XP = xMin + i * xSpace + oInVo.ShuGanRadius;
                oCreateCircleInVo.YP = 0;
                oOutVo.ContourShuGanListInVo.Add(oCreateCircleInVo);
                // 绘制图形
                oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCircle, oCreateCircleInVo);
                if (!oRespVo.ok)
                {
                    return oRespVo;
                }
                // 获取绘制图形
                SketchArcInfo oContourShuGan = oRespVo.resultObj as SketchArcInfo;
                oOutVo.ContourShuGanListOutVo.Add(oContourShuGan);
            }

            // 5.退出编辑草图
            oOutVo.SketchShuGanExitInVo = new ExitSketchInVo();
            oRespVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.ExitSketch, oOutVo.SketchShuGanExitInVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            curDoc.ShowNamedView2("*等轴测", 7);
            curDoc.ViewZoomtofit2();

            return RespVoLogExt.genOk("Step2 绘制竖杆草图成功");
        }

        /// <summary>
        /// Step3 创建面管
        /// 1.拉伸薄壁-面管1
        /// 2.拉伸薄壁-面管2
        /// </summary>
        private RespVo step3(CreateLadderInVo oInVo, CreateLadderOutVo oOutVo)
        {
            //Step3 创建面管
            RespVo oRespVo;
            SwBuLogService.SInfo("Step3 创建面管开始");

            //1.拉伸薄壁-面管1
            // 获取绘制参数
            oOutVo.FeatureMianGuan1 = new FeatureExtrusionThinInVo();
            oOutVo.FeatureMianGuan1.SketchName = oOutVo.SketchHengGanEditInVo.SketchName;
            oOutVo.FeatureMianGuan1.ContourName = oOutVo.ContourMianGuan1OutVo.Name;
            oOutVo.FeatureMianGuan1.FeatrueName = "面管1";
            oOutVo.FeatureMianGuan1.Sd = false;
            oOutVo.FeatureMianGuan1.D1 = oInVo.MianGuanWidth / 2;
            oOutVo.FeatureMianGuan1.D2 = oInVo.MianGuanWidth / 2;
            oOutVo.FeatureMianGuan1.Thk1 = oInVo.MianGuanThickness;
            // 绘制图形
            oRespVo = SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusionThin, oOutVo.FeatureMianGuan1);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            //2.拉伸薄壁-面管2
            // 获取绘制参数
            oOutVo.FeatureMianGuan2 = new FeatureExtrusionThinInVo();
            oOutVo.FeatureMianGuan2.SketchName = oOutVo.SketchHengGanEditInVo.SketchName;
            oOutVo.FeatureMianGuan2.ContourName = oOutVo.ContourMianGuan2OutVo.Name;
            oOutVo.FeatureMianGuan2.FeatrueName = "面管2";
            oOutVo.FeatureMianGuan2.Sd = false;
            oOutVo.FeatureMianGuan2.D1 = oInVo.MianGuanWidth / 2;
            oOutVo.FeatureMianGuan2.D2 = oInVo.MianGuanWidth / 2;
            oOutVo.FeatureMianGuan2.Thk1 = oInVo.MianGuanThickness;
            // 绘制图形
            oRespVo = SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusionThin, oOutVo.FeatureMianGuan2);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            return RespVoLogExt.genOk("Step3 创建面管成功");
        }

        /// <summary>
        /// Step4 创建立柱
        /// 1.拉伸薄壁-立柱1
        /// 2.拉伸薄壁-立柱2
        /// </summary>
        private RespVo step4(CreateLadderInVo oInVo, CreateLadderOutVo oOutVo)
        {
            //Step4 创建立柱
            RespVo oRespVo;
            SwBuLogService.SInfo("Step4 创建立柱开始");

            //1.拉伸薄壁-立柱1
            // 获取绘制参数
            oOutVo.FeatureLiZhu1 = new FeatureExtrusionThinInVo();
            oOutVo.FeatureLiZhu1.SketchName = oOutVo.SketchShuGanEditInVo.SketchName;
            oOutVo.FeatureLiZhu1.ContourName = oOutVo.ContourLiZhu1OutVo.Name;
            oOutVo.FeatureLiZhu1.FeatrueName = "立柱1";
            oOutVo.FeatureLiZhu1.Sd = false;
            oOutVo.FeatureLiZhu1.D1 = oInVo.LiZhuHeight / 2;
            oOutVo.FeatureLiZhu1.D2 = oInVo.LiZhuHeight / 2;
            oOutVo.FeatureLiZhu1.Thk1 = oInVo.LiZhuThickness;
            // 绘制图形
            oRespVo = SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusionThin, oOutVo.FeatureLiZhu1);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            //2.拉伸薄壁-立柱2
            // 获取绘制参数
            oOutVo.FeatureLiZhu2 = new FeatureExtrusionThinInVo();
            oOutVo.FeatureLiZhu2.SketchName = oOutVo.SketchShuGanEditInVo.SketchName;
            oOutVo.FeatureLiZhu2.ContourName = oOutVo.ContourLiZhu2OutVo.Name;
            oOutVo.FeatureLiZhu2.FeatrueName = "立柱2";
            oOutVo.FeatureLiZhu2.Sd = false;
            oOutVo.FeatureLiZhu2.D1 = oInVo.LiZhuHeight / 2;
            oOutVo.FeatureLiZhu2.D2 = oInVo.LiZhuHeight / 2;
            oOutVo.FeatureLiZhu2.Thk1 = oInVo.LiZhuThickness;
            // 绘制图形
            oRespVo = SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusionThin, oOutVo.FeatureLiZhu2);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            return RespVoLogExt.genOk("Step4 创建立柱成功");
        }

        /// <summary>
        /// Step5 创建横杆
        /// 1.拉伸薄壁-横杆1
        /// 2.拉伸薄壁-横杆2
        /// </summary>
        private RespVo step5(CreateLadderInVo oInVo, CreateLadderOutVo oOutVo)
        {
            //Step5 创建横杆
            RespVo oRespVo;
            SwBuLogService.SInfo("Step5 创建横杆开始");

            //1.拉伸薄壁-横杆1
            // 获取绘制参数
            oOutVo.FeatureHengGan1 = new FeatureExtrusionThinInVo();
            oOutVo.FeatureHengGan1.SketchName = oOutVo.SketchHengGanEditInVo.SketchName;
            oOutVo.FeatureHengGan1.ContourName = oOutVo.ContourHengGan1OutVo.Name;
            oOutVo.FeatureHengGan1.FeatrueName = "横杆1";
            oOutVo.FeatureHengGan1.Sd = false;
            oOutVo.FeatureHengGan1.D1 = oInVo.HengGanWidth / 2;
            oOutVo.FeatureHengGan1.D2 = oInVo.HengGanWidth / 2;
            oOutVo.FeatureHengGan1.Thk1 = oInVo.HengGanThickness;
            // 绘制图形
            oRespVo = SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusionThin, oOutVo.FeatureHengGan1);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            //2.拉伸薄壁-横杆2
            // 获取绘制参数
            oOutVo.FeatureHengGan2 = new FeatureExtrusionThinInVo();
            oOutVo.FeatureHengGan2.SketchName = oOutVo.SketchHengGanEditInVo.SketchName;
            oOutVo.FeatureHengGan2.ContourName = oOutVo.ContourHengGan2OutVo.Name;
            oOutVo.FeatureHengGan2.FeatrueName = "横杆2";
            oOutVo.FeatureHengGan2.Sd = false;
            oOutVo.FeatureHengGan2.D1 = oInVo.HengGanWidth / 2;
            oOutVo.FeatureHengGan2.D2 = oInVo.HengGanWidth / 2;
            oOutVo.FeatureHengGan2.Thk1 = oInVo.HengGanThickness;
            // 绘制图形
            oRespVo = SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusionThin, oOutVo.FeatureHengGan2);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            return RespVoLogExt.genOk("Step5 创建横杆成功");
        }

        /// <summary>
        /// Step6 创建竖杆
        /// 1.拉伸薄壁-竖杆1
        /// 2.拉伸薄壁-竖杆N
        /// </summary>
        private RespVo step6(CreateLadderInVo oInVo, CreateLadderOutVo oOutVo)
        {
            //Step6 创建竖杆
            RespVo oRespVo;
            SwBuLogService.SInfo("Step6 创建竖杆开始");

            //1.拉伸薄壁-竖杆1
            //2.拉伸薄壁-竖杆N
            oOutVo.FeatureShuGanList = new List<FeatureExtrusionThinInVo>();
            for (int i = 0; i < oOutVo.ContourShuGanListOutVo.Count; i ++)
            {
                SketchArcInfo oContourShuGan = oOutVo.ContourShuGanListOutVo[i];
                // 获取绘制参数
                FeatureExtrusionThinInVo oFeatureShuGan = new FeatureExtrusionThinInVo();
                oFeatureShuGan.SketchName = oOutVo.SketchShuGanEditInVo.SketchName;
                oFeatureShuGan.ContourName = oContourShuGan.Name;
                oFeatureShuGan.FeatrueName = $"竖杆{i+1}";
                oFeatureShuGan.Sd = false;
                oFeatureShuGan.D1 = oInVo.ShuGanHeight / 2;
                oFeatureShuGan.D2 = oInVo.ShuGanHeight / 2;
                oFeatureShuGan.Thk1 = oInVo.ShuGanThickness;
                // 绘制图形
                oRespVo = SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusionThin, oFeatureShuGan);
                if (!oRespVo.ok)
                {
                    return oRespVo;
                }
                oOutVo.FeatureShuGanList.Add(oFeatureShuGan);
            }

            return RespVoLogExt.genOk("Step6 创建竖杆成功");
        }

    }
}
