using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.basic.io;
using wpfapp.bu.feature.vo.feature.fillet;

namespace wpfapp.bu.feature.action.feature.fillet
{
    /// <summary>
    /// 创建圆角特征
    /// </summary>
    public class SimpleFilletAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SimpleFilletAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            SimpleFilletInVo oInVo = this.actionInVo<SimpleFilletInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            SimpleFilletFeatureData2 oSimpleFilletFeatureData = featMgr.CreateDefinition((int)swFeatureNameID_e.swFmFillet) as SimpleFilletFeatureData2;
            if (oSimpleFilletFeatureData == null)
            {
                return RespVoLogExt.genError("创建圆角特征参数错误");
            }

            oSimpleFilletFeatureData.Initialize((int)oInVo.FilletType);
            oSimpleFilletFeatureData.AsymmetricFillet = oInVo.AsymmetricFillet;
            oSimpleFilletFeatureData.DefaultRadius = oInVo.DefaultRadius / 1000;
            oSimpleFilletFeatureData.DefaultDistance = oInVo.DefaultDistance / 1000;
            oSimpleFilletFeatureData.ConicTypeForCrossSectionProfile = (int)oInVo.ConicTypeForCrossSectionProfile; 

            Feature oFeature = featMgr.CreateFeature(oSimpleFilletFeatureData);
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建圆角特征错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建圆角特征成功：{oFeature.Name}");
        }
    }
}