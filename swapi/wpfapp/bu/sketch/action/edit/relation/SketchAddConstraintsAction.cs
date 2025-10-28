using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.edit.relation;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.edit.relation
{
    /// <summary>
    /// 添加草图约束关系
    /// </summary>
    public class SketchAddConstraintsAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SketchAddConstraintsAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            SketchAddConstraintsInVo oInVo = this.actionInVo<SketchAddConstraintsInVo>();

            // 编辑图形
            curDoc.SketchAddConstraints(oInVo.ConstraintId);

            return RespVoLogExt.genOk("添加草图约束关系完成");
        }
    }
}
