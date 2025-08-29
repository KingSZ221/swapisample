using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.arc;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.arc
{
    /// <summary>
    /// 绘制切线弧
    /// </summary>
    public class CreateTangentArcAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateTangentArcAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateTangentArcInVo oInVo = this.actionInVo<CreateTangentArcInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            skeMgr.CreateTangentArc(
                oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000,
                oInVo.ArcType);

            return RespVoLogExt.genOk("绘制切线弧成功");
        }
    }
}
