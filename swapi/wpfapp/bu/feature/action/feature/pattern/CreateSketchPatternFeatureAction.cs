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
    /// 创建草图阵列特征
    /// </summary>
    public class CreateSketchPatternFeatureAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateSketchPatternFeatureAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateSketchPatternFeatureInVo oInVo = this.actionInVo<CreateSketchPatternFeatureInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            SketchPatternFeatureData oFeatureData = featMgr.CreateDefinition((int)swFeatureNameID_e.swFmSketchPattern) as SketchPatternFeatureData;
            if (oFeatureData == null)
            {
                return RespVoLogExt.genError("创建草图阵列特征参数错误");
            }

            oFeatureData.GeometryPattern = oInVo.GeometryPattern;
            oFeatureData.UseCentroid = oInVo.UseCentroid;

            Feature oFeature = featMgr.CreateFeature(oFeatureData);
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建草图阵列特征错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建草图阵列特征成功：{oFeature.Name}");
        }
    }
}