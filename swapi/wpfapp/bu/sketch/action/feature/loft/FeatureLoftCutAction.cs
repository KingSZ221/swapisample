using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.feature.loft;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.feature.loft
{
    /// <summary>
    /// 创建放样切除特征
    /// </summary>
    public class FeatureLoftCutAction : SwSketchFeatureActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FeatureLoftCutAction(object oInVo) : base(oInVo)
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

            // 清除选择
            curDoc.ClearSelection2(true);

            // 选择轮廓，标记Mark=1
            bool bSelContour = priSelectContourBySegmentName(oInVo.Contour1.SketchName, oInVo.Contour1.Name, 1);//"圆弧1"                                                                                                       //bool bSelContour = curDocExt.SelectByID2($"{oInVo.ContourName}@{oInVo.SketchName}", "EXTSKETCHSEGMENT", 0, 0, 0, true, 4, null, 0);
            if (!bSelContour)
            {
                return RespVoLogExt.genError($"选中轮廓1错误,草图 {oInVo.Contour1.SketchName}, 轮廓 {oInVo.Contour1.Name}");
            }

            bSelContour = priSelectContourBySegmentName(oInVo.Contour2.SketchName, oInVo.Contour2.Name, 1);//"圆弧1"                                                                                                       //bool bSelContour = curDocExt.SelectByID2($"{oInVo.ContourName}@{oInVo.SketchName}", "EXTSKETCHSEGMENT", 0, 0, 0, true, 4, null, 0);
            if (!bSelContour)
            {
                return RespVoLogExt.genError($"选中轮廓2错误,草图 {oInVo.Contour2.SketchName}, 轮廓 {oInVo.Contour2.Name}");
            }

            Feature oFeature = featMgr.InsertCutBlend(
                // 放样形状
                Closed: oInVo.Closed,//是否闭合
                KeepTangency: oInVo.KeepTangency,//截面相切
                ForceNonRational: oInVo.ForceNonRational,//光滑表面
                TessToleranceFactor: oInVo.TessToleranceFactor,//中心线参数
                                                               // 起始和结束
                StartMatchingType: oInVo.StartMatchingType,//起始轮廓处的相切类型
                EndMatchingType: oInVo.EndMatchingType,//结束轮廓处的相切类型
                // 薄壁
                IsThinBody: oInVo.IsThinBody,//薄壁
                Thickness1: oInVo.Thickness1,//方向1的壁厚
                Thickness2: oInVo.Thickness2,//方向2的壁厚
                ThinType: oInVo.ThinType,//薄壁类型
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
