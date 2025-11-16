using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.ellipse;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.draw.ellipse
{
    /// <summary>
    /// 绘制圆锥
    /// </summary>
    public class CreateConicAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateConicAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateConicInVo oInVo = this.actionInVo<CreateConicInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 抛物线方程:x^2=2py, y=x^2/(2p)
            double p = 2 * oInVo.YFocus;
            // 计算得出起点和终点的Y坐标
            double y1 = Math.Pow(oInVo.X1, 2) / (2 * p);
            double y2 = Math.Pow(oInVo.X2, 2) / (2 * p);

            // 绘制图形
            var sketchSegment = skeMgr.CreateConic(oInVo.XFocus / 1000, oInVo.YFocus / 1000, oInVo.ZFocus / 1000,
                oInVo.XApex / 1000, oInVo.YApex / 1000, oInVo.ZApex / 1000,
                oInVo.X1 / 1000, y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, y2 / 1000, oInVo.Z2 / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制圆锥成功");
        }
    }
}
