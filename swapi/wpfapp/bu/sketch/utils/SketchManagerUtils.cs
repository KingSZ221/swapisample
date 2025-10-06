using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.utils
{
    /// <summary>
    /// 草图管理工具
    /// </summary>
    public class SketchManagerUtils
    {

        /// <summary>
        /// 通过草图对象获取特征对象
        /// </summary>
        /// <param name="swDoc">零件文档</param>
        /// <param name="sketch">草图对象</param>
        /// <returns>特征对象</returns>
        public static Feature getFeatureBySketch(ModelDoc2 swDoc, Sketch sketch)
        {
            if (swDoc != null && sketch != null)
            {
                FeatureManager featureMgr = swDoc.FeatureManager;
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
                            if (oSketch != null)
                            {
                                //Console.WriteLine($" {feature.Name} {feature.GetTypeName2()}");
                                if (oSketch == sketch)
                                {
                                    //Console.WriteLine($" ActiveSketch {feature.Name} {feature.GetTypeName2()}");
                                    return feature;
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
