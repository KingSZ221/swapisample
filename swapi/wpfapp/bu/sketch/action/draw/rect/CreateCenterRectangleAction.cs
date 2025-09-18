using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.rect;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.draw.rect
{
    /// <summary>
    /// 绘制中心矩形
    /// </summary>
    public class CreateCenterRectangleAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateCenterRectangleAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateCenterRectangleInVo oInVo = this.actionInVo<CreateCenterRectangleInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.CreateCenterRectangle(oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000);
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制中心矩形成功");
        }
    }
}
