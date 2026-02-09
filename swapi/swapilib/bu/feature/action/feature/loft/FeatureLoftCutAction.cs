using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.feature.vo.feature.loft;
using swapilib.basic.io;

namespace swapilib.bu.feature.action.feature.loft
{
    /// <summary>
    /// 创建放样切除特征
    /// </summary>
    public class FeatureLoftCutAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FeatureLoftCutAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            FeatureLoftCutInVo oInVo = this.actionInVo<FeatureLoftCutInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            Feature oFeature = featMgr.InsertCutBlend(
                // 放样形状
                Closed: oInVo.Closed,//是否闭合
                KeepTangency: oInVo.KeepTangency,//截面相切
                ForceNonRational: oInVo.ForceNonRational,//光滑表面
                TessToleranceFactor: oInVo.TessToleranceFactor,//中心线参数
                                                               // 起始和结束
                StartMatchingType: (short)oInVo.StartMatchingType,//起始轮廓处的相切类型
                EndMatchingType: (short)oInVo.EndMatchingType,//结束轮廓处的相切类型
                // 薄壁
                IsThinBody: oInVo.IsThinBody,//薄壁
                Thickness1: oInVo.Thickness1,//方向1的壁厚
                Thickness2: oInVo.Thickness2,//方向2的壁厚
                ThinType: (short)oInVo.ThinType,//薄壁类型
                // 多实体
                UseFeatScope: oInVo.UseFeatScope,//影响实体范围
                UseAutoSelect: oInVo.UseAutoSelect//自动选择实体
                );
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建放样切除特征错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建放样切除特征成功：{oFeature.Name}");
        }
    }
}
