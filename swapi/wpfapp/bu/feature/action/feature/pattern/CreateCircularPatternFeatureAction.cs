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
    /// 创建圆形阵列特征
    /// </summary>
    public class CreateCircularPatternFeatureAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateCircularPatternFeatureAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateCircularPatternFeatureInVo oInVo = this.actionInVo<CreateCircularPatternFeatureInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            CircularPatternFeatureData oFeatureData = featMgr.CreateDefinition((int)swFeatureNameID_e.swFmCirPattern) as CircularPatternFeatureData;
            if (oFeatureData == null)
            {
                return RespVoLogExt.genError("创建圆形阵列特征参数错误");
            }

            oFeatureData.EqualSpacing = oInVo.EqualSpacing;
            oFeatureData.ReverseDirection = oInVo.ReverseDirection;
            oFeatureData.Spacing = oInVo.Spacing / 1000;
            oFeatureData.TotalInstances = oInVo.TotalInstances;
            oFeatureData.EqualSpacing2 = oInVo.EqualSpacing2;
            oFeatureData.Spacing2 = oInVo.Spacing2 / 1000;
            oFeatureData.TotalInstances2 = oInVo.TotalInstances2;
            oFeatureData.Direction2 = oInVo.Direction2;
            oFeatureData.GeometryPattern = oInVo.GeometryPattern;
            oFeatureData.VarySketch = oInVo.VarySketch;

            Feature oFeature = featMgr.CreateFeature(oFeatureData);
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建圆形阵列特征错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建圆形阵列特征成功：{oFeature.Name}");
        }
    }
}
