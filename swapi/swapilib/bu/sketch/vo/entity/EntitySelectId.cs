using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.entity
{
    /// <summary>
    /// 草图实体选择ID
    /// </summary>
    [DisplayName("草图实体选择ID")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class EntitySelectId
    {
        #region Fields

        /// <summary>
        /// 草图名称
        /// </summary>
        [DisplayName("草图名称")]
        [Category("基础")]
        [Description("草图名称")]
        public string SketchName { get; set; } = "";

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [Category("基础")]
        [Description("段(直线、弧、椭圆、抛物线等)-填实体名称,\r\n点-填空")]
        public string Name { get; set; } = "";

        /// <summary>
        /// 类型ID
        /// </summary>
        [DisplayName("类型")]
        [Category("基础")]
        [Description("可选值:\r\n段(直线、弧、椭圆、抛物线等)-SKETCHSEGMENT,\r\n点-SKETCHPOINT")]
        public string Type { get; set; } = "";

        /// <summary>
        /// X
        /// </summary>
        [DisplayName("X")]
        [Category("位置")]
        [Description("段(直线、弧、椭圆、抛物线等)-不填,\r\n点-填点位置")]
        public double X { get; set; } = 0;

        /// <summary>
        /// Y
        /// </summary>
        [DisplayName("Y")]
        [Category("位置")]
        [Description("段(直线、弧、椭圆、抛物线等)-不填,\r\n点-填点位置")]
        public double Y { get; set; } = 0;

        /// <summary>
        /// Z
        /// </summary>
        [DisplayName("Z")]
        [Category("位置")]
        [Description("段(直线、弧、椭圆、抛物线等)-不填,\r\n点-填点位置")]
        public double Z { get; set; } = 0;

        #endregion
    }
}
