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

namespace swapilib.bu.feature.vo.feature.loft
{
    [DisplayName("创建放样切除特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class FeatureLoftCutInVo
    {
        #region Fields

        /// <summary>
        /// 是否闭合
        /// </summary>
        [DisplayName("是否闭合")]
        [Description("true:闭合，false:不闭合。如果选取了true且选取的轮廓不少于三个，则任何选定的引导曲线都必须是闭合曲线。")]
        [Category("放样形状")]
        [PropertyOrder(1)]
        public bool Closed { get; set; } = false;

        /// <summary>
        /// 截面相切
        /// </summary>
        [DisplayName("截面相切")]
        [Description("true:保持与截面曲线相切，false:不保持。" +
            "如果截面曲线是相切的，则可以选择指定生成的面是否也是相切的；" +
            "生成切线曲面时，如果截面曲线具有这些特征，则将保持平面和圆柱面形状。")]
        [Category("放样形状")]
        [PropertyOrder(2)]
        public bool KeepTangency { get; set; } = true;

        /// <summary>
        /// 光滑表面
        /// </summary>
        [DisplayName("光滑表面")]
        [Description("true:获取更光滑的表面，false:没有")]
        [Category("放样形状")]
        [PropertyOrder(3)]
        public bool ForceNonRational { get; set; } = true;

        /// <summary>
        /// 中心线参数
        /// </summary>
        [DisplayName("中心线参数")]
        [Description("控制用于带中心线的放样的中间截面数量的因子。默认值为1.0，值越大，创建的中间部分越多。")]
        [Category("放样形状")]
        [PropertyOrder(4)]
        public double TessToleranceFactor { get; set; } = 0.01;

        /// <summary>
        /// 起始轮廓处的相切类型
        /// </summary>
        [DisplayName("起始轮廓处的相切类型")]
        [Description("起始轮廓处的相切类型，见swLoftStartEndMatchingType。")]
        [Category("起始和结束")]
        [PropertyOrder(5)]
        public swLoftStartEndMatchingType StartMatchingType { get; set; } = 0;

        /// <summary>
        /// 结束轮廓处的相切类型
        /// </summary>
        [DisplayName("结束轮廓处的相切类型")]
        [Description("结束轮廓处的相切类型，见swLoftStartEndMatchingType。")]
        [Category("起始和结束")]
        [PropertyOrder(6)]
        public swLoftStartEndMatchingType EndMatchingType { get; set; } = 0;

        /// <summary>
        /// 薄壁
        /// </summary>
        [DisplayName("薄壁")]
        [Description("true:勾选薄壁特征，false:不是薄壁")]
        [Category("薄壁")]
        [PropertyOrder(7)]
        public bool IsThinBody { get; set; } = false;

        /// <summary>
        /// 方向1的壁厚
        /// </summary>
        [DisplayName("方向1的壁厚")]
        [Description("方向1的壁厚 (如果ThinType为swThinWallType_e.swThinWallMidPlane, 则每个方向使用(ThinThickness1)/2)")]
        [Category("薄壁")]
        [PropertyOrder(8)]
        public double Thickness1 { get; set; } = 0;

        /// <summary>
        /// 方向2的壁厚
        /// </summary>
        [DisplayName("方向2的壁厚")]
        [Description("方向2的壁厚 (仅当ThinType为swThinWallType_e.swThinWallTwoDirection双向时才有效。)")]
        [Category("薄壁")]
        [PropertyOrder(9)]
        public double Thickness2 { get; set; } = 0;

        /// <summary>
        /// 薄壁类型
        /// </summary>
        [DisplayName("薄壁类型")]
        [Description("薄壁类型,见swThinWallType_ext。")]
        [Category("薄壁")]
        [PropertyOrder(10)]
        public swThinWallType_ext ThinType { get; set; } = 0;

        /// <summary>
        /// 影响实体范围
        /// </summary>
        [DisplayName("影响实体范围")]
        [Description("true:该特征仅影响选中的实体，false:该特征影响所有的实体。")]
        [Category("多实体")]
        [PropertyOrder(11)]
        public bool UseFeatScope { get; set; } = true;

        /// <summary>
        /// 自动选择实体
        /// </summary>
        [DisplayName("自动选择实体")]
        [Description("true:自动选择所有实体并让特征影响这些实体，false:选择特征影响的实体，该参数是针对合并结果而言的。")]
        [Category("多实体")]
        [PropertyOrder(12)]
        public bool UseAutoSelect { get; set; } = true;

        /// <summary>
        /// 特征名称
        /// </summary>
        [DisplayName("特征名称")]
        [Description("设置新生成的特征名称")]
        [Category("特征名称")]
        [PropertyOrder(13)]
        public string FeatrueName { get; set; } = "放样切除特征1";

        #endregion
    }
}
