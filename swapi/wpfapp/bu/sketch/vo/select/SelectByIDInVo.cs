using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.select
{
    /// <summary>
    /// 射线选择
    /// </summary>
    [DisplayName("射线选择")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class SelectByIDInVo
    {
        #region Fields

        /// <summary>
        /// 选中对象的名称
        /// </summary>
        [DisplayName("选中对象的名称")]
        [Category("名称")]
        [Description("选中对象的名称，可以为空字符串")]
        public string Name { get; set; } = "";

        /// <summary>
        /// 选中对象的类型
        /// </summary>
        [DisplayName("选中对象的类型")]
        [Category("类型")]
        [Description("选中对象的类型，可以为空字符串")]
        public string Type { get; set; } = "";

        /// <summary>
        /// 对象位置X
        /// </summary>
        [DisplayName("对象位置X")]
        [Category("对象位置")]
        [Description("对象位置X")]
        public double X { get; set; } = 0;

        /// <summary>
        /// 对象位置Y
        /// </summary>
        [DisplayName("对象位置Y")]
        [Category("对象位置")]
        [Description("对象位置Y")]
        public double Y { get; set; } = 0;

        /// <summary>
        /// 对象位置Z
        /// </summary>
        [DisplayName("对象位置Z")]
        [Category("对象位置")]
        [Description("对象位置Z")]
        public double Z { get; set; } = 0;

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

        /// <summary>
        /// 选择对象选项
        /// </summary>
        [DisplayName("选择对象类型")]
        [Category("选择对象")]
        [Description("见 swSelectOption_e")]
        public int Option { get; set; } = 0;

        #endregion
    }
}
