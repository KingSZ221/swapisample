using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.point;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.draw.point
{
    /// <summary>
    /// 绘制点
    /// </summary>
    public class CreatePointAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreatePointAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreatePointInVo oInVo = this.actionInVo<CreatePointInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchPoint = skeMgr.CreatePoint(oInVo.X / 1000, oInVo.Y / 1000, oInVo.Z / 1000) as ISketchPoint;
            if (sketchPoint == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制点成功");
        }
    }
}
