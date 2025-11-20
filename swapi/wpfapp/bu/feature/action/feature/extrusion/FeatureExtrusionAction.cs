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

namespace wpfapp.bu.feature.action.feature.extrusion
{
    /// <summary>
    /// 拉伸凸台基体
    /// </summary>
    public class FeatureExtrusionAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FeatureExtrusionAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            FeatureExtrusionInVo oInVo = this.actionInVo<FeatureExtrusionInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            Feature oFeature = featMgr.FeatureExtrusion3(
                Sd: oInVo.Sd, //拉伸方向
                Flip: oInVo.Flip,
                Dir: oInVo.Dir,
                T1: (int)oInVo.T1,
                T2: (int)oInVo.T2,
                D1: oInVo.D1 / 1000, //拉伸深度
                D2: oInVo.D2 / 1000,
                //拔模参数
                Dchk1: oInVo.Dchk1,
                Dchk2: oInVo.Dchk2,
                Ddir1: oInVo.Ddir1,
                Ddir2: oInVo.Ddir2,
                Dang1: oInVo.Dang1,
                Dang2: oInVo.Dang2,
                //
                OffsetReverse1: oInVo.OffsetReverse1,
                OffsetReverse2: oInVo.OffsetReverse2,
                TranslateSurface1: oInVo.TranslateSurface1,
                TranslateSurface2: oInVo.TranslateSurface2,
                //实体和选择
                Merge: oInVo.Merge,
                UseFeatScope: oInVo.UseFeatScope,
                UseAutoSelect: oInVo.UseAutoSelect,
                //起始条件
                T0: (int)oInVo.T0,
                StartOffset: oInVo.StartOffset,
                FlipStartOffset: oInVo.FlipStartOffset
                );

            if (oFeature == null)
            {
                return RespVoLogExt.genError("拉伸参数错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"拉伸凸台基体成功：{oFeature.Name}");
        }
    }
}
