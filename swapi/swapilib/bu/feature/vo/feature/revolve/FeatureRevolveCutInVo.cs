using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace swapilib.bu.feature.vo.feature.revolve
{
    [DisplayName("创建旋转切除特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class FeatureRevolveCutInVo : FeatureRevolveBaseInVo
    {
        /// <summary>
        /// 旋转基体名称
        /// </summary>
        [DisplayName("旋转基体名称")]
        [Description("设置旋转特征名称")]
        [Category("旋转基体名称")]
        [PropertyOrder(23)]
        public string FeatrueName { get; set; } = "旋转切除特征1";
    }
}
