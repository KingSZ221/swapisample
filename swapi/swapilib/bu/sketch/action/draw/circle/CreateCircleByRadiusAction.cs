using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.basic.io;
using swapilib.bu.log;
using swapilib.bu.sketch.vo.draw.circle;
using swapilib.bu.sketch.vo.entity;

namespace swapilib.bu.sketch.action.draw.circle
{
    /// <summary>
    /// 绘制半径圆
    /// </summary>
    public class CreateCircleByRadiusAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateCircleByRadiusAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateCircleByRadiusInVo oInVo = this.actionInVo<CreateCircleByRadiusInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.CreateCircleByRadius(oInVo.XC / 1000, oInVo.YC / 1000, oInVo.ZC / 1000,
                oInVo.Radius / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            // 添加固定约束关系
            curDoc.SketchAddConstraints("sgFIXED");

            // 获取图形信息
            SketchArcInfo oSketchEntity = SketchEntityConverter.ToArc(sketchSegment);

            return RespVoLogExt.genOk("绘制圆成功", oSketchEntity);
        }
    }
}
