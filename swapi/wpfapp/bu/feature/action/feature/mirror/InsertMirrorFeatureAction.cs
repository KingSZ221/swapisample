using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.basic.io;
using wpfapp.bu.feature.vo.feature.mirror;

namespace wpfapp.bu.feature.action.feature.mirror
{
    /// <summary>
    /// 创建镜像特征
    /// </summary>
    public class InsertMirrorFeatureAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public InsertMirrorFeatureAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            InsertMirrorFeatureInVo oInVo = this.actionInVo<InsertMirrorFeatureInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            Feature oFeature = featMgr.InsertMirrorFeature2(
                oInVo.BMirrorBody,
                oInVo.BGeometryPattern,
                oInVo.BMerge,
                oInVo.BKnit,
                (int)oInVo.ScopeOptions);
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建镜像特征错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建镜像特征成功：{oFeature.Name}");
        }
    }
}