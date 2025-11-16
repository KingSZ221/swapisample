using SolidWorks.Interop.sldworks;
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
    /// 创建拉伸切除特征
    /// </summary>
    public class FeatureExtrusionCutAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FeatureExtrusionCutAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            FeatureExtrusionCutInVo oInVo = this.actionInVo<FeatureExtrusionCutInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            // 清除选择
            curDoc.ClearSelection2(true);

            //selMgr.EnableContourSelection = true;

            // 选中草图轮廓
            //bool bSelContour = priSelectContourBySegmentName(oInVo.SketchName, oInVo.ContourName, 4);//"圆弧1"
            ////bool bSelContour = curDocExt.SelectByID2($"{oInVo.ContourName}@{oInVo.SketchName}", "EXTSKETCHSEGMENT", 0, 0, 0, true, 4, null, 0);
            //if (!bSelContour)
            //{
            //    return RespVoLogExt.genError("选中轮廓错误");
            //}

            //selMgr.EnableContourSelection = false;

            Feature oFeature = featMgr.FeatureCut4(
                Sd: oInVo.Sd, //拉伸方向
                Flip: oInVo.Flip,
                Dir: oInVo.Dir,
                T1: oInVo.T1,
                T2: oInVo.T2,
                D1: oInVo.D1 / 1000, //拉伸深度
                D2: oInVo.D2 / 1000,
                //拔模参数
                Dchk1: oInVo.Dchk1,
                Dchk2: oInVo.Dchk2,
                Ddir1: oInVo.Ddir1,
                Ddir2: oInVo.Ddir2,
                Dang1: oInVo.Dang1,
                Dang2: oInVo.Dang2,
                //等距反向
                OffsetReverse1: oInVo.OffsetReverse1,
                OffsetReverse2: oInVo.OffsetReverse2,
                TranslateSurface1: oInVo.TranslateSurface1,
                TranslateSurface2: oInVo.TranslateSurface2,
                //正交切除
                NormalCut: oInVo.NormalCut,
                //选择
                UseFeatScope: oInVo.UseFeatScope,
                UseAutoSelect: oInVo.UseAutoSelect,
                AssemblyFeatureScope: oInVo.AssemblyFeatureScope,
                AutoSelectComponents: oInVo.AutoSelectComponents,
                PropagateFeatureToParts: oInVo.PropagateFeatureToParts,
                //起始条件
                T0: oInVo.T0,
                StartOffset: oInVo.StartOffset,
                FlipStartOffset: oInVo.FlipStartOffset,
                //正交切除
                OptimizeGeometry: oInVo.OptimizeGeometry
                );

            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建拉伸切除特征参数错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建拉伸切除特征成功：{oFeature.Name}");
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

            return sketchContour.Select2(false, selectData);
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
