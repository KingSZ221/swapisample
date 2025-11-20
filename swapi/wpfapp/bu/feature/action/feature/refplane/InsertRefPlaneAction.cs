using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.feature.vo.feature.refplane;
using wpfapp.bu.log;

namespace wpfapp.bu.feature.action.feature.refplane
{
    /// <summary>
    /// 创建参考面
    /// </summary>
    public class InsertRefPlaneAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public InsertRefPlaneAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            InsertRefPlaneInVo oInVo = this.actionInVo<InsertRefPlaneInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            object oFeature = featMgr.InsertRefPlane(
                oInVo.FirstConstraint,
                oInVo.FirstConstraintAngleOrDistance / 1000,
                oInVo.SecondConstraint,
                oInVo.SecondConstraintAngleOrDistance / 1000,
                oInVo.ThirdConstraint,
                oInVo.ThirdConstraintAngleOrDistance / 1000
                );
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建参考面错误");
            }

            //IRefPlane oRefPlane = (IRefPlane)oFeature;
            //if (!string.IsNullOrEmpty(oInVo.RefPlaneName))
            //{
            //    oRefPlane.Name = oInVo.RefPlaneName;
            //}

            return RespVoLogExt.genOk("创建参考面成功");
        }

    }
}
