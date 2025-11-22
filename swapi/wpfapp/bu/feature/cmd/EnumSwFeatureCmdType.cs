using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.cmd.cmdtype;
using wpfapp.bu.feature.action.feature.curve;
using wpfapp.bu.feature.action.feature.extrusion;
using wpfapp.bu.feature.action.feature.loft;
using wpfapp.bu.feature.action.feature.refplane;
using wpfapp.bu.feature.action.feature.revolve;
using wpfapp.bu.feature.action.feature.sweep;
using wpfapp.bu.feature.vo.feature.curve;
using wpfapp.bu.feature.vo.feature.extrusion;
using wpfapp.bu.feature.vo.feature.hole;
using wpfapp.bu.feature.vo.feature.loft;
using wpfapp.bu.feature.vo.feature.refplane;
using wpfapp.bu.feature.vo.feature.revolve;
using wpfapp.bu.feature.vo.feature.sweep;

namespace wpfapp.bu.feature.cmd
{
    /// <summary>
    /// 特征命令类型
    /// </summary>
    public enum EnumSwFeatureCmdType
    {
        [SwCmdType("None", "None", typeof(Object), typeof(Object))]
        None = 0,

        [SwCmdType("拉伸基体", "拉伸基体", typeof(FeatureExtrusionInVo), typeof(FeatureExtrusionAction))]
        [Description("创建拉伸基体特征")]
        FeatureExtrusion = 1,

        [SwCmdType("拉伸薄壁", "拉伸薄壁", typeof(FeatureExtrusionThinInVo), typeof(FeatureExtrusionThinAction))]
        [Description("创建拉伸薄壁特征")]
        FeatureExtrusionThin = 2,

        [SwCmdType("旋转基体", "旋转基体", typeof(FeatureRevolveInVo), typeof(FeatureRevolveAction))]
        [Description("基于选择的草图创建旋转基体、凸台或切除特征")]
        FeatureRevolve = 3,

        [SwCmdType("扫描特征", "创建扫描基体/凸台", typeof(FeatureSweepInVo), typeof(FeatureSweepAction))]
        [Description("基于选择的草图、路径创建扫描基体/凸台特征")]
        FeatureSweep = 4,

        [SwCmdType("放样特征", "放样特征", typeof(FeatureLoftInVo), typeof(FeatureLoftAction))]
        [Description("基于选择的草图、中心线、引导线创放样特征")]
        FeatureLoft = 5,

        [SwCmdType("边界特征", "边界特征", typeof(FeatureLoftInVo), typeof(FeatureLoftAction))]
        [Description("创建边界特征")]
        FeatureBianJie = 6,

        [SwCmdType("拉伸切除", "拉伸切除", typeof(FeatureExtrusionCutInVo), typeof(FeatureExtrusionCutAction))]
        [Description("拉伸切除")]
        FeatureExtrusionCut = 7,

        [SwCmdType("旋转切除", "旋转切除", typeof(FeatureRevolveCutInVo), typeof(FeatureRevolveCutAction))]
        [Description("旋转切除")]
        FeatureRevolveCut = 8,

        [SwCmdType("扫描切除", "扫描切除", typeof(FeatureSweepCutInVo), typeof(FeatureSweepCutAction))]
        [Description("扫描切除")]
        FeatureSweepCut = 9,

        [SwCmdType("放样切除", "放样切除", typeof(FeatureLoftCutInVo), typeof(FeatureLoftCutAction))]
        [Description("放样切除")]
        FeatureLoftCut = 10,

        [SwCmdType("边界切除", "边界切除", typeof(FeatureLoftInVo), typeof(FeatureLoftAction))]
        [Description("创建边界切除特征")]
        FeatureBianJieCut = 11,

        [SwCmdType("创建基准面", "创建基准面", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建基准面")]
        InsertRefPlane = 12,

        [SwCmdType("创建基准轴", "创建基准轴", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建基准轴")]
        InsertRef1 = 13,

        [SwCmdType("创建坐标系", "创建坐标系", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建坐标系")]
        InsertRef2 = 14,

        [SwCmdType("创建点", "创建点", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建点")]
        InsertRef3 = 15,

        [SwCmdType("创建质心", "创建质心", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建质心")]
        InsertRef4 = 16,

        [SwCmdType("创建边界框", "创建边界框", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建边界框")]
        InsertRef5 = 17,

        [SwCmdType("创建配合参考", "创建配合参考", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建配合参考")]
        InsertRef6 = 18,

        [SwCmdType("创建3D样条曲线", "创建3D样条曲线", typeof(Insert3DSplineCurveInVo), typeof(Insert3DSplineCurveAction))]
        [Description("创建3D样条曲线")]
        Insert3DSplineCurve = 19,

        [SwCmdType("创建柱形沉头孔", "创建创建柱形沉头孔", typeof(WzdCounterBoreInVo), typeof(HoleWizardAction))]
        [Description("创建创建柱形沉头孔")]
        WzdCounterBore = 20,

        [SwCmdType("创建锥形沉头孔", "创建锥形沉头孔", typeof(WzdCounterSinkInVo), typeof(HoleWizardAction))]
        [Description("创建锥形沉头孔")]
        WzdCounterSink = 21,

        [SwCmdType("创建常规孔", "创建常规孔", typeof(WzdHoleInVo), typeof(HoleWizardAction))]
        [Description("创建常规孔")]
        WzdHole = 22,

        [SwCmdType("创建锥形螺纹孔", "创建锥形螺纹孔", typeof(WzdPipeTapInVo), typeof(HoleWizardAction))]
        [Description("创建锥形螺纹孔")]
        WzdPipeTap = 23,

        [SwCmdType("创建直螺纹孔", "创建直螺纹孔", typeof(WzdTapInVo), typeof(HoleWizardAction))]
        [Description("创建直螺纹孔")]
        WzdTap = 24,

        HoleWizard
    }
}
