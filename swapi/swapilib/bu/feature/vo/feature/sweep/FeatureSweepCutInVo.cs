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
    [DisplayName("创建扫描切除特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class FeatureSweepCutInVo
    {
        #region Fields

        /// <summary>
        /// 扫描切除特征名称
        /// </summary>
        [DisplayName("扫描切除特征名称")]
        [Description("设置扫描切除特征名称")]
        [Category("扫描切除特征名称")]
        public string FeatrueName { get; set; } = "";

        #endregion
    }
}
