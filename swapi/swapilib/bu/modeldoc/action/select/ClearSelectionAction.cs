using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.basic.io;
using swapilib.bu.log;
using swapilib.bu.modeldoc.action;
using swapilib.bu.modeldoc.vo.select;

namespace swapilib.bu.modeldoc.action.select
{
    /// <summary>
    /// 清空选中对象列表
    /// </summary>
    public class ClearSelectionAction : SwModelDocActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public ClearSelectionAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            ClearSelectionInVo oInVo = this.actionInVo<ClearSelectionInVo>();

            // 编辑图形
            curDoc.ClearSelection2(oInVo.All);

            return RespVoLogExt.genOk("清空选中对象列表完成");
        }
    }
}
