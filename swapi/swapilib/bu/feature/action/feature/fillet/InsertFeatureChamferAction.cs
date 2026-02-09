using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.basic.io;
using swapilib.bu.feature.vo.feature.fillet;

namespace swapilib.bu.feature.action.feature.fillet
{
    /// <summary>
    /// 创建倒角特征
    /// </summary>
    public class InsertFeatureChamferAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public InsertFeatureChamferAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            InsertFeatureChamferInVo oInVo = this.actionInVo<InsertFeatureChamferInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            Feature oFeature = featMgr.InsertFeatureChamfer(
                oInVo.getOptions(),
                (int)oInVo.ChamferType,
                oInVo.Width / 1000,
                oInVo.Angle * Math.PI / 180,
                oInVo.OtherDist,
                oInVo.VertexChamDist1,
                oInVo.VertexChamDist2,
                oInVo.VertexChamDist3);
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建倒角特征错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建倒角特征成功：{oFeature.Name}");
        }
    }
}