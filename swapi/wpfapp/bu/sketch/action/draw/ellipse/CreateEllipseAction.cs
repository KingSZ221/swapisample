using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.ellipse;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.draw.ellipse
{
    /// <summary>
    /// 绘制椭圆
    /// </summary>
    public class CreateEllipseAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateEllipseAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateEllipseInVo oInVo = this.actionInVo<CreateEllipseInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.CreateEllipse(oInVo.XC / 1000, oInVo.YC / 1000, oInVo.ZC / 1000,
                oInVo.XMajor / 1000, oInVo.YMajor / 1000, oInVo.ZMajor / 1000,
                oInVo.XMinor / 1000, oInVo.YMinor / 1000, oInVo.ZMinor / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制椭圆成功");
        }
    }
}
