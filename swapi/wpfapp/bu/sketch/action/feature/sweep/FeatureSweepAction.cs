using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.feature.sweep;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.feature.sweep
{
    /// <summary>
    /// 创建扫描基体/凸台特征
    /// </summary>
    public class FeatureSweepAction : SwSketchFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FeatureSweepAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            FeatureSweepInVo oInVo = this.actionInVo<FeatureSweepInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;
            var featMgr = curDoc.FeatureManager;
            var selMgr = curDoc.SelectionManager as ISelectionMgr;

            // 清除选择
            curDoc.ClearSelection2(true);

            // 选择轮廓
            if(oInVo.ContourType == 0)
            {
                // 如果是草图轮廓，使用Mark=1选取面、边或曲线。对于扫描凸台特征，必须为闭合的草图轮廓。对于扫描曲面特征，草图轮廓是开放的或闭合的
                bool bSelContour = priSelectContourBySegmentName(oInVo.Contour.SketchName, oInVo.Contour.Name, 1);//"圆弧1"                                                                                                       //bool bSelContour = curDocExt.SelectByID2($"{oInVo.ContourName}@{oInVo.SketchName}", "EXTSKETCHSEGMENT", 0, 0, 0, true, 4, null, 0);
                if (!bSelContour)
                {
                    return RespVoLogExt.genError("选中扫描轮廓错误");
                }
            }

            // 选择路径
            bool bSelPath = priSelectContourBySegmentName(oInVo.Path.SketchName, oInVo.Path.Name, 1);//"圆弧1"                                                                                                       //bool bSelContour = curDocExt.SelectByID2($"{oInVo.ContourName}@{oInVo.SketchName}", "EXTSKETCHSEGMENT", 0, 0, 0, true, 4, null, 0);
            if (!bSelPath)
            {
                return RespVoLogExt.genError("选中扫描路径错误");
            }

            SweepFeatureData oSweepFeatureData = featMgr.CreateDefinition((int)swFeatureNameID_e.swFmSweep) as SweepFeatureData;
            if (oSweepFeatureData == null)
            {
                return RespVoLogExt.genError("创建扫描特征参数错误");
            }

            Feature oFeature = featMgr.CreateFeature(oSweepFeatureData);
            if (oFeature == null)
            {
                return RespVoLogExt.genError("创建扫描特征错误");
            }

            if (!string.IsNullOrEmpty(oInVo.FeatrueName))
            {
                oFeature.Name = oInVo.FeatrueName;
            }

            return RespVoLogExt.genOk($"创建扫描特征成功：{oFeature.Name}");
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
