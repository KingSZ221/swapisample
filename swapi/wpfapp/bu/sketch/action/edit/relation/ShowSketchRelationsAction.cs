using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.edit.relation;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.edit.relation
{
    /// <summary>
    /// 显示隐藏草图约束关系
    /// </summary>
    public class ShowSketchRelationsAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public ShowSketchRelationsAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            ShowSketchRelationsInVo oInVo = this.actionInVo<ShowSketchRelationsInVo>();

            // 编辑图形
            bool bShow = curDocExt.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewSketchRelations, (int)swUserPreferenceOption_e.swDetailingNoOptionSpecified, oInVo.Show);
            
            return RespVoLogExt.genOk(bShow ? "显示草图约束关系成功" : "隐藏草图约束关系成功");
        }
    }
}
