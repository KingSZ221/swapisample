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
    [DisplayName("创建草图阵列特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class CreateSketchPatternFeatureInVo
    {
        #region Fields

        /// <summary>
        /// 几何体阵列
        /// </summary>
        [DisplayName("几何体阵列")]
        [Description("true:几何体阵列，false:反之")]
        [PropertyOrder(10)]
        public bool GeometryPattern { get; set; } = false;

        /// <summary>
        /// 使用重心
        /// </summary>
        [DisplayName("使用重心")]
        [Description("true:使用重心，false:不使用")]
        [PropertyOrder(11)]
        public bool UseCentroid { get; set; } = false;

        /// <summary>
        /// 阵列特征名称
        /// </summary>
        [DisplayName("阵列特征名称")]
        [Description("设置阵列特征名称")]
        [Category("阵列特征名称")]
        [PropertyOrder(12)]
        public string FeatrueName { get; set; } = "草图阵列特征1";

        #endregion
    }
}

