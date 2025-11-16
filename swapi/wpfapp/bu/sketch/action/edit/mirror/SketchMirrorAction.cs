using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.edit.mirror;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.edit.mirror
{
    /// <summary>
    /// 镜像实体
    /// </summary>
    public class SketchMirrorAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SketchMirrorAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            SketchMirrorInVo oInVo = this.actionInVo<SketchMirrorInVo>();

            // 编辑前清空选中实体
            curDoc.ClearSelection();

            // 选择待镜像实体
            if (oInVo.MirrorEntityIds != null && oInVo.MirrorEntityIds.Count > 0)
            {
                foreach (var selectId in oInVo.MirrorEntityIds)
                {
                    curDocExt.SelectByID2(selectId.Name, selectId.Type, selectId.X / 1000, selectId.Y / 1000, selectId.Z / 1000, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
                }
            }

            // 选择镜像轴
            if (oInVo.CenterLineId != null)
            {
                var selectId = oInVo.CenterLineId;
                curDocExt.SelectByID2(selectId.Name, selectId.Type, selectId.X / 1000, selectId.Y / 1000, selectId.Z / 1000, true, 2, null, (int)swSelectOption_e.swSelectOptionDefault);
            }

            // 编辑图形
            curDoc.SketchMirror();

            return RespVoLogExt.genOk("镜像实体完成");
        }
    }
}
