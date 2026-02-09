using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.draw.circle
{
    [DisplayName("绘制半径圆")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class CreateCircleByRadiusInVo : SketchDrawInVoBase
    {
        #region Fields

        /// <summary>
        /// 圆心X
        /// </summary>
        [DisplayName("圆心X")]
        [Category("圆心")]
        public double XC { get; set; } = 0;

        /// <summary>
        /// 圆心Y
        /// </summary>
        [DisplayName("圆心Y")]
        [Category("圆心")]
        public double YC { get; set; } = 0;

        /// <summary>
        /// 圆心Z
        /// </summary>
        [DisplayName("圆心Z")]
        [Category("圆心")]
        public double ZC { get; set; } = 0;

        /// <summary>
        /// 半径
        /// </summary>
        [DisplayName("半径")]
        [Category("半径")]
        public double Radius { get; set; } = 100;

        #endregion
    }
}
