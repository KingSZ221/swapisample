using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.feature.vo.feature.pattern;
using wpfapp.basic.io;

namespace wpfapp.bu.feature.action.feature.pattern
{
    /// <summary>
    /// 创建线性阵列特征
    /// </summary>
    public class CreateLinearPatternFeatureAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateLinearPatternFeatureAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateLinearPatternFeatureInVo oInVo = this.actionInVo<CreateLinearPatternFeatureInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            LinearPatternFeatureData oFeatureData = featMgr.CreateDefinition((int)swFeatureNameID_e.swFmLPattern) as LinearPatternFeatureData;
            if (oFeatureData == null)
            {
                return RespVoLogExt.genError("创建线性阵列特征参数错误");
            }

            oFeatureData.D1EndCondition = (int)oInVo.D1EndCondition;
            oFeatureData.D1ReverseDirection = oInVo.D1ReverseDirection;
            oFeatureData.D1Spacing = oInVo.D1Spacing / 1000;
            oFeatureData.D1TotalInstances = oInVo.D1TotalInstances;
            oFeatureData.D2EndCondition = (int)oInVo.D2EndCondition;
            oFeatureData.D2ReverseDirection = oInVo.D2ReverseDirection;
            oFeatureData.D2Spacing = oInVo.D2Spacing / 1000;
            oFeatureData.D2TotalInstances = oInVo.D2TotalInstances;
            oFeatureData.D2PatternSeedOnly = oInVo.D2PatternSeedOnly;
            oFeatureData.GeometryPattern = oInVo.GeometryPattern;
            oFeatureData.VarySketch = oInVo.VarySketch;

            Feature oFeature = featMgr.CreateFeature(oFeatureData);
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建线性阵列特征错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建线性阵列特征成功：{oFeature.Name}");
        }
    }
}
