using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.edit.trim;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.edit.trim
{
    /// <summary>
    /// 裁剪实体
    /// </summary>
    public class SketchTrimAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SketchTrimAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            SketchTrimInVo oInVo = this.actionInVo<SketchTrimInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 编辑图形
            var bOk = skeMgr.SketchTrim(oInVo.Option, oInVo.X, oInVo.Y, oInVo.Z);
            if (!bOk)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("裁剪实体成功");
        }
    }
}
