using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.log;
using wpfapp.bu.sketch.action.draw;
using wpfapp.bu.sketch.vo.select;

namespace wpfapp.bu.sketch.action.select
{
    /// <summary>
    /// 通过名称或坐标选择草图对象
    /// </summary>
    public class SelectByIDAction : SwModelDocActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SelectByIDAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            SelectByIDInVo oInVo = this.actionInVo<SelectByIDInVo>();

            // 编辑图形
            bool bOk = curDocExt.SelectByID2(oInVo.Name, oInVo.Type, oInVo.X / 1000, oInVo.Y / 1000, oInVo.Z / 1000, oInVo.Append, oInVo.Mark, null, oInVo.Option);

            return RespVoLogExt.genOk("选择草图对象" + (bOk ? "成功" : "失败"));
        }
    }
}
