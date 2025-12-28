using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.feature.vo.feature.extrusion;
using wpfapp.basic.io;
using wpfapp.bu.modeldoc.action;
using wpfapp.bu.modeldoc.vo.select;

namespace wpfapp.bu.modeldoc.action.select
{
    /// <summary>
    /// 选中特征树最后1个特征
    /// </summary>
    public class SelectFeatureByPositionReverseAction : SwModelDocActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SelectFeatureByPositionReverseAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            SelectFeatureByPositionReverseInVo oInVo = this.actionInVo<SelectFeatureByPositionReverseInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            Feature oFeature = (Feature)curDoc.FeatureByPositionReverse(oInVo.Num);

            if (oFeature == null)
            {
                return RespVoLogExt.genError("参数错误");
            }

            bool bOk = oFeature.Select2(oInVo.Append, oInVo.Mark);

            return RespVoLogExt.genOk("选择特征对象" + (bOk ? "成功" : "失败"));
        }
    }
}

