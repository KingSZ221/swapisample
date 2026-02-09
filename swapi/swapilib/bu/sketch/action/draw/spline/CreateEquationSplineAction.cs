using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.sketch.vo.draw.spline;
using swapilib.basic.io;

namespace swapilib.bu.sketch.action.draw.spline
{
    /// <summary>
    /// 绘制方程式驱动曲线
    /// </summary>
    public class CreateEquationSplineAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateEquationSplineAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateEquationSplineInVo oInVo = this.actionInVo<CreateEquationSplineInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var spline = skeMgr.CreateEquationSpline2(oInVo.XExpression, oInVo.YExpression, oInVo.ZExpression, oInVo.RangeStart, oInVo.RangeEnd,
                oInVo.IsAngleRange, oInVo.RotationAngle, oInVo.XOffset, oInVo.YOffset, oInVo.LockStart, oInVo.LockEnd) as ISketchSpline;
            if (spline == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制方程式驱动曲线成功");
        }
    }
}
