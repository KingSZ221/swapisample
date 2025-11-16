using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.edit.copy;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.edit.copy
{
    /// <summary>
    /// 移动或复制实体
    /// </summary>
    public class MoveOrCopyAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public MoveOrCopyAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            MoveOrCopyInVo oInVo = this.actionInVo<MoveOrCopyInVo>();

            // 编辑图形
            curDocExt.MoveOrCopy(oInVo.Copy, oInVo.NumCopies, oInVo.KeepRelations, oInVo.BaseX / 1000, oInVo.BaseY / 1000, oInVo.BaseZ / 1000, oInVo.DestX / 1000, oInVo.DestY / 1000, oInVo.DestZ / 1000);

            return RespVoLogExt.genOk("移动或复制实体完成");
        }
    }
}
