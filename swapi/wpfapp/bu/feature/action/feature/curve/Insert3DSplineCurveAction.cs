using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.feature.vo.feature.curve;
using wpfapp.bu.log;

namespace wpfapp.bu.feature.action.feature.curve
{
    /// <summary>
    /// 创建3D样条曲线
    /// </summary>
    public class Insert3DSplineCurveAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public Insert3DSplineCurveAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            Insert3DSplineCurveInVo oInVo = this.actionInVo<Insert3DSplineCurveInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            curDoc.Insert3DSplineCurve(
                oInVo.CurveClosed
                );

            return RespVoLogExt.genOk("创建3D样条曲线完成");
        }

    }
}
