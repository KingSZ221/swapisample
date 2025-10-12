using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.entity
{
    /// <summary>
    /// 草图数学点
    /// </summary>
    [DisplayName("位置")]
    [Description("位置")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class SketchMathPointInfo
    {
        #region Fields

        /// <summary>
        /// X
        /// </summary>
        [DisplayName("X")]
        public double X { get; set; } = 0;

        /// <summary>
        /// Y
        /// </summary>
        [DisplayName("Y")]
        public double Y { get; set; } = 0;

        /// <summary>
        /// Z
        /// </summary>
        [DisplayName("Z")]
        public double Z { get; set; } = 0;

        #endregion
    }
}
