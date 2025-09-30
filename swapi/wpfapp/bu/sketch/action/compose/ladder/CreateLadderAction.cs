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
using wpfapp.bu.vo;

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

        public CreateLadderAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            return createMethod2();
        }

        protected RespVo createMethod2()
        {
            // 获取绘制参数
            CreateLadderInVo oInVo = this.actionInVo<CreateLadderInVo>();
            if(oInVo == null)
            {
                return RespVoLogExt.genError("获取绘制参数错误");
            }

            //Step1 绘制草图1
            //1.面管1截面圆
            //2.面管2截面圆
            //3.横杆1截面圆
            //4.横杆2截面圆
            RespVo oRespVo = this.step1(oInVo);
            if(!oRespVo.ok)
            {
                return oRespVo;
            }

            //Step2 绘制草图2
            //1.立柱1截面圆
            //2.立柱2截面圆
            //3.竖杆1截面圆
            //4.竖杆1截面圆整列
            oRespVo = this.step2(oInVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            //Step3 创建面管
            //1.拉伸薄壁-面管1
            //2.拉伸薄壁-面管2
            oRespVo = this.step3(oInVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            //Step4 创建立柱
            //1.拉伸薄壁-立柱1
            //2.拉伸薄壁-立柱2
            oRespVo = this.step4(oInVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            //Step5 创建横杆
            //1.拉伸薄壁-横杆1
            //2.拉伸薄壁-横杆2
            oRespVo = this.step5(oInVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            //Step6 创建竖杆
            //1.拉伸薄壁-竖杆1
            //2.拉伸薄壁-竖杆N
            oRespVo = this.step6(oInVo);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }
            else
            {
                return RespVoLogExt.genOk("绘制扶梯成功");
            }
        }

        /// <summary>
        /// Step1 绘制草图1
        /// </summary>
        private RespVo step1(CreateLadderInVo oInVo)
        {
            //Step1 绘制草图1
            //1.面管1截面圆
            //2.面管2截面圆
            //3.横杆1截面圆
            //4.横杆2截面圆

            //Step1 绘制草图1

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            // 选中基准面
            RespVo oRespVo = priSelectRefPlane(curDoc, "右视基准面");
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            // 在这个基准面上插入一个草图，进入编辑草图模式
            skeMgr.InsertSketch(true);

            //1.面管1截面圆
            // 获取绘制参数
            CreateCircleInVo oCreateCircleInVo = new CreateCircleInVo();
            oCreateCircleInVo.XC = 0;
            oCreateCircleInVo.YC = oInVo.LiZhuHeight / 2;
            oCreateCircleInVo.XP = 0;
            oCreateCircleInVo.YP = oInVo.LiZhuHeight / 2 + oInVo.MianGuanRadius;
            // 绘制图形
            var sketchSegment = skeMgr.CreateCircle(oCreateCircleInVo.XC / 1000, oCreateCircleInVo.YC / 1000, oCreateCircleInVo.ZC / 1000,
                oCreateCircleInVo.XP / 1000, oCreateCircleInVo.YP / 1000, oCreateCircleInVo.ZP / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制面管1截面圆参数错误");
            }

            //2.面管2截面圆
            oCreateCircleInVo = new CreateCircleInVo();
            oCreateCircleInVo.XC = 0;
            oCreateCircleInVo.YC = -oInVo.LiZhuHeight / 2;
            oCreateCircleInVo.XP = 0;
            oCreateCircleInVo.YP = -oInVo.LiZhuHeight / 2 + oInVo.MianGuanRadius;
            // 绘制图形
            sketchSegment = skeMgr.CreateCircle(oCreateCircleInVo.XC / 1000, oCreateCircleInVo.YC / 1000, oCreateCircleInVo.ZC / 1000,
                oCreateCircleInVo.XP / 1000, oCreateCircleInVo.YP / 1000, oCreateCircleInVo.ZP / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制面管2截面圆参数错误");
            }

            //3.横杆1截面圆
            oCreateCircleInVo = new CreateCircleInVo();
            oCreateCircleInVo.XC = 0;
            oCreateCircleInVo.YC = oInVo.ShuGanHeight / 2;
            oCreateCircleInVo.XP = 0;
            oCreateCircleInVo.YP = oInVo.ShuGanHeight / 2 + oInVo.HengGanRadius;
            // 绘制图形
            sketchSegment = skeMgr.CreateCircle(oCreateCircleInVo.XC / 1000, oCreateCircleInVo.YC / 1000, oCreateCircleInVo.ZC / 1000,
                oCreateCircleInVo.XP / 1000, oCreateCircleInVo.YP / 1000, oCreateCircleInVo.ZP / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制横杆1截面圆参数错误");
            }

            //4.横杆2截面圆
            oCreateCircleInVo = new CreateCircleInVo();
            oCreateCircleInVo.XC = 0;
            oCreateCircleInVo.YC = -oInVo.ShuGanHeight / 2;
            oCreateCircleInVo.XP = 0;
            oCreateCircleInVo.YP = -oInVo.ShuGanHeight / 2 + oInVo.HengGanRadius;
            // 绘制图形
            sketchSegment = skeMgr.CreateCircle(oCreateCircleInVo.XC / 1000, oCreateCircleInVo.YC / 1000, oCreateCircleInVo.ZC / 1000,
                oCreateCircleInVo.XP / 1000, oCreateCircleInVo.YP / 1000, oCreateCircleInVo.ZP / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制横杆2截面圆参数错误");
            }

            // 退出编辑草图模式
            skeMgr.InsertSketch(true);

            return RespVoLogExt.genOk("Step1 绘制草图1成功");
        }

        /// <summary>
        /// Step2 绘制草图2
        /// </summary>
        private RespVo step2(CreateLadderInVo oInVo)
        {
            //Step2 绘制草图2
            //1.立柱1截面圆
            //2.立柱2截面圆
            //3.竖杆1截面圆
            //4.竖杆1截面圆整列

            //Step1 绘制草图2

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            // 选中基准面
            RespVo oRespVo = priSelectRefPlane(curDoc, "上视基准面");
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            // 在这个基准面上插入一个草图，进入编辑草图模式
            skeMgr.InsertSketch(true);

            //1.立柱1截面圆
            // 获取绘制参数
            CreateCircleInVo oCreateCircleInVo = new CreateCircleInVo();
            oCreateCircleInVo.XC = -(oInVo.HengGanWidth / 2);
            oCreateCircleInVo.YC = 0;
            oCreateCircleInVo.XP = -(oInVo.HengGanWidth / 2) + oInVo.LiZhuRadius;
            oCreateCircleInVo.YP = 0;
            // 绘制图形
            var sketchSegment = skeMgr.CreateCircle(oCreateCircleInVo.XC / 1000, oCreateCircleInVo.YC / 1000, oCreateCircleInVo.ZC / 1000,
                oCreateCircleInVo.XP / 1000, oCreateCircleInVo.YP / 1000, oCreateCircleInVo.ZP / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制立柱1截面圆参数错误");
            }

            //2.立柱2截面圆
            oCreateCircleInVo = new CreateCircleInVo();
            oCreateCircleInVo.XC = oInVo.HengGanWidth / 2;
            oCreateCircleInVo.YC = 0;
            oCreateCircleInVo.XP = oInVo.HengGanWidth / 2 + oInVo.LiZhuRadius;
            oCreateCircleInVo.YP = 0;
            // 绘制图形
            sketchSegment = skeMgr.CreateCircle(oCreateCircleInVo.XC / 1000, oCreateCircleInVo.YC / 1000, oCreateCircleInVo.ZC / 1000,
                oCreateCircleInVo.XP / 1000, oCreateCircleInVo.YP / 1000, oCreateCircleInVo.ZP / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制立柱2截面圆参数错误");
            }

            //3.竖杆1截面圆
            oCreateCircleInVo = new CreateCircleInVo();
            oCreateCircleInVo.XC = -(oInVo.HengGanWidth / 2) + 100;
            oCreateCircleInVo.YC = 0;
            oCreateCircleInVo.XP = -(oInVo.HengGanWidth / 2) + 100 + oInVo.ShuGanRadius;
            oCreateCircleInVo.YP = 0;
            // 绘制图形
            sketchSegment = skeMgr.CreateCircle(oCreateCircleInVo.XC / 1000, oCreateCircleInVo.YC / 1000, oCreateCircleInVo.ZC / 1000,
                oCreateCircleInVo.XP / 1000, oCreateCircleInVo.YP / 1000, oCreateCircleInVo.ZP / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制竖杆1截面圆参数错误");
            }

            //4.竖杆1截面圆整列
            //oCreateCircleInVo = new CreateCircleInVo();
            //oCreateCircleInVo.XC = 0;
            //oCreateCircleInVo.YC = -oInVo.ShuGanHeight / 2;
            //oCreateCircleInVo.XP = 0;
            //oCreateCircleInVo.YP = -oInVo.ShuGanHeight / 2 + oInVo.HengGanRadius;
            //// 绘制图形
            //sketchSegment = skeMgr.CreateCircle(oCreateCircleInVo.XC / 1000, oCreateCircleInVo.YC / 1000, oCreateCircleInVo.ZC / 1000,
            //    oCreateCircleInVo.XP / 1000, oCreateCircleInVo.YP / 1000, oCreateCircleInVo.ZP / 1000) as ISketchSegment;
            //if (sketchSegment == null)
            //{
            //    return RespVoLogExt.genError("绘制横杆2截面圆参数错误");
            //}

            // 退出编辑草图模式
            skeMgr.InsertSketch(true);

            return RespVoLogExt.genOk("Step2 绘制草图2成功");
        }

        /// <summary>
        /// Step3 创建面管
        /// </summary>
        private RespVo step3(CreateLadderInVo oInVo)
        {
            //Step3 创建面管
            //1.拉伸薄壁-面管1
            //2.拉伸薄壁-面管2

            return RespVoLogExt.genOk("Step3 创建面管成功");
        }

        /// <summary>
        /// Step4 创建立柱
        /// </summary>
        private RespVo step4(CreateLadderInVo oInVo)
        {
            //Step4 创建立柱
            //1.拉伸薄壁-立柱1
            //2.拉伸薄壁-立柱2

            return RespVoLogExt.genOk("Step4 创建立柱成功");
        }

        /// <summary>
        /// Step5 创建横杆
        /// </summary>
        private RespVo step5(CreateLadderInVo oInVo)
        {
            //Step5 创建横杆
            //1.拉伸薄壁-横杆1
            //2.拉伸薄壁-横杆2

            return RespVoLogExt.genOk("Step5 创建横杆成功");
        }

        /// <summary>
        /// Step6 创建竖杆
        /// </summary>
        private RespVo step6(CreateLadderInVo oInVo)
        {
            //Step6 创建竖杆
            //1.拉伸薄壁-竖杆1
            //2.拉伸薄壁-竖杆N

            return RespVoLogExt.genOk("Step6 创建竖杆成功");
        }

        protected RespVo createMethod1()
        {
            // 获取绘制参数
            CreateLadderInVo oInVo = this.actionInVo<CreateLadderInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            //子步骤 起点  终点
            //1.绘制面管1中心直线(0, 0)(2000, 0)
            //2.绘制面管2中心直线(0, -1500)(2000, -1500)
            //3.绘制立柱1中心直线(500, 0)(500, -1500)
            //4.绘制立柱2中心直线(1500, 0)(1500, -1500)
            //5.绘制横杆1中心直线(500, -250)(1500, -250)
            //6.绘制横杆2中心直线(500, -1250)(1500, -1250)
            //7.绘制竖杆1中心直线(600, -250)(600, -1250)
            //8.绘制竖杆2中心直线(1400, -250)(1400, -1250)
            //9.完全草图定义

            //1.绘制面管1中心直线(0, 0)(2000, 0)
            CreateLineInVo oCreateLineInVo = new CreateLineInVo();
            oCreateLineInVo.X1 = 0;
            oCreateLineInVo.Y1 = 0;
            oCreateLineInVo.X2 = oInVo.MianGuanWidth;
            oCreateLineInVo.Y2 = 0;
            RespVo oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateLine, oCreateLineInVo);
            if (!oRespVo.ok)
            {
                return RespVoLogExt.genError("绘制面管1中心直线参数错误");
            }

            //2.绘制面管2中心直线(0, -1500)(2000, -1500)
            oCreateLineInVo = new CreateLineInVo();
            oCreateLineInVo.X1 = 0;
            oCreateLineInVo.Y1 = -oInVo.LiZhuHeight;
            oCreateLineInVo.X2 = oInVo.MianGuanWidth;
            oCreateLineInVo.Y2 = -oInVo.LiZhuHeight;
            oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateLine, oCreateLineInVo);
            if (!oRespVo.ok)
            {
                return RespVoLogExt.genError("绘制面管2中心直线参数错误");
            }

            //3.绘制立柱1中心直线(500, 0)(500, -1500)
            oCreateLineInVo = new CreateLineInVo();
            oCreateLineInVo.X1 = (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2;
            oCreateLineInVo.Y1 = 0;
            oCreateLineInVo.X2 = (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2;
            oCreateLineInVo.Y2 = -oInVo.LiZhuHeight;
            oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateLine, oCreateLineInVo);
            if (!oRespVo.ok)
            {
                return RespVoLogExt.genError("绘制立柱1中心直线参数错误");
            }

            //4.绘制立柱2中心直线(1500, 0)(1500, -1500)
            oCreateLineInVo = new CreateLineInVo();
            oCreateLineInVo.X1 = oInVo.MianGuanWidth - (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2;
            oCreateLineInVo.Y1 = 0;
            oCreateLineInVo.X2 = oInVo.MianGuanWidth - (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2;
            oCreateLineInVo.Y2 = -oInVo.LiZhuHeight;
            oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateLine, oCreateLineInVo);
            if (!oRespVo.ok)
            {
                return RespVoLogExt.genError("绘制立柱2中心直线参数错误");
            }

            //5.绘制横杆1中心直线(500, -250)(1500, -250)
            oCreateLineInVo = new CreateLineInVo();
            oCreateLineInVo.X1 = (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2;
            oCreateLineInVo.Y1 = -(oInVo.LiZhuHeight - oInVo.ShuGanHeight) / 2;
            oCreateLineInVo.X2 = oInVo.MianGuanWidth - (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2;
            oCreateLineInVo.Y2 = -(oInVo.LiZhuHeight - oInVo.ShuGanHeight) / 2;
            oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateLine, oCreateLineInVo);
            if (!oRespVo.ok)
            {
                return RespVoLogExt.genError("绘制立柱2中心直线参数错误");
            }

            //6.绘制横杆2中心直线(500, -1250)(1500, -1250)
            oCreateLineInVo = new CreateLineInVo();
            oCreateLineInVo.X1 = (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2;
            oCreateLineInVo.Y1 = -oInVo.LiZhuHeight + (oInVo.LiZhuHeight - oInVo.ShuGanHeight) / 2;
            oCreateLineInVo.X2 = oInVo.MianGuanWidth - (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2;
            oCreateLineInVo.Y2 = -oInVo.LiZhuHeight + (oInVo.LiZhuHeight - oInVo.ShuGanHeight) / 2;
            oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateLine, oCreateLineInVo);
            if (!oRespVo.ok)
            {
                return RespVoLogExt.genError("绘制立柱2中心直线参数错误");
            }

            //7.绘制竖杆1中心直线(600, -250)(600, -1250)
            oCreateLineInVo = new CreateLineInVo();
            oCreateLineInVo.X1 = (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2 + oInVo.ShuGanJianGuangWidth;
            oCreateLineInVo.Y1 = -(oInVo.LiZhuHeight - oInVo.ShuGanHeight) / 2;
            oCreateLineInVo.X2 = (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2 + oInVo.ShuGanJianGuangWidth;
            oCreateLineInVo.Y2 = -oInVo.LiZhuHeight + (oInVo.LiZhuHeight - oInVo.ShuGanHeight) / 2;
            oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateLine, oCreateLineInVo);
            if (!oRespVo.ok)
            {
                return RespVoLogExt.genError("绘制立柱2中心直线参数错误");
            }

            //8.绘制竖杆2中心直线(1400, -250)(1400, -1250)
            oCreateLineInVo = new CreateLineInVo();
            oCreateLineInVo.X1 = oInVo.MianGuanWidth - (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2 - oInVo.ShuGanJianGuangWidth;
            oCreateLineInVo.Y1 = -(oInVo.LiZhuHeight - oInVo.ShuGanHeight) / 2;
            oCreateLineInVo.X2 = oInVo.MianGuanWidth - (oInVo.MianGuanWidth - oInVo.HengGanWidth) / 2 - oInVo.ShuGanJianGuangWidth;
            oCreateLineInVo.Y2 = -oInVo.LiZhuHeight + (oInVo.LiZhuHeight - oInVo.ShuGanHeight) / 2;
            oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateLine, oCreateLineInVo);
            if (!oRespVo.ok)
            {
                return RespVoLogExt.genError("绘制立柱2中心直线参数错误");
            }

            //9.完全草图定义
            //FullyDefineSketchInVo oFullyDefineSketchInVo = new FullyDefineSketchInVo();
            //oRespVo = SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.FullyDefineSketch, oFullyDefineSketchInVo);
            //if (!oRespVo.ok)
            //{
            //    return RespVoLogExt.genError("完全草图定义参数错误");
            //}

            //子步骤 起点  终点
            //1.绘制面管1中心直线(0, 0)(2000, 0)
            //2.绘制面管2中心直线(0, -1500)(2000, -1500)
            //3.绘制立柱1中心直线(500, 0)(500, -1500)
            //4.绘制立柱2中心直线(1500, 0)(1500, -1500)
            //5.绘制横杆1中心直线(500, -250)(1500, -250)
            //6.绘制横杆2中心直线(500, -1250)(1500, -1250)
            //7.绘制竖杆1中心直线(600, -250)(600, -1250)
            //8.绘制竖杆2中心直线(1400, -250)(1400, -1250)
            //9.完全草图定义

            return RespVoLogExt.genOk("绘制扶梯成功");
        }

    }
}
