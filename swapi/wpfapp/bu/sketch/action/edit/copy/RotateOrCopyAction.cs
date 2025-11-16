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
    /// 旋转或复制实体
    /// </summary>
    public class RotateOrCopyAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public RotateOrCopyAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            RotateOrCopyInVo oInVo = this.actionInVo<RotateOrCopyInVo>();

            // 编辑图形
            curDocExt.RotateOrCopy(oInVo.Copy, oInVo.NumCopies, oInVo.KeepRelations, oInVo.BaseX / 1000, oInVo.BaseY / 1000, oInVo.BaseZ / 1000, oInVo.DestX / 1000, oInVo.DestY / 1000, oInVo.DestZ / 1000, oInVo.Angle * Math.PI / 180);

            return RespVoLogExt.genOk("旋转或复制实体完成");
        }
    }
}
