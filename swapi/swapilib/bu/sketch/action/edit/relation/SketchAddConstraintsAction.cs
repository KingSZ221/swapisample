using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.sketch.vo.edit.relation;
using swapilib.basic.io;

namespace swapilib.bu.sketch.action.edit.relation
{
    /// <summary>
    /// 添加草图约束关系
    /// </summary>
    public class SketchAddConstraintsAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SketchAddConstraintsAction() : base()
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
