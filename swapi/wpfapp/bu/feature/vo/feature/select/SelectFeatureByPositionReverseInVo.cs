using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.feature.vo.feature.select
{
    /// <summary>
    /// 选中特征树从下往上排序的指定序号的1个特征
    /// </summary>
    [DisplayName("射线选择")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class SelectFeatureByPositionReverseInVo
    {
        #region Fields

        /// <summary>
        /// 序号
        /// </summary>
        [DisplayName("序号")]
        [Description("特征树从下往上排序的特征序号，最下面的特性序号为0")]
        public int Num { get; set; } = 0;

        /// <summary>
        /// 追加选择
        /// </summary>
        [DisplayName("追加选择")]
        [Category("选择对象")]
        [Description("true:追加选择，false，清空当前选择")]
        public bool Append { get; set; } = false;

        /// <summary>
        /// 选择对象标记
        /// </summary>
        [DisplayName("选择对象标记")]
        [Category("选择对象")]
        [Description("选择对象标记")]
        public int Mark { get; set; } = 0;

        #endregion
    }
}
