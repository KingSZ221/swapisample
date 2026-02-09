using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.sketch.vo.draw.slot;
using swapilib.basic.io;

namespace swapilib.bu.sketch.action.draw.slot
{
    /// <summary>
    /// 绘制中心点圆弧槽口
    /// </summary>
    public class CreateSketchSlotArcAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateSketchSlotArcAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateSketchSlotArcInVo oInVo = this.actionInVo<CreateSketchSlotArcInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSlot = skeMgr.CreateSketchSlot((int)swSketchSlotCreationType_e.swSketchSlotCreationType_arc, oInVo.SlotLengthType, oInVo.Width / 1000,
                oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000,
                oInVo.X3 / 1000, oInVo.Y3 / 1000, oInVo.Z3 / 1000,
                oInVo.CenterArcDirection, oInVo.AddDimension);
            if (sketchSlot == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制中心点圆弧槽口成功");
        }
    }
}
