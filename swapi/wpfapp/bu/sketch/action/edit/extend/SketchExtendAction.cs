using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.edit.extend;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.edit.extend
{
    /// <summary>
    /// 延伸实体
    /// </summary>
    public class SketchExtendAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SketchExtendAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            SketchExtendInVo oInVo = this.actionInVo<SketchExtendInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 编辑图形
            var bOk = skeMgr.SketchExtend(oInVo.X, oInVo.Y, oInVo.Z);
            if (!bOk)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("延伸实体成功");
        }
    }
}
