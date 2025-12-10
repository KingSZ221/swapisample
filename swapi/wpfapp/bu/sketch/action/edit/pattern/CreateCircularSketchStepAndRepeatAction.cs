using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.edit.pattern;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.edit.pattern
{
    /// <summary>
    /// 圆周草图阵列
    /// </summary>
    public class CreateCircularSketchStepAndRepeatAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateCircularSketchStepAndRepeatAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateCircularSketchStepAndRepeatInVo oInVo = this.actionInVo<CreateCircularSketchStepAndRepeatInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 编辑图形
            var bOk = skeMgr.CreateCircularSketchStepAndRepeat(oInVo.ArcRadius / 1000, oInVo.ArcAngle * Math.PI / 180, oInVo.PatternNum, oInVo.PatternSpacing * Math.PI / 180, oInVo.PatternRotate, oInVo.DeleteInstances, oInVo.RadiusDim, oInVo.AngleDim, oInVo.CreateNumOfInstancesDim);
            if (!bOk)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("圆周草图阵列成功");
        }
    }
}
