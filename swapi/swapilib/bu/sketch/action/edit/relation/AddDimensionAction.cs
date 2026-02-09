using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
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
    public class AddDimensionAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public AddDimensionAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            AddDimensionInVo oInVo = this.actionInVo<AddDimensionInVo>();

            // 关闭输入尺寸弹框
            swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swInputDimValOnCreate, false);

            // 编辑图形
            var dimension = curDoc.AddDimension2(oInVo.X / 1000, oInVo.Y / 1000, oInVo.Z / 1000);
            if (dimension == null)
            {
                // 打开输入尺寸弹框
                swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swInputDimValOnCreate, true);
                return RespVoLogExt.genError("绘制参数错误");
            }

            //IDisplayDimension oDimension = (IDisplayDimension)dimension;

            // 打开输入尺寸弹框
            swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swInputDimValOnCreate, true);

            return RespVoLogExt.genOk("添加草图约束成功");
        }
    }
}
