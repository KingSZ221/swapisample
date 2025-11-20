using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.feature.vo.feature.sweep;
using wpfapp.basic.io;

namespace wpfapp.bu.feature.action.feature.sweep
{
    /// <summary>
    /// 创建扫描切除特征
    /// </summary>
    public class FeatureSweepCutAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FeatureSweepCutAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            FeatureSweepCutInVo oInVo = this.actionInVo<FeatureSweepCutInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            SweepFeatureData oSweepFeatureData = featMgr.CreateDefinition((int)swFeatureNameID_e.swFmSweepCut) as SweepFeatureData;
            if (oSweepFeatureData == null)
            {
                return RespVoLogExt.genError("创建扫描切除特征参数错误");
            }

            Feature oFeature = featMgr.CreateFeature(oSweepFeatureData);
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建扫描切除特征错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建扫描切除特征成功：{oFeature.Name}");
        }
    }
}
