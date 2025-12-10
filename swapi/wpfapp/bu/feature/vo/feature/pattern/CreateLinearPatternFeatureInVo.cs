using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.feature.vo.feature.consts;
using wpfapp.bu.sketch.vo.entity;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace wpfapp.bu.feature.vo.feature.pattern
{
    [DisplayName("创建线性阵列特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class CreateLinearPatternFeatureInVo
    {
        #region Fields

        /// <summary>
        /// 方向1阵列终止条件
        /// </summary>
        [DisplayName("方向1阵列终止条件")]
        [Description("见swPatternEndCondition_e")]
        [PropertyOrder(1)]
        public swPatternEndCondition_ext D1EndCondition { get; set; } = 0;

        /// <summary>
        /// 方向1阵列反向
        /// </summary>
        [DisplayName("方向1阵列反向")]
        [Description("true:反向，false:不反向")]
        [PropertyOrder(2)]
        public bool D1ReverseDirection { get; set; } = false;

        /// <summary>
        /// 方向1阵列间距
        /// </summary>
        [DisplayName("方向1阵列间距")]
        [Description("方向1阵列间距")]
        [PropertyOrder(3)]
        public double D1Spacing { get; set; } = 10;

        /// <summary>
        /// 方向1阵列实例数量
        /// </summary>
        [DisplayName("方向1阵列实例数量")]
        [Description("方向1阵列实例数量")]
        [PropertyOrder(4)]
        public int D1TotalInstances { get; set; } = 1;

        /// <summary>
        /// 方向2阵列终止条件
        /// </summary>
        [DisplayName("方向2阵列终止条件")]
        [Description("见swPatternEndCondition_e")]
        [PropertyOrder(5)]
        public swPatternEndCondition_ext D2EndCondition { get; set; } = 0;

        /// <summary>
        /// 方向2阵列反向
        /// </summary>
        [DisplayName("方向2阵列反向")]
        [Description("true:反向，false:不反向")]
        [PropertyOrder(6)]
        public bool D2ReverseDirection { get; set; } = false;

        /// <summary>
        /// 方向2阵列间距
        /// </summary>
        [DisplayName("方向2阵列间距")]
        [Description("方向2阵列间距")]
        [PropertyOrder(7)]
        public double D2Spacing { get; set; } = 10;

        /// <summary>
        /// 方向2阵列实例数量
        /// </summary>
        [DisplayName("方向2阵列实例数量")]
        [Description("方向2阵列实例数量")]
        [PropertyOrder(8)]
        public int D2TotalInstances { get; set; } = 1;

        /// <summary>
        /// 方向2只阵列源
        /// </summary>
        [DisplayName("方向2只阵列源")]
        [Description("true:只阵列源，false:反之")]
        [PropertyOrder(9)]
        public bool D2PatternSeedOnly { get; set; } = false;

        /// <summary>
        /// 几何体阵列
        /// </summary>
        [DisplayName("几何体阵列")]
        [Description("true:几何体阵列，false:反之")]
        [PropertyOrder(10)]
        public bool GeometryPattern { get; set; } = false;

        /// <summary>
        /// 变化草图
        /// </summary>
        [DisplayName("变化草图")]
        [Description("true:变化草图，false:反之")]
        [PropertyOrder(11)]
        public bool VarySketch { get; set; } = false;

        /// <summary>
        /// 阵列特征名称
        /// </summary>
        [DisplayName("阵列特征名称")]
        [Description("设置阵列特征名称")]
        [Category("阵列特征名称")]
        [PropertyOrder(12)]
        public string FeatrueName { get; set; } = "线性阵列特征1";

        #endregion
    }
}

