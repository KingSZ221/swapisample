using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.sketch.vo.entity;

namespace swapilib.bu.feature.vo.feature.sweep
{
    [DisplayName("创建扫描基体/凸台特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class FeatureSweepInVo
    {
        #region Fields

        /// <summary>
        /// 扫描特征名称
        /// </summary>
        [DisplayName("扫描特征名称")]
        [Description("设置扫描特征名称")]
        [Category("扫描特征名称")]
        public string FeatrueName { get; set; } = "";

        #endregion
    }
}
