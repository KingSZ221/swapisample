using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.draw.ellipse
{
    /// <summary>
    /// 绘制椭圆
    /// </summary>
    [DisplayName("绘制椭圆")]
    public class CreateEllipseInVo : SketchDrawInVoBase
    {
        #region Fields

        /// <summary>
        /// 椭圆中心X
        /// </summary>
        [DisplayName("椭圆中心X")]
        [Category("椭圆中心")]
        public double XC { get; set; } = 0;

        /// <summary>
        /// 椭圆中心Y
        /// </summary>
        [DisplayName("椭圆中心Y")]
        [Category("椭圆中心")]
        public double YC { get; set; } = 0;

        /// <summary>
        /// 椭圆中心Z
        /// </summary>
        [DisplayName("椭圆中心Z")]
        [Category("椭圆中心")]
        public double ZC { get; set; } = 0;

        /// <summary>
        /// 主轴上点X
        /// </summary>
        [DisplayName("主轴上点X")]
        [Category("主轴")]
        public double XMajor { get; set; } = 100;

        /// <summary>
        /// 主轴上点Y
        /// </summary>
        [DisplayName("主轴上点Y")]
        [Category("主轴")]
        public double YMajor { get; set; } = 0;

        /// <summary>
        /// 主轴上点Z
        /// </summary>
        [DisplayName("主轴上点Z")]
        [Category("主轴")]
        public double ZMajor { get; set; } = 0;

        /// <summary>
        /// 次轴上点X
        /// </summary>
        [DisplayName("次轴上点X")]
        [Category("次轴")]
        public double XMinor { get; set; } = 0;

        /// <summary>
        /// 次轴上点Y
        /// </summary>
        [DisplayName("次轴上点Y")]
        [Category("次轴")]
        public double YMinor { get; set; } = 50;

        /// <summary>
        /// 次轴上点Z
        /// </summary>
        [DisplayName("次轴上点Z")]
        [Category("次轴")]
        public double ZMinor { get; set; } = 0;

        #endregion
    }
}
