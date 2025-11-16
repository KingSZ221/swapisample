using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.feature.vo.feature.revolve
{
    [DisplayName("创建旋转基体/凸台特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class FeatureRevolveInVo : FeatureRevolveBaseInVo
    {
    }
}
