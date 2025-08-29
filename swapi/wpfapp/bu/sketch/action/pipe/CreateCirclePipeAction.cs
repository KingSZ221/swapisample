using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.pipe
{
    public class CreateCirclePipeAction : SwSketchActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateCirclePipeAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;

            // 获取绘制参数
            CreateCirclePipeInVo oInVo = this.actionInVo<CreateCirclePipeInVo>();

            // 在这个基准面上插入一个草图，进入编辑草图模式
            skeMgr.InsertSketch(true);

            // 绘制一个圆
            skeMgr.CreateCircleByRadius(0, 0, 0, oInVo.CircleRadius / 1000);

            // 退出草图编辑模式
            skeMgr.InsertSketch(true);

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
                D1: oInVo.Length / 1000, //拉伸深度
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
                Thk1: oInVo.Thickness / 1000, //壁厚
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

            return RespVoLogExt.genOk("绘制圆管成功");
        }
    }
}
