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
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.edit.fillet
{
    /// <summary>
    /// 绘制倒角
    /// </summary>
    public class CreateChamferAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateChamferAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateChamferInVo oInVo = this.actionInVo<CreateChamferInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            ISketchSegment sketchSegment = null;
            // 编辑图形
            if (oInVo.Type == (int)swSketchChamferType_e.swSketchChamfer_DistanceEqual ||
                oInVo.Type == (int)swSketchChamferType_e.swSketchChamfer_DistanceDistance)
            {
                sketchSegment = skeMgr.CreateChamfer(oInVo.Type, oInVo.Distance / 1000, oInVo.AngleORdist / 1000) as ISketchSegment;
            }
            else
            {
                sketchSegment = skeMgr.CreateChamfer(oInVo.Type, oInVo.Distance / 1000, oInVo.AngleORdist / 180 * Math.PI) as ISketchSegment;
            }
            
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            SketchSegmentInfo oSegmentInfo = SketchEntityConverter.ToSegment(sketchSegment);

            return RespVoLogExt.genOk("绘制倒角成功", oSegmentInfo);
        }
    }
}
