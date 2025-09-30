using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.circle;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.draw.circle
{
    /// <summary>
    /// 绘制圆
    /// </summary>
    public class CreateCircleAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateCircleAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateCircleInVo oInVo = this.actionInVo<CreateCircleInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.CreateCircle(oInVo.XC / 1000, oInVo.YC / 1000, oInVo.ZC / 1000,
                oInVo.XP / 1000, oInVo.YP / 1000, oInVo.ZP / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            // 添加固定约束关系
            curDoc.SketchAddConstraints("sgFIXED");

            return RespVoLogExt.genOk("绘制圆成功");
        }
    }
}
