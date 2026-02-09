using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.feature.vo.feature.consts
{
    /// <summary>
    /// 参考面引用约束类型
    /// </summary>
    [Description("参考面引用约束类型")]
    public enum swRefPlaneReferenceConstraints_ext
    {
        [Description("None")]
        swRefPlaneReferenceConstraint_None = 0,

        [Description("Parallel")]
        swRefPlaneReferenceConstraint_Parallel = 1,

        [Description("Perpendicular")]
        swRefPlaneReferenceConstraint_Perpendicular = 2,

        [Description("Coincident")]
        swRefPlaneReferenceConstraint_Coincident = 4,

        [Description("Distance")]
        swRefPlaneReferenceConstraint_Distance = 8,

        [Description("Angle")]
        swRefPlaneReferenceConstraint_Angle = 16,

        [Description("Tangent")]
        swRefPlaneReferenceConstraint_Tangent = 32,

        [Description("Project")]
        swRefPlaneReferenceConstraint_Project = 64,

        [Description("MidPlane")]
        swRefPlaneReferenceConstraint_MidPlane = 128,

        [Description("OptionFlip")]
        swRefPlaneReferenceConstraint_OptionFlip = 256,

        [Description("OptionOriginOnCurve")]
        swRefPlaneReferenceConstraint_OptionOriginOnCurve = 512,

        [Description("OptionProjectToNearestLocation")]
        swRefPlaneReferenceConstraint_OptionProjectToNearestLocation = 1024,

        [Description("OptionProjectAlongSketchNormal")]
        swRefPlaneReferenceConstraint_OptionProjectAlongSketchNormal = 2056,

        [Description("ParallelToScreen")]
        swRefPlaneReferenceConstraint_ParallelToScreen = 4096,

        [Description("OptionReferenceFlip")]
        swRefPlaneReferenceConstraint_OptionReferenceFlip = 8192
    }
}
