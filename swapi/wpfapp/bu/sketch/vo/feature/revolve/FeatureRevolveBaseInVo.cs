using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.sketch.vo.feature.revolve
{
    public class FeatureRevolveBaseInVo
    {
        #region Fields

        /// <summary>
        /// 单向旋转
        /// </summary>
        [DisplayName("单向旋转")]
        [Description("true:单向旋转，false:双向旋转")]
        [Category("旋转结果")]
        public bool SingleDir { get; set; } = true;

        /// <summary>
        /// 实心
        /// </summary>
        [DisplayName("实心")]
        [Description("true:实心的旋转特征，false:不是实心")]
        [Category("旋转结果")]
        public bool IsSolid { get; set; } = false;

        /// <summary>
        /// 薄壁
        /// </summary>
        [DisplayName("薄壁")]
        [Description("true:薄壁的旋转特征，false:不是薄壁")]
        [Category("旋转结果")]
        public bool IsThin { get; set; } = false;

        ///// <summary>
        ///// 切除
        ///// </summary>
        //[DisplayName("切除")]
        //[Description("true:旋转切除，false:不是切除")]
        //[Category("旋转结果")]
        //public bool IsCut { get; set; } = false;

        /// <summary>
        /// 反转旋转
        /// </summary>
        [DisplayName("反转旋转")]
        [Description("true:反转旋转角度，false:不反转。仅当Dir1Type的结束条件不是swEndConditions_e.swEndCondMidPlane(两侧对称)时才生效")]
        [Category("旋转方向")]
        public bool ReverseDir { get; set; } = false;

        /// <summary>
        /// 切除
        /// </summary>
        [DisplayName("切除")]
        [Description("true:旋转在两个方向上都成形到同一个实体，false:反之。仅当SingleDir为false且Dir1Type和Dir2Type的结束条件为swEndConditions_e.swEndCondUpToVertex(成型到一顶点), swEndConditions_e.swEndCondUpToSurface(成型到一面), 或 swEndConditions_e.swEndCondOffsetFromSurface(到离指定面指定的距离))时才有效")]
        [Category("旋转方向")]
        public bool BothDirectionUpToSameEntity { get; set; } = false;

        /// <summary>
        /// 旋转方向1结束条件类型
        /// </summary>
        [DisplayName("旋转方向1结束条件类型")]
        [Description("枚举swEndConditions_e中定义的旋转方向1的结束条件")]
        [Category("旋转结束条件")]
        public int Dir1Type { get; set; } = 0;

        /// <summary>
        /// 旋转方向2结束条件类型
        /// </summary>
        [DisplayName("旋转方向2结束条件类型")]
        [Description("枚举swEndConditions_e中定义的旋转方向2的结束条件")]
        [Category("旋转结束条件")]
        public int Dir2Type { get; set; } = 0;

        /// <summary>
        /// 方向1的旋转角度
        /// </summary>
        [DisplayName("方向1的旋转角度")]
        [Description("仅当旋转方向1结束条件类型为swEndConditions_e.swEndCondBlind(给定深度)时有效")]
        [Category("旋转结束条件")]
        public double Dir1Angle { get; set; } = 360;

        /// <summary>
        /// 方向2的旋转角度
        /// </summary>
        [DisplayName("方向2的旋转角度")]
        [Description("仅当旋转方向2结束条件类型为swEndConditions_e.swEndCondBlind(给定深度)时有效")]
        [Category("旋转结束条件")]
        public double Dir2Angle { get; set; } = 0;

        /// <summary>
        /// 方向1反向偏移
        /// </summary>
        [DisplayName("方向1反向偏移")]
        [Description("true:勾选方向1反向等距，表示远离草图方向偏移，false:不勾选方向1反向等距，表示向草图方向偏移。")]
        [Category("偏移")]
        public bool OffsetReverse1 { get; set; } = false;

        /// <summary>
        /// 方向2反向偏移
        /// </summary>
        [DisplayName("方向2反向偏移")]
        [Description("true:勾选方向2反向等距，表示远离草图方向偏移，false:不勾选方向2反向等距，表示向草图方向偏移。")]
        [Category("偏移")]
        public bool OffsetReverse2 { get; set; } = false;

        /// <summary>
        /// 偏移距离1
        /// </summary>
        [DisplayName("方向1的偏移距离")]
        [Description("方向1的偏移距离; 仅当Dir1Type为swEndConditions_e.swEndCondOffsetFromSurface(到离指定面指定的距离))时才有效。")]
        [Category("偏移")]
        public double OffsetDistance1 { get; set; } = 10;

        /// <summary>
        /// 偏移距离2
        /// </summary>
        [DisplayName("方向2的偏移距离")]
        [Description("方向2的偏移距离; 仅当Dir1Type为swEndConditions_e.swEndCondOffsetFromSurface(到离指定面指定的距离))时才有效。")]
        [Category("偏移")]
        public double OffsetDistance2 { get; set; } = 10;

        /// <summary>
        /// 薄壁类型
        /// </summary>
        [DisplayName("薄壁类型")]
        [Description("由枚举swThinWallType_e定义薄壁的类型和方向，单向时可取单向反向swThinWallOppDirection。")]
        [Category("薄壁类型")]
        public int ThinType { get; set; } = 3;

        /// <summary>
        /// 方向1的壁厚
        /// </summary>
        [DisplayName("方向1的壁厚")]
        [Description("方向1的壁厚 (如果ThinType为swThinWallType_e.swThinWallMidPlane, 则每个方向使用(ThinThickness1)/2)")]
        [Category("薄壁类型")]
        public double ThinThickness1 { get; set; } = 2;

        /// <summary>
        /// 方向2的壁厚
        /// </summary>
        [DisplayName("方向2的壁厚")]
        [Description("方向2的壁厚 (仅当ThinType为swThinWallType_e.swThinWallTwoDirection双向时才有效。)")]
        [Category("薄壁类型")]
        public double ThinThickness2 { get; set; } = 2;

        /// <summary>
        /// 合并实体
        /// </summary>
        [DisplayName("合并实体")]
        [Description("true:表示将结果合并到多实体零件中，false:不合并。")]
        [Category("多实体")]
        public bool Merge { get; set; } = false;

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
        [Description("true:自动选择所有实体并让特征影响这些实体，false:选择特征影响的实体，该参数是针对合并结果而言的。")]
        [Category("多实体")]
        public bool UseAutoSelect { get; set; } = false;

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
