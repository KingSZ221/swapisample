using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.feature.vo.feature.extrusion
{
    [DisplayName("创建拉伸切除特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class FeatureExtrusionCutInVo
    {
        #region Fields

        /// <summary>
        /// 单向拉伸切除
        /// </summary>
        [DisplayName("单向拉伸切除")]
        [Description("true:单向拉伸切除，false:双向拉伸切除")]
        [Category("切除方向")]
        public bool Sd { get; set; } = true;

        /// <summary>
        /// 反向拉伸切除
        /// </summary>
        [DisplayName("反向拉伸切除")]
        [Description("true:反向拉伸切除，false:不反向")]
        [Category("切除方向")]
        public bool Flip { get; set; } = false;

        /// <summary>
        /// 反转默认方向
        /// </summary>
        [DisplayName("反转默认方向")]
        [Description("true:反转默认方向，false:不反转")]
        [Category("反转默认方向")]
        public bool Dir { get; set; } = false;

        /// <summary>
        /// 拉伸方向1结束条件类型
        /// </summary>
        [DisplayName("拉伸方向1结束条件类型")]
        [Description("枚举swEndConditions_e中定义的拉伸方向1的结束条件")]
        [Category("结束条件")]
        public int T1 { get; set; } = 0;

        /// <summary>
        /// 拉伸方向2结束条件类型
        /// </summary>
        [DisplayName("拉伸方向2结束条件类型")]
        [Description("枚举swEndConditions_e中定义的拉伸方向2的结束条件")]
        [Category("结束条件")]
        public int T2 { get; set; } = 0;

        /// <summary>
        /// 拉伸方向1切除深度
        /// </summary>
        [DisplayName("拉伸方向1切除深度")]
        [Description("如果拉伸方向1结束条件类型为swEndConditions_e.swEndCondOffsetFromSurface(到指定面指定的距离)时，则不是拉伸切除深度，而是偏移距离")]
        [Category("切除深度")]
        public double D1 { get; set; } = 100;

        /// <summary>
        /// 拉伸方向2切除深度
        /// </summary>
        [DisplayName("拉伸方向2切除深度")]
        [Description("如果拉伸方向2结束条件类型为swEndConditions_e.swEndCondOffsetFromSurface(到指定面指定的距离)时，则不是拉伸切除深度，而是偏移距离")]
        [Category("切除深度")]
        public double D2 { get; set; } = 0;

        /// <summary>
        /// 拉伸方向1拔模
        /// </summary>
        [DisplayName("拉伸方向1拔模")]
        [Description("true:拔模，false:不拔模")]
        [Category("拔模")]
        public bool Dchk1 { get; set; } = false;

        /// <summary>
        /// 拉伸方向2拔模
        /// </summary>
        [DisplayName("拉伸方向2拔模")]
        [Description("true:拔模，false:不拔模")]
        [Category("拔模")]
        public bool Dchk2 { get; set; } = false;

        /// <summary>
        /// 拉伸方向1拔模方向
        /// </summary>
        [DisplayName("拉伸方向1拔模方向")]
        [Description("true:向内拔模，false:向外拔模。仅当拉伸方向开启拔模时才有效")]
        [Category("拔模")]
        public bool Ddir1 { get; set; } = false;

        /// <summary>
        /// 拉伸方向2拔模方向
        /// </summary>
        [DisplayName("拉伸方向2拔模方向")]
        [Description("true:向内拔模，false:向外拔模。仅当拉伸方向开启拔模时才有效")]
        [Category("拔模")]
        public bool Ddir2 { get; set; } = false;

        /// <summary>
        /// 拉伸方向1拔模斜度
        /// </summary>
        [DisplayName("拉伸方向1拔模斜度")]
        [Description("表示拔模斜度，仅当拉伸方向开启拔模时才有效")]
        [Category("拔模")]
        public double Dang1 { get; set; } = 0;

        /// <summary>
        /// 拉伸方向2拔模斜度
        /// </summary>
        [DisplayName("拉伸方向2拔模斜度")]
        [Description("表示拔模斜度，仅当拉伸方向开启拔模时才有效")]
        [Category("拔模")]
        public double Dang2 { get; set; } = 0;

        /// <summary>
        /// 方向1反向偏移
        /// </summary>
        [DisplayName("方向1反向偏移")]
        [Description("true:勾选方向1反向等距，表示远离草图方向偏移，false:不勾选方向1反向等距，表示向草图方向偏移。仅当拉伸结束条件类型为swEndConditions_e.swEndCondOffsetFromSurface(到离指定面指定的距离)时才有效")]
        [Category("偏移")]
        public bool OffsetReverse1 { get; set; } = false;

        /// <summary>
        /// 方向2反向偏移
        /// </summary>
        [DisplayName("方向2反向偏移")]
        [Description("true:勾选方向2反向等距，表示远离草图方向偏移，false:不勾选方向2反向等距，表示向草图方向偏移。仅当拉伸结束条件类型为swEndConditions_e.swEndCondOffsetFromSurface(到离指定面指定的距离)时才有效")]
        [Category("偏移")]
        public bool OffsetReverse2 { get; set; } = false;

        /// <summary>
        /// 方向1转换曲面
        /// </summary>
        [DisplayName("方向1转换曲面")]
        [Description("true:勾选方向1转换曲面，false:不勾选方向1转换曲面。仅当拉伸结束条件类型为swEndConditions_e.swEndCondOffsetFromSurface(到离指定面指定的距离)时才有效")]
        [Category("旋转方向")]
        public bool TranslateSurface1 { get; set; } = false;

        /// <summary>
        /// 方向2转换曲面
        /// </summary>
        [DisplayName("方向2转换曲面")]
        [Description("true:勾选方向2转换曲面，false:不勾选方向2转换曲面。仅当拉伸结束条件类型为swEndConditions_e.swEndCondOffsetFromSurface(到离指定面指定的距离)时才有效")]
        [Category("旋转结束条件")]
        public bool TranslateSurface2 { get; set; } = false;

        /// <summary>
        /// 正交切除
        /// </summary>
        [DisplayName("正交切除")]
        [Description("true:创建垂直于钣金厚度的切除特征，false:表示不是。(仅对钣金零件有效，非钣金零件选择false)")]
        [Category("钣金")]
        public bool NormalCut { get; set; } = false;

        /// <summary>
        /// 优化几何图形
        /// </summary>
        [DisplayName("优化几何图形")]
        [Description("true:优化钣金零件中的正交切除，false:表示不是。(仅对钣金零件有效，非钣金零件选择false)")]
        [Category("钣金")]
        public bool OptimizeGeometry { get; set; } = false;

        /// <summary>
        /// 影响实体范围
        /// </summary>
        [DisplayName("影响实体范围")]
        [Description("true:该特征仅影响选中的实体，false:该特征影响所有的实体。")]
        [Category("多实体")]
        public bool UseFeatScope { get; set; } = false;

        /// <summary>
        /// 自动选择实体
        /// </summary>
        [DisplayName("自动选择实体")]
        [Description("true:自动选择所有实体并让特征影响这些实体，false:选择特征影响的实体。")]
        [Category("多实体")]
        public bool UseAutoSelect { get; set; } = false;

        /// <summary>
        /// 装配体影响实体范围
        /// </summary>
        [DisplayName("装配体影响实体范围")]
        [Description("true:装配体特征仅影响选定零部件，false:仅影响选定的零部件。在装配体中创建拉伸切除特征时才有效。")]
        [Category("多实体")]
        public bool AssemblyFeatureScope { get; set; } = false;

        /// <summary>
        /// 装配体自动选择实体
        /// </summary>
        [DisplayName("装配体自动选择实体")]
        [Description("true:自动选择所有受影响的零部件，false:选择特征影响的零部件。在装配体中创建拉伸切除特征时才有效。")]
        [Category("多实体")]
        public bool AutoSelectComponents { get; set; } = false;

        /// <summary>
        /// 传播特征到零件
        /// </summary>
        [DisplayName("传播特征到零件")]
        [Description("true:将装配体特征传播到它影响的零部件中，false:不传播。在装配体中创建拉伸切除特征时才有效。")]
        [Category("多实体")]
        public bool PropagateFeatureToParts { get; set; } = false;

        /// <summary>
        /// 拉伸开始类型
        /// </summary>
        [DisplayName("拉伸开始类型")]
        [Description("枚举swStartConditions_e中定义的拉伸切除开始类型")]
        [Category("拉伸开始类型")]
        public int T0 { get; set; } = 0;

        /// <summary>
        /// 拉伸切除偏移距离
        /// </summary>
        [DisplayName("拉伸切除偏移距离")]
        [Description("从草图平面开始拉伸切除偏移的距离。仅当拉伸开始类型为swStartConditions_e.swStartOffset(等距)时才有效。")]
        [Category("拉伸开始类型")]
        public double StartOffset { get; set; } = 100;

        /// <summary>
        /// 反转起始偏移方向
        /// </summary>
        [DisplayName("反转起始偏移方向")]
        [Description("true:反转起始偏移的方向，false:不反转。仅当拉伸开始类型为swStartConditions_e.swStartOffset(等距)时才有效。")]
        [Category("拉伸开始类型")]
        public bool FlipStartOffset { get; set; } = false;

        /// <summary>
        /// 待旋转草图名称
        /// </summary>
        [DisplayName("待旋转草图名称")]
        [Description("待旋转草图名称，使用Mark=0。")]
        [Category("待旋转草图")]
        public EntitySelectId RevolveSketch { get; set; } = new EntitySelectId();

        /// <summary>
        /// 旋转轴
        /// </summary>
        [DisplayName("旋转轴")]
        [Description("旋转轴，使用Mark=4或16。")]
        [Category("旋转轴")]
        public EntitySelectId RevolveAxis { get; set; } = new EntitySelectId();

        /// <summary>
        /// 成形到实体
        /// </summary>
        [DisplayName("成形到实体")]
        [Description("成型到的顶点，成型到的面，偏移到指定的面，使用Mark=32。")]
        [Category("成形到实体")]
        public EntitySelectId ToSelection { get; set; } = new EntitySelectId();

        /// <summary>
        /// 旋转基体名称
        /// </summary>
        [DisplayName("旋转基体名称")]
        [Description("设置旋转特征名称")]
        [Category("旋转基体名称")]
        public string FeatrueName { get; set; } = "旋转体1";

        #endregion
    }
}
