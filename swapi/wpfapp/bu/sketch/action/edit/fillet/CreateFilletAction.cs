using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.entity;
using wpfapp.bu.sketch.vo.edit.fillet;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.edit.fillet
{
    /// <summary>
    /// 绘制圆角
    /// </summary>
    public class CreateFilletAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateFilletAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateFilletInVo oInVo = this.actionInVo<CreateFilletInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 编辑图形
            var sketchSegment = skeMgr.CreateFillet(oInVo.Radius / 1000, oInVo.ConstrainedCorners) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            SketchSegmentInfo oSegmentInfo = SketchEntityConverter.ToSegment(sketchSegment);

            return RespVoLogExt.genOk("绘制圆角成功", oSegmentInfo);
        }
    }
}
