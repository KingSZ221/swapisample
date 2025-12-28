using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.modeldoc.vo.select
{
    /// <summary>
    /// 射线选择
    /// </summary>
    [DisplayName("射线选择")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class SelectByRayInVo
    {
        #region Fields

        /// <summary>
        /// 射线起点X
        /// </summary>
        [DisplayName("射线起点X")]
        [Category("起点位置")]
        [Description("射线起点X")]
        public double WorldX { get; set; } = 0;

        /// <summary>
        /// 射线起点Y
        /// </summary>
        [DisplayName("射线起点Y")]
        [Category("起点位置")]
        [Description("射线起点Y")]
        public double WorldY { get; set; } = 0;

        /// <summary>
        /// 射线起点Z
        /// </summary>
        [DisplayName("射线起点Z")]
        [Category("起点位置")]
        [Description("射线起点Z")]
        public double WorldZ { get; set; } = 0;

        /// <summary>
        /// 射线方向向量X
        /// </summary>
        [DisplayName("射线方向向量X")]
        [Category("射线方向向量")]
        [Description("射线方向向量X")]
        public double RayVecX { get; set; } = 0;

        /// <summary>
        /// 射线方向向量Y
        /// </summary>
        [DisplayName("射线方向向量Y")]
        [Category("射线方向向量")]
        [Description("射线方向向量Y")]
        public double RayVecY { get; set; } = 0;

        /// <summary>
        /// 射线方向向量Z
        /// </summary>
        [DisplayName("射线方向向量Z")]
        [Category("射线方向向量")]
        [Description("射线方向向量Z")]
        public double RayVecZ { get; set; } = 1;

        /// <summary>
        /// 射线半径
        /// </summary>
        [DisplayName("射线半径")]
        [Category("射线半径")]
        [Description("射线半径")]
        public double RayRadius { get; set; } = 1;

        /// <summary>
        /// 选择对象类型
        /// </summary>
        [DisplayName("选择对象类型")]
        [Category("选择对象")]
        [Description("选择对象类型")]
        public swSelectType_ext TypeWanted { get; set; } = swSelectType_ext.swSelEDGES;

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
        [DisplayName("选择对象选项")]
        [Category("选择对象")]
        [Description("见 swSelectOption_e")]
        public int Option { get; set; } = 0;

        #endregion
    }
}
