using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.polygon;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.draw.polygon
{
    /// <summary>
    /// 绘制多边形
    /// </summary>
    public class CreatePolygonAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreatePolygonAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreatePolygonInVo oInVo = this.actionInVo<CreatePolygonInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.CreatePolygon(oInVo.XC / 1000, oInVo.YC / 1000, oInVo.ZC / 1000,
                oInVo.XP / 1000, oInVo.YP / 1000, oInVo.ZP / 1000, oInVo.Sides, oInVo.Inscribed);
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制多边形成功");
        }
    }
}
