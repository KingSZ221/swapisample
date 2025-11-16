using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.feature.vo.feature.revolve;
using wpfapp.basic.io;

namespace wpfapp.bu.feature.action.feature.revolve
{
    /// <summary>
    /// 创建旋转基体/凸台
    /// </summary>
    public class FeatureRevolveAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FeatureRevolveAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            FeatureRevolveInVo oInVo = this.actionInVo<FeatureRevolveInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            // 清除选择
            curDoc.ClearSelection2(true);

            //selMgr.EnableContourSelection = true;

            // 选中待旋转的草图轮廓
            bool bSelContour = priSelectContourBySegmentName(oInVo.RevolveSketch.SketchName, oInVo.RevolveSketch.Name, 0);//"圆弧1"
            //bool bSelContour = curDocExt.SelectByID2($"{oInVo.ContourName}@{oInVo.SketchName}", "EXTSKETCHSEGMENT", 0, 0, 0, true, 4, null, 0);
            if (!bSelContour)
            {
                return RespVoLogExt.genError("选中待旋转的草图轮廓错误");
            }

            // 选中旋转轴
            //bSelContour = priSelectContourBySegmentName(oInVo.RevolveAxis.SketchName, oInVo.RevolveAxis.Name, 4);//"圆弧1"
            bSelContour = curDocExt.SelectByID2($"{oInVo.RevolveAxis.Name}@{oInVo.RevolveAxis.SketchName}", "EXTSKETCHSEGMENT", 0, 0, 0, true, 4, null, 0);
            if (!bSelContour)
            {
                return RespVoLogExt.genError("选中旋转轴错误");
            }

            //selMgr.EnableContourSelection = false;

            Feature oFeature = featMgr.FeatureRevolve2(
                SingleDir: oInVo.SingleDir, //拉伸方向
                IsSolid: oInVo.IsSolid,
                IsThin: oInVo.IsThin,
                IsCut: false,
                ReverseDir: oInVo.ReverseDir,
                BothDirectionUpToSameEntity: oInVo.BothDirectionUpToSameEntity,
                Dir1Type: oInVo.Dir1Type,
                Dir2Type: oInVo.Dir2Type,
                Dir1Angle: oInVo.Dir1Angle,
                Dir2Angle: oInVo.Dir2Angle,
                OffsetReverse1: oInVo.OffsetReverse1,
                OffsetReverse2: oInVo.OffsetReverse2,
                OffsetDistance1: oInVo.OffsetDistance1,
                OffsetDistance2: oInVo.OffsetDistance2,
                ThinType: oInVo.ThinType,
                ThinThickness1: oInVo.ThinThickness1,
                ThinThickness2: oInVo.ThinThickness2,
                Merge: oInVo.Merge,
                UseFeatScope: oInVo.UseFeatScope,
                UseAutoSelect: oInVo.UseAutoSelect
                );

            if (oFeature == null)
            {
                return RespVoLogExt.genError("旋转参数错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"旋转基体成功：{oFeature.Name}");
        }

        private bool priSelectContourBySegmentName(string strSketchName, string strSegmentName, int mark)
        {
            Sketch oSketch = priGetSketchByName(strSketchName);
            if (oSketch == null)
            {
                return false;
            }
            SketchContour sketchContour = priGetSketchContourBySegementName(oSketch, strSegmentName);
            if (sketchContour == null)
            {
                return false;
            }

            SelectionMgr selMgr = (SelectionMgr)curDoc.SelectionManager;
            SelectData selectData = selMgr.CreateSelectData();
            selectData.Mark = mark;

            return sketchContour.Select2(true, selectData);
        }

        private Sketch priGetSketchByName(string strSketchName)
        {
            FeatureManager featureMgr = curDoc.FeatureManager;
            object[] features = featureMgr.GetFeatures(false) as object[];
            for (int i = 0; i < features.Length; i++)
            {
                Feature feature = features[i] as Feature;
                if (feature != null)
                {
                    //Console.WriteLine($" {feature.Name} {feature.GetTypeName2()}");
                    if (feature.GetTypeName2() == "ProfileFeature")
                    {
                        Sketch oSketch = feature.GetSpecificFeature2() as Sketch;
                        if (oSketch != null && feature.Name == strSketchName)
                        {
                            return oSketch;
                        }
                    }
                }
            }
            return null;
        }

        private SketchContour priGetSketchContourBySegementName(Sketch oSketch, string strSegmentName)
        {
            object[] sketchContours = (object[])oSketch.GetSketchContours();
            if (sketchContours == null)
            {
                return null;
            }

            foreach (object objContour in sketchContours)
            {
                SketchContour sketchContour = (SketchContour)objContour;
                object[] sketchSegments = (object[])sketchContour.GetSketchSegments();
                if (sketchSegments != null)
                {
                    foreach (object objSegment in sketchSegments)
                    {
                        SketchSegment sketchSegment = (SketchSegment)objSegment;
                        string segmentName = sketchSegment.GetName();
                        Console.WriteLine($"segmentName:{segmentName}");
                        if (segmentName == strSegmentName)
                        {
                            return sketchContour;
                        }
                    }
                }
            }

            return null;
        }
    }
}
