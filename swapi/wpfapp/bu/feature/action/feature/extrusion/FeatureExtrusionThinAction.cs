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
    /// 薄壁拉伸
    /// </summary>
    public class FeatureExtrusionThinAction : SwFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FeatureExtrusionThinAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            FeatureExtrusionThinInVo oInVo = this.actionInVo<FeatureExtrusionThinInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            // 清除选择
            curDoc.ClearSelection2(true);

            // 选中草图轮廓
            //bool bSel = curDocExt.SelectByID2("圆弧1@草图2", "EXTSKETCHSEGMENT", 0, 0, 0, true, 4, null, 0);
            //bool bSel1 = curDocExt.SelectByID2("横杆草图", "SKETCH", 0, 0, 0, false, 0, null, 0);
            //if (!bSel1)
            //{
            //    return RespVoLogExt.genError("薄壁拉伸参数错误");
            //}
            bool bSelContour = priSelectContourBySegmentName(oInVo.SketchName, oInVo.ContourName, 4);//"圆弧1"
            if (!bSelContour)
            {
                return RespVoLogExt.genError("选中轮廓错误");
            }
            //selMgr.EnableContourSelection = true;
            //bool bSel = curDocExt.SelectByID2("Arc1", "SKETCHCONTOUR", 0, 0, 0, true, 4, null, 0); //EXTSKETCHSEGMENT
            //if (!bSel)
            //{
            //    return RespVoLogExt.genError("薄壁拉伸参数错误");
            //}

            //FeatureExtrusionThin2(False, False, False, 0, 0, 0.1, 0.1, False, False, False, False, 1.74532925199433E-02, 1.74532925199433E-02,
            //False, False, False, False, True, 0.002, 0.001, 0.002, 0, 0, False, 0.005, True, True, 0, 0, False)
            // 薄壁拉伸
            //Feature oFeature = featMgr.FeatureExtrusionThin2(
            //    Sd: oInVo.Sd, //拉伸方向
            //    Flip: false,
            //    Dir: false,
            //    T1: (int)swEndConditions_e.swEndCondBlind,
            //    T2: (int)swEndConditions_e.swEndCondBlind,
            //    D1: oInVo.D1 / 1000, //拉伸深度
            //    D2: oInVo.D2 / 1000, //拉伸深度
            //    //拔模参数
            //    Dchk1: false,
            //    Dchk2: false,
            //    Ddir1: false,
            //    Ddir2: false,
            //    Dang1: 0,
            //    Dang2: 0,
            //    //
            //    OffsetReverse1: false,
            //    OffsetReverse2: false,
            //    TranslateSurface1: false,
            //    TranslateSurface2: false,
            //    //实体和选择
            //    Merge: false,
            //    Thk1: oInVo.Thk1 / 1000, //壁厚
            //    Thk2: 0,
            //    EndThk: 0,
            //    RevThinDir: 0,
            //    CapEnds: 0,
            //    AddBends: false,
            //    BendRad: 0,
            //    UseFeatScope: true,
            //    UseAutoSelect: true,
            //    //起始条件
            //    T0: (int)swStartConditions_e.swStartSketchPlane,
            //    StartOffset: 0,
            //    FlipStartOffset: false
            //    );

            //selMgr.EnableContourSelection = false;

            Feature oFeature = featMgr.FeatureExtrusion3(
                Sd: oInVo.Sd, //拉伸方向
                Flip: false,
                Dir: false,
                T1: (int)swEndConditions_e.swEndCondBlind,
                T2: (int)swEndConditions_e.swEndCondBlind,
                D1: oInVo.D1 / 1000, //拉伸深度
                D2: oInVo.D2 / 1000,
                //拔模参数
                Dchk1: false,
                Dchk2: false,
                Ddir1: false,
                Ddir2: false,
                Dang1: 0,
                Dang2: 0,
                //
                OffsetReverse1: false,
                OffsetReverse2: false,
                TranslateSurface1: false,
                TranslateSurface2: false,
                //实体和选择
                Merge: true,
                UseFeatScope: true,
                UseAutoSelect: true,
                //起始条件
                T0: (int)swStartConditions_e.swStartSketchPlane,
                StartOffset: 0,
                FlipStartOffset: false
                );

            if (oFeature == null)
            {
                return RespVoLogExt.genError("薄壁拉伸参数错误");
            }
            
            if(!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"薄壁拉伸成功:{oFeature.Name}");
        }

        private bool priSelectContourBySegmentName(string strSketchName, string strSegmentName, int mark)
        {
            Sketch oSketch = priGetSketchByName(strSketchName);
            if(oSketch == null)
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
                if(sketchSegments != null)
                {
                    foreach(object objSegment in sketchSegments)
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
