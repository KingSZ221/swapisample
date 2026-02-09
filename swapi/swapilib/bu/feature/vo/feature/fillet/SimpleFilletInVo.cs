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

namespace swapilib.bu.feature.vo.feature.fillet
{
    [DisplayName("创建圆角特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class SimpleFilletInVo
    {
        #region Fields

        /// <summary>
        /// 圆角类型
        /// </summary>
        [DisplayName("圆角类型")]
        [Description("见swSimpleFilletType_ext")]
        [PropertyOrder(1)]
        public swSimpleFilletType_ext FilletType { get; set; } = 0;

        /// <summary>
        /// 圆角对称
        /// </summary>
        [DisplayName("圆角不对称")]
        [Description("true:圆角不对称，false:对称")]
        [PropertyOrder(2)]
        public bool AsymmetricFillet { get; set; } = false;

        /// <summary>
        /// 圆角半径
        /// </summary>
        [DisplayName("圆角半径")]
        [Description("第1圆角半径")]
        [PropertyOrder(3)]
        public double DefaultRadius { get; set; } = 20;

        /// <summary>
        /// 圆角距离
        /// </summary>
        [DisplayName("圆角距离")]
        [Description("圆角距离或第2个圆角半径")]
        [PropertyOrder(4)]
        public double DefaultDistance { get; set; } = 20;

        /// <summary>
        /// 横截面轮廓形状
        /// </summary>
        [DisplayName("横截面轮廓形状")]
        [Description("固定圆角可选:swFeatureFilletCircular/swFeatureFilletConicRho/swFeatureFilletConicRadius" +
            "面圆角可选：swFeatureFilletCircular/swFeatureFilletConicRho/swFeatureFilletConicRadius" +
            "完整圆角可选：swFeatureFilletCircular")]
        [PropertyOrder(5)]
        public swFeatureFilletProfileType_ext ConicTypeForCrossSectionProfile { get; set; } = 0;

        /// <summary>
        /// 拉伸特征名称
        /// </summary>
        [DisplayName("拉伸特征名称")]
        [Description("设置拉伸特征名称")]
        [Category("拉伸特征名称")]
        [PropertyOrder(6)]
        public string FeatrueName { get; set; } = "圆角特征1";

        #endregion
    }
}