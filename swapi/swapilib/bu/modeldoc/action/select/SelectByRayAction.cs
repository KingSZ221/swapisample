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
    /// 通过射线选择对象
    /// </summary>
    public class SelectByRayAction : SwModelDocActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SelectByRayAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            SelectByRayInVo oInVo = this.actionInVo<SelectByRayInVo>();

            // 编辑图形
            bool bOk = curDocExt.SelectByRay(oInVo.WorldX / 1000, oInVo.WorldY / 1000, oInVo.WorldZ / 1000, oInVo.RayVecX, oInVo.RayVecY, oInVo.RayVecZ, oInVo.RayRadius / 1000, (int)oInVo.TypeWanted, oInVo.Append, oInVo.Mark, oInVo.Option);

            return RespVoLogExt.genOk("选择对象" + (bOk ? "成功" : "失败"));
        }
    }
}
