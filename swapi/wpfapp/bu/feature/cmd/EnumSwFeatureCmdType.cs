using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.cmd.cmdtype;
using wpfapp.bu.feature.action.feature.curve;
using wpfapp.bu.feature.action.feature.extrusion;
using wpfapp.bu.feature.action.feature.fillet;
using wpfapp.bu.feature.action.feature.loft;
using wpfapp.bu.feature.action.feature.refplane;
using wpfapp.bu.feature.action.feature.revolve;
using wpfapp.bu.feature.action.feature.select;
using wpfapp.bu.feature.action.feature.sweep;
using wpfapp.bu.feature.vo.feature.curve;
using wpfapp.bu.feature.vo.feature.extrusion;
using wpfapp.bu.feature.vo.feature.fillet;
using wpfapp.bu.feature.vo.feature.hole;
using wpfapp.bu.feature.vo.feature.loft;
using wpfapp.bu.feature.vo.feature.refplane;
using wpfapp.bu.feature.vo.feature.revolve;
using wpfapp.bu.feature.vo.feature.select;
using wpfapp.bu.feature.vo.feature.sweep;

namespace wpfapp.bu.feature.cmd
{
    /// <summary>
    /// 特征命令类型
    /// </summary>
    public enum EnumSwFeatureCmdType
    {
        [SwCmdType("None", "None", "拉伸", typeof(Object), typeof(Object))]
        None = 0,

        [SwCmdType("选中指定序号特征", "选中特征", "选择", typeof(SelectFeatureByPositionReverseInVo), typeof(SelectFeatureByPositionReverseAction))]
        [Description("选中指定序号特征")]
        SelectFeatureByPositionReverse,

        [SwCmdType("拉伸基体", "拉伸基体", "拉伸", typeof(FeatureExtrusionInVo), typeof(FeatureExtrusionAction))]
        [Description("创建拉伸基体特征")]
        FeatureExtrusion,

        [SwCmdType("拉伸薄壁", "拉伸薄壁", "拉伸", typeof(FeatureExtrusionThinInVo), typeof(FeatureExtrusionThinAction))]
        [Description("创建拉伸薄壁特征")]
        FeatureExtrusionThin,

        [SwCmdType("旋转基体", "旋转基体", "旋转", typeof(FeatureRevolveInVo), typeof(FeatureRevolveAction))]
        [Description("基于选择的草图创建旋转基体、凸台或切除特征")]
        FeatureRevolve,

        [SwCmdType("扫描特征", "创建扫描基体/凸台", "扫描", typeof(FeatureSweepInVo), typeof(FeatureSweepAction))]
        [Description("基于选择的草图、路径创建扫描基体/凸台特征")]
        FeatureSweep,

        [SwCmdType("放样特征", "放样特征", "放样", typeof(FeatureLoftInVo), typeof(FeatureLoftAction))]
        [Description("基于选择的草图、中心线、引导线创放样特征")]
        FeatureLoft,

        [SwCmdType("边界特征", "边界特征", "边界", typeof(FeatureLoftInVo), typeof(FeatureLoftAction))]
        [Description("创建边界特征")]
        FeatureBianJie,

        [SwCmdType("拉伸切除", "拉伸切除", "拉伸", typeof(FeatureExtrusionCutInVo), typeof(FeatureExtrusionCutAction))]
        [Description("拉伸切除")]
        FeatureExtrusionCut,

        [SwCmdType("旋转切除", "旋转切除", "旋转", typeof(FeatureRevolveCutInVo), typeof(FeatureRevolveCutAction))]
        [Description("旋转切除")]
        FeatureRevolveCut,

        [SwCmdType("扫描切除", "扫描切除", "扫描", typeof(FeatureSweepCutInVo), typeof(FeatureSweepCutAction))]
        [Description("扫描切除")]
        FeatureSweepCut,

        [SwCmdType("放样切除", "放样切除", "放样", typeof(FeatureLoftCutInVo), typeof(FeatureLoftCutAction))]
        [Description("放样切除")]
        FeatureLoftCut,

        [SwCmdType("边界切除", "边界切除", "边界", typeof(FeatureLoftInVo), typeof(FeatureLoftAction))]
        [Description("创建边界切除特征")]
        FeatureBianJieCut,

        [SwCmdType("创建基准面", "创建基准面", "参考几何体", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建基准面")]
        InsertRefPlane,

        [SwCmdType("创建基准轴", "创建基准轴", "参考几何体", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建基准轴")]
        InsertRef1,

        [SwCmdType("创建坐标系", "创建坐标系", "参考几何体", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建坐标系")]
        InsertRef2,

        [SwCmdType("创建点", "创建点", "参考几何体", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建点")]
        InsertRef3,

        [SwCmdType("创建质心", "创建质心", "参考几何体", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建质心")]
        InsertRef4,

        [SwCmdType("创建边界框", "创建边界框", "参考几何体", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建边界框")]
        InsertRef5,

        [SwCmdType("创建配合参考", "创建配合参考", "参考几何体", typeof(InsertRefPlaneInVo), typeof(InsertRefPlaneAction))]
        [Description("创建配合参考")]
        InsertRef6,

        [SwCmdType("创建3D样条曲线", "创建3D样条曲线", "曲线", typeof(Insert3DSplineCurveInVo), typeof(Insert3DSplineCurveAction))]
        [Description("创建3D样条曲线")]
        Insert3DSplineCurve,

        [SwCmdType("创建柱形沉头孔", "创建创建柱形沉头孔", "异形孔", typeof(WzdCounterBoreInVo), typeof(HoleWizardAction))]
        [Description("创建创建柱形沉头孔")]
        WzdCounterBore,

        [SwCmdType("创建锥形沉头孔", "创建锥形沉头孔", "异形孔", typeof(WzdCounterSinkInVo), typeof(HoleWizardAction))]
        [Description("创建锥形沉头孔")]
        WzdCounterSink,

        [SwCmdType("创建常规孔", "创建常规孔", "异形孔", typeof(WzdHoleInVo), typeof(HoleWizardAction))]
        [Description("创建常规孔")]
        WzdHole,

        [SwCmdType("创建锥形螺纹孔", "创建锥形螺纹孔", "异形孔", typeof(WzdPipeTapInVo), typeof(HoleWizardAction))]
        [Description("创建锥形螺纹孔")]
        WzdPipeTap,

        [SwCmdType("创建直螺纹孔", "创建直螺纹孔", "异形孔", typeof(WzdTapInVo), typeof(HoleWizardAction))]
        [Description("创建直螺纹孔")]
        WzdTap,

        [SwCmdType("创建圆角", "创建圆角", "圆角", typeof(SimpleFilletInVo), typeof(SimpleFilletAction))]
        [Description("创建圆角")]
        SimpleFillet,

        [SwCmdType("创建倒角", "创建倒角", "圆角", typeof(InsertFeatureChamferInVo), typeof(InsertFeatureChamferAction))]
        [Description("创建圆角")]
        InsertFeatureChamfer
    }
}
