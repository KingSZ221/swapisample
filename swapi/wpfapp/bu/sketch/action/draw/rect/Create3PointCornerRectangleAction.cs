using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.rect;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.draw.rect
{
    /// <summary>
    /// 绘制3点边角矩形
    /// </summary>
    public class Create3PointCornerRectangleAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public Create3PointCornerRectangleAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            Create3PointCornerRectangleInVo oInVo = this.actionInVo<Create3PointCornerRectangleInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.Create3PointCornerRectangle(oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000,
                oInVo.X3 / 1000, oInVo.Y3 / 1000, oInVo.Z3 / 1000);
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制3点边角矩形成功");
        }
    }
}
