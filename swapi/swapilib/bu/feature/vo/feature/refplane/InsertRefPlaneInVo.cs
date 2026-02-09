using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace swapilib.bu.feature.vo.feature.refplane
{
    [DisplayName("创建基准面")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class InsertRefPlaneInVo
    {
        #region Fields

        /// <summary>
        /// 第一参考
        /// </summary>
        [DisplayName("第一参考")]
        [Description("见swRefPlaneReferenceConstraints_e。")]
        [PropertyOrder(1)]
        public int FirstConstraint { get; set; } = 8;

        /// <summary>
        /// 第一参考角度或距离
        /// </summary>
        [DisplayName("第一参考角度或距离")]
        [Description("")]
        [PropertyOrder(2)]
        public double FirstConstraintAngleOrDistance { get; set; } = 140;

        /// <summary>
        /// 第二参考
        /// </summary>
        [DisplayName("第二参考")]
        [Description("见swRefPlaneReferenceConstraints_e。")]
        [PropertyOrder(3)]
        public int SecondConstraint { get; set; } = 0;

        /// <summary>
        /// 第二参考角度或距离
        /// </summary>
        [DisplayName("第二参考角度或距离")]
        [Description("")]
        [PropertyOrder(4)]
        public double SecondConstraintAngleOrDistance { get; set; } = 0;

        /// <summary>
        /// 第三参考
        /// </summary>
        [DisplayName("第三参考")]
        [Description("见swRefPlaneReferenceConstraints_e。")]
        [PropertyOrder(5)]
        public int ThirdConstraint { get; set; } = 0;

        /// <summary>
        /// 第三参考角度或距离
        /// </summary>
        [DisplayName("第三参考角度或距离")]
        [Description("")]
        [PropertyOrder(6)]
        public double ThirdConstraintAngleOrDistance { get; set; } = 0;

        /// <summary>
        /// 参考面名称
        /// </summary>
        [DisplayName("参考面名称")]
        [Description("")]
        [PropertyOrder(7)]
        public string RefPlaneName { get; set; } = "";

        #endregion
    }
}
