using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.feature.vo.feature.consts;
using swapilib.bu.sketch.vo.entity;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace swapilib.bu.feature.vo.feature.pattern
{
    [DisplayName("创建圆周阵列特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class CreateCircularPatternFeatureInVo
    {
        #region Fields

        /// <summary>
        /// 方向1等间距
        /// </summary>
        [DisplayName("方向1等间距")]
        [Description("true:等间距，false:实例间距")]
        [PropertyOrder(1)]
        public bool EqualSpacing { get; set; } = true;

        /// <summary>
        /// 方向1阵列反向
        /// </summary>
        [DisplayName("方向1阵列反向")]
        [Description("true:反向，false:不反向")]
        [PropertyOrder(2)]
        public bool ReverseDirection { get; set; } = false;

        /// <summary>
        /// 方向1阵列间距角度
        /// </summary>
        [DisplayName("方向1阵列间距角度")]
        [Description("方向1阵列间距角度")]
        [PropertyOrder(3)]
        public double Spacing { get; set; } = 15;

        /// <summary>
        /// 方向1阵列实例数量
        /// </summary>
        [DisplayName("方向1阵列实例数量")]
        [Description("方向1阵列实例数量")]
        [PropertyOrder(4)]
        public int TotalInstances { get; set; } = 1;

        /// <summary>
        /// 方向2等间距
        /// </summary>
        [DisplayName("方向2等间距")]
        [Description("true:等间距，false:实例间距")]
        [PropertyOrder(5)]
        public bool EqualSpacing2 { get; set; } = true;

        /// <summary>
        /// 方向2阵列间距
        /// </summary>
        [DisplayName("方向2阵列间距")]
        [Description("方向2阵列间距")]
        [PropertyOrder(6)]
        public double Spacing2 { get; set; } = 15;

        /// <summary>
        /// 方向2阵列实例数量
        /// </summary>
        [DisplayName("方向2阵列实例数量")]
        [Description("方向2阵列实例数量")]
        [PropertyOrder(7)]
        public int TotalInstances2 { get; set; } = 1;

        /// <summary>
        /// 方向2
        /// </summary>
        [DisplayName("方向2")]
        [Description("true:阵列，false:不阵列")]
        [PropertyOrder(8)]
        public bool Direction2 { get; set; } = false;

        /// <summary>
        /// 几何体阵列
        /// </summary>
        [DisplayName("几何体阵列")]
        [Description("true:几何体阵列，false:反之")]
        [PropertyOrder(9)]
        public bool GeometryPattern { get; set; } = false;

        /// <summary>
        /// 变化草图
        /// </summary>
        [DisplayName("变化草图")]
        [Description("true:变化草图，false:反之")]
        [PropertyOrder(10)]
        public bool VarySketch { get; set; } = false;

        /// <summary>
        /// 阵列特征名称
        /// </summary>
        [DisplayName("阵列特征名称")]
        [Description("设置阵列特征名称")]
        [Category("阵列特征名称")]
        [PropertyOrder(11)]
        public string FeatrueName { get; set; } = "圆周阵列特征1";

        #endregion
    }

}
