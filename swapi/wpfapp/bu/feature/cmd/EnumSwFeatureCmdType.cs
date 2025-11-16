using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.cmd.cmdtype;
using wpfapp.bu.feature.action.feature.extrusion;
using wpfapp.bu.feature.action.feature.loft;
using wpfapp.bu.feature.action.feature.revolve;
using wpfapp.bu.feature.action.feature.sweep;
using wpfapp.bu.feature.vo.feature.extrusion;
using wpfapp.bu.feature.vo.feature.loft;
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

        [SwCmdType("创建拉伸基体特征", "拉伸基体", typeof(FeatureExtrusionThinInVo), typeof(FeatureExtrusionAction))]
        [Description("创建拉伸基体特征")]
        FeatureExtrusion,

        [SwCmdType("创建拉伸薄壁特征", "拉伸薄壁", typeof(FeatureExtrusionThinInVo), typeof(FeatureExtrusionThinAction))]
        [Description("创建拉伸基体特征")]
        FeatureExtrusionThin,

        [SwCmdType("创建旋转基体/凸台特征", "旋转基体", typeof(FeatureRevolveInVo), typeof(FeatureRevolveAction))]
        [Description("基于选择的草图创建旋转基体、凸台或切除特征")]
        FeatureRevolve,

        [SwCmdType("创建扫描基体/凸台特征", "创建扫描基体/凸台", typeof(FeatureSweepInVo), typeof(FeatureSweepAction))]
        [Description("基于选择的草图、路径创建扫描基体/凸台特征")]
        FeatureSweep,

        [SwCmdType("创建放样特征", "放样特征", typeof(FeatureLoftInVo), typeof(FeatureLoftAction))]
        [Description("基于选择的草图、中心线、引导线创放样特征")]
        FeatureLoft,

        [SwCmdType("拉伸切除", "拉伸切除", typeof(FeatureExtrusionCutInVo), typeof(FeatureExtrusionCutAction))]
        FeatureExtrusionCut,

        [SwCmdType("旋转切除", "旋转切除", typeof(FeatureExtrusionCutInVo), typeof(FeatureExtrusionCutAction))]
        FeatureRevolveCut,

        [SwCmdType("扫描切除", "扫描切除", typeof(FeatureSweepCutInVo), typeof(FeatureSweepCutAction))]
        FeatureSweepCut,

        [SwCmdType("放样切除", "放样切除", typeof(FeatureLoftCutInVo), typeof(FeatureLoftCutAction))]
        FeatureLoftCut
    }
}
