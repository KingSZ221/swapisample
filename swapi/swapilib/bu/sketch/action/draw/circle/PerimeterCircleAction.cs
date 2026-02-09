using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.sketch.vo.draw.circle;
using swapilib.basic.io;

namespace swapilib.bu.sketch.action.draw.circle
{
    /// <summary>
    /// 绘制周边圆
    /// </summary>
    public class PerimeterCircleAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public PerimeterCircleAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            PerimeterCircleInVo oInVo = this.actionInVo<PerimeterCircleInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.PerimeterCircle(
                oInVo.X1 / 1000, oInVo.Y1 / 1000, 
                oInVo.X2 / 1000, oInVo.Y2 / 1000, 
                oInVo.X3 / 1000, oInVo.Y3 / 1000);
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制周边圆成功");
        }
    }
}
