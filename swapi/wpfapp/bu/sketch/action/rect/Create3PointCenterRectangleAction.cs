using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.rect;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.rect
{
    /// <summary>
    /// 绘制3点中心矩形
    /// </summary>
    public class Create3PointCenterRectangleAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public Create3PointCenterRectangleAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            Create3PointCenterRectangleInVo oInVo = this.actionInVo<Create3PointCenterRectangleInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            skeMgr.Create3PointCenterRectangle(oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000,
                oInVo.X3 / 1000, oInVo.Y3 / 1000, oInVo.Z3 / 1000);

            return RespVoLogExt.genOk("绘制3点中心矩形成功");
        }
    }
}
