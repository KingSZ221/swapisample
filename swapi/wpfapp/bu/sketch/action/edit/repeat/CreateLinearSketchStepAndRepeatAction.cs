using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.edit.repeat;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.edit.repeat
{
    /// <summary>
    /// 线性草图阵列
    /// </summary>
    public class CreateLinearSketchStepAndRepeatAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateLinearSketchStepAndRepeatAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateLinearSketchStepAndRepeatInVo oInVo = this.actionInVo<CreateLinearSketchStepAndRepeatInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 编辑图形
            var bOk = skeMgr.CreateLinearSketchStepAndRepeat(oInVo.NumX, oInVo.NumY, oInVo.SpacingX / 1000, oInVo.SpacingY / 1000, oInVo.AngleX * Math.PI / 180, oInVo.AngleY * Math.PI / 180, oInVo.DeleteInstances, oInVo.XSpacingDim, oInVo.YSpacingDim, oInVo.AngleDim, oInVo.CreateNumOfInstancesDimInXDir, oInVo.CreateNumOfInstancesDimInYDir);
            if (!bOk)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("线性草图阵列成功");
        }
    }
}
