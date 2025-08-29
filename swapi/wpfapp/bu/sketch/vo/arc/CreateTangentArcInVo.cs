using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.arc
{
    [DisplayName("绘制切线弧")]
    public class CreateTangentArcInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 圆弧起点X
        /// </summary>
        [DisplayName("圆弧起点X")]
        [Category("圆弧起点(切点)")]
        public double X1 { get; set; } = 100;

        /// <summary>
        /// 圆弧起点Y
        /// </summary>
        [DisplayName("圆弧起点Y")]
        [Category("圆弧起点(切点)")]
        public double Y1 { get; set; } = 0;

        /// <summary>
        /// 圆弧起点Z
        /// </summary>
        [DisplayName("圆弧起点Z")]
        [Category("圆弧起点(切点)")]
        public double Z1 { get; set; } = 0;

        /// <summary>
        /// 圆弧终点X
        /// </summary>
        [DisplayName("圆弧终点X")]
        [Category("圆弧终点")]
        public double X2 { get; set; } = 0;

        /// <summary>
        /// 圆弧终点Y
        /// </summary>
        [DisplayName("圆弧终点Y")]
        [Category("圆弧终点")]
        public double Y2 { get; set; } = 100;

        /// <summary>
        /// 圆弧终点Z
        /// </summary>
        [DisplayName("圆弧终点Z")]
        [Category("圆弧终点")]
        public double Z2 { get; set; } = 0;

        /// <summary>
        /// 圆弧方向
        /// </summary>
        [DisplayName("圆弧类型")]
        [Category("圆弧类型")]
        [Description("可选值：见swTangentArcTypes_e，1-swForward，2-swLeft，3-swBack，4-swRight")]
        public int ArcType { get; set; } = 1;

        #endregion
    }
}
