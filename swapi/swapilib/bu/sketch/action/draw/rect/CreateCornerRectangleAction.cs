using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.sketch.vo.entity;
using swapilib.bu.sketch.vo.draw.rect;
using swapilib.basic.io;

namespace swapilib.bu.sketch.action.draw.rect
{
    /// <summary>
    /// 绘制边角矩形
    /// </summary>
    public class CreateCornerRectangleAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateCornerRectangleAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateCornerRectangleInVo oInVo = this.actionInVo<CreateCornerRectangleInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.CreateCornerRectangle(oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000);
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            CreateRectangleOutVo oOutVo = new CreateRectangleOutVo();
            var sketchLines = sketchSegment as object[];
            foreach(var sketchLine in sketchLines)
            {
                SketchLineInfo lineInfo = SketchEntityConverter.ToLine(sketchLine as ISketchSegment);
                if (lineInfo != null)
                {
                    oOutVo.Lines.Add(lineInfo);
                }
            }

            return RespVoLogExt.genOk("绘制边角矩形成功", oOutVo);
        }
    }
}
