using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.circle;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.circle
{
    /// <summary>
    /// 绘制周边圆
    /// </summary>
    public class PerimeterCircleAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public PerimeterCircleAction(object oInVo) : base(oInVo)
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
            skeMgr.PerimeterCircle(
                oInVo.X1 / 1000, oInVo.Y1 / 1000, 
                oInVo.X2 / 1000, oInVo.Y2 / 1000, 
                oInVo.X3 / 1000, oInVo.Y3 / 1000);

            return RespVoLogExt.genOk("绘制周边圆成功");
        }
    }
}
