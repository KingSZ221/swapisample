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
using wpfapp.bu.feature.vo.feature.hole;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.feature.action.feature.extrusion
{
    /// <summary>
    /// 异形孔向导
    /// </summary>
    public class HoleWizardAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public HoleWizardAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            HoleWizardBaseInVo oInVo = this.actionInVo<HoleWizardBaseInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            Feature oFeature = featMgr.HoleWizard5(
                GenericHoleType: (int)oInVo.getHoleType(),
                StandardIndex: oInVo.StandardIndex,
                FastenerTypeIndex: oInVo.FastenerTypeIndex,
                SSize: oInVo.SSize,
                EndType: (short)oInVo.EndType,
                Diameter: oInVo.Diameter / 1000,
                Depth: oInVo.Depth / 1000,
                Length: oInVo.Length / 1000,
                Value1: oInVo.getValue(1),
                Value2: oInVo.getValue(2),
                Value3: oInVo.getValue(3),
                Value4: oInVo.getValue(4),
                Value5: oInVo.getValue(5),
                Value6: oInVo.getValue(6),
                Value7: oInVo.getValue(7),
                Value8: oInVo.getValue(8),
                Value9: oInVo.getValue(9),
                Value10: oInVo.getValue(10),
                Value11: oInVo.getValue(11),
                Value12: oInVo.getValue(12),
                ThreadClass: oInVo.ThreadClass,
                RevDir: oInVo.RevDir,
                FeatureScope: oInVo.FeatureScope,
                AutoSelect: oInVo.AutoSelect,
                AssemblyFeatureScope: oInVo.AssemblyFeatureScope,
                AutoSelectComponents: oInVo.AutoSelectComponents,
                PropagateFeatureToParts: oInVo.PropagateFeatureToParts
                );

            if (oFeature == null)
            {
                return RespVoLogExt.genError("异形孔向导参数错误");
            }

            // 设置异形孔位置
            if(oInVo.Positions.Count() > 0)
            {
                // 获取异形孔特征的第1个草图(位置草图)
                Feature oSketchFeature = (Feature)oFeature.GetFirstSubFeature();
                oSketchFeature.Select2(false, 0);
                curDoc.EditSketch();
                Sketch oSketch = (Sketch)oSketchFeature.GetSpecificFeature2();
                object[] swSketchPoints = oSketch.GetSketchPoints2() as object[];
                for(int i = 0; i < swSketchPoints.Length; i++)
                {
                    selMgr.AddSelectionListObject(swSketchPoints[i], null);
                    curDoc.EditDelete();
                }
                foreach(SketchMathPointInfo oSketchMathPointInfo in oInVo.Positions)
                {
                    skeMgr.CreatePoint(oSketchMathPointInfo.X / 1000, oSketchMathPointInfo.Y / 1000, oSketchMathPointInfo.Z / 1000);
                }
                skeMgr.InsertSketch(true);
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建{oInVo.getHoleTypeName()}成功：{oFeature.Name}");
        }
    }
}