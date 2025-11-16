using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.line;
using wpfapp.bu.sketch.vo.entity;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.draw.line
{
    /// <summary>
    /// 绘制中心直线
    /// </summary>
    public class CreateCenterLineAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateCenterLineAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateCenterLineInVo oInVo = this.actionInVo<CreateCenterLineInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.CreateCenterLine(oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            // 获取图形信息
            SketchLineInfo oSketchEntity = SketchEntityConverter.ToLine(sketchSegment);

            return RespVoLogExt.genOk("绘制中心直线成功", oSketchEntity);
        }
    }
}
