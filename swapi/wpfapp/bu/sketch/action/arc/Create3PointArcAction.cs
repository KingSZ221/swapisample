using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.arc;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.arc
{
    /// <summary>
    /// 绘制3点圆弧
    /// </summary>
    public class Create3PointArcAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public Create3PointArcAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            Create3PointArcInVo oInVo = this.actionInVo<Create3PointArcInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            skeMgr.Create3PointArc(
                oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000,
                oInVo.X3 / 1000, oInVo.Y3 / 1000, oInVo.Z3 / 1000);

            return RespVoLogExt.genOk("绘制圆成功");
        }
    }
}
