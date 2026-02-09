using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.sketch.vo.draw.arc;
using swapilib.basic.io;

namespace swapilib.bu.sketch.action.draw.arc
{
    /// <summary>
    /// 绘制切线弧
    /// </summary>
    public class CreateTangentArcAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateTangentArcAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateTangentArcInVo oInVo = this.actionInVo<CreateTangentArcInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.CreateTangentArc(
                oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000,
                oInVo.ArcType) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制切线弧成功");
        }
    }
}
