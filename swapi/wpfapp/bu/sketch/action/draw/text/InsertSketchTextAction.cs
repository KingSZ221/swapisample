using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.text;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.draw.text
{
    /// <summary>
    /// 绘制文本
    /// </summary>
    public class InsertSketchTextAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public InsertSketchTextAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            InsertSketchTextInVo oInVo = this.actionInVo<InsertSketchTextInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var text = curDoc.InsertSketchText(oInVo.Ptx, oInVo.Pty, oInVo.Ptz, oInVo.Text, oInVo.Alignment,
                oInVo.FlipDirection, oInVo.HorizontalMirror, oInVo.WidthFactor, oInVo.SpaceBetweenChars) as ISketchText;
            if (text == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制文本成功");
        }
    }
}
