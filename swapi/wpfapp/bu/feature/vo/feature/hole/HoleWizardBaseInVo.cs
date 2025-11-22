using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.feature.vo.feature.consts;
using wpfapp.bu.sketch.vo.entity;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace wpfapp.bu.feature.vo.feature.hole
{
    /// <summary>
    /// 异形孔向导
    /// </summary>
    public class HoleWizardBaseInVo
    {
        #region Fields

        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public virtual swWzdGeneralHoleTypes_ext getHoleType()
        {
            return swWzdGeneralHoleTypes_ext.swWzdCounterBore;
        }

        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public virtual string getHoleTypeName()
        {
            return "柱形沉头孔";
        }

        /// <summary>
        /// 标准
        /// </summary>
        [DisplayName("标准")]
        [Description("")]
        [Category("孔类型")]
        [PropertyOrder(1)]
        public int StandardIndex { get; set; } = 8;

        /// <summary>
        /// Fastener类型
        /// </summary>
        [DisplayName("Fastener类型")]
        [Description("")]
        [Category("孔类型")]
        [PropertyOrder(2)]
        public int FastenerTypeIndex { get; set; } = 139;

        /// <summary>
        /// 孔大小
        /// </summary>
        [DisplayName("大小")]
        [Description("")]
        [Category("孔规格")]
        [PropertyOrder(3)]
        public string SSize { get; set; } = "M6";

        /// <summary>
        /// 终止条件
        /// </summary>
        [DisplayName("终止条件")]
        [Description("")]
        [Category("孔规格")]
        [PropertyOrder(4)]
        public swEndConditions_ext EndType { get; set; } = swEndConditions_ext.swEndCondThroughAll;

        /// <summary>
        /// 孔或槽的直径
        /// </summary>
        [DisplayName("孔或槽的直径")]
        [Description("")]
        [Category("孔规格")]
        [PropertyOrder(5)]
        public double Diameter { get; set; } = 0;

        /// <summary>
        /// 孔或槽的深度
        /// </summary>
        [DisplayName("孔或槽的深度")]
        [Description("")]
        [Category("孔规格")]
        [PropertyOrder(6)]
        public double Depth { get; set; } = 0;

        /// <summary>
        /// 槽长
        /// </summary>
        [DisplayName("槽长")]
        [Description("")]
        [Category("孔规格")]
        [PropertyOrder(7)]
        public double Length { get; set; } = 0;

        #region Value1-Value12

        /// <summary>
        /// 获得第1到第12个Value值，由派生类实现
        /// </summary>
        /// <param name="i">值序号从1开始，到12</param>
        /// <returns></returns>
        public virtual double getValue(int i)
        {
            return -1;
        }

        #endregion

        /// <summary>
        /// 螺纹线等级
        /// </summary>
        [DisplayName("螺纹线等级")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(20)]
        public string ThreadClass { get; set; } = "";

        /// <summary>
        /// 反转方向
        /// </summary>
        [DisplayName("反转方向")]
        [Description("true:反转孔或槽的方向，false:不反转")]
        [Category("选项")]
        [PropertyOrder(21)]
        public bool RevDir { get; set; } = false;

        /// <summary>
        /// 影响实体范围
        /// </summary>
        [DisplayName("影响实体范围")]
        [Description("true:该特征仅影响选中的实体，false:该特征影响所有的实体。")]
        [Category("多实体")]
        [PropertyOrder(22)]
        public bool FeatureScope { get; set; } = true;

        /// <summary>
        /// 自动选择实体
        /// </summary>
        [DisplayName("自动选择实体")]
        [Description("true:自动选择所有实体并让特征影响这些实体，false:选择特征影响的实体。")]
        [Category("多实体")]
        [PropertyOrder(23)]
        public bool AutoSelect { get; set; } = true;

        /// <summary>
        /// 装配体影响实体范围
        /// </summary>
        [DisplayName("装配体影响实体范围")]
        [Description("true:装配体特征仅影响选定零部件，false:仅影响选定的零部件。在装配体中创建拉伸切除特征时才有效。")]
        [Category("多实体")]
        [PropertyOrder(24)]
        public bool AssemblyFeatureScope { get; set; } = true;

        /// <summary>
        /// 装配体自动选择实体
        /// </summary>
        [DisplayName("装配体自动选择实体")]
        [Description("true:自动选择所有受影响的零部件，false:选择特征影响的零部件。在装配体中创建拉伸切除特征时才有效。")]
        [Category("多实体")]
        [PropertyOrder(25)]
        public bool AutoSelectComponents { get; set; } = true;

        /// <summary>
        /// 传播特征到零件
        /// </summary>
        [DisplayName("传播特征到零件")]
        [Description("true:将装配体特征传播到它影响的零部件中，false:不传播。在装配体中创建拉伸切除特征时才有效。")]
        [Category("旋转结果")]
        [PropertyOrder(26)]
        public bool PropagateFeatureToParts { get; set; } = false;

        /// <summary>
        /// 特征名称
        /// </summary>
        [DisplayName("特征位置")]
        [Description("特征位置")]
        [Category("特征位置")]
        [PropertyOrder(27)]
        public List<SketchMathPointInfo> Positions { get; set; } = new List<SketchMathPointInfo>();

        /// <summary>
        /// 特征名称
        /// </summary>
        [DisplayName("特征名称")]
        [Description("特征名称")]
        [Category("特征名称")]
        [PropertyOrder(28)]
        public string FeatrueName { get; set; } = "异形孔1";

        #endregion
    }
}
