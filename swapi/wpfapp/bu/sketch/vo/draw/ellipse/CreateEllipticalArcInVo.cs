using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.draw.ellipse
{
    /// <summary>
    /// 绘制部分椭圆
    /// </summary>
    [DisplayName("绘制部分椭圆")]
    public class CreateEllipticalArcInVo : SketchDrawInVoBase
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
        public double XMajor { get; set; } = 1000;

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
        public double YMinor { get; set; } = 500;

        /// <summary>
        /// 次轴上点Z
        /// </summary>
        [DisplayName("次轴上点Z")]
        [Category("次轴")]
        public double ZMinor { get; set; } = 0;

        /// <summary>
        /// 弧起点X
        /// </summary>
        [DisplayName("弧起点X")]
        [Category("弧起点")]
        public double X1 { get; set; } = 1000;

        /// <summary>
        /// 弧起点Y
        /// </summary>
        [DisplayName("弧起点Y")]
        [Category("弧起点")]
        public double Y1 { get; set; } = 0;

        /// <summary>
        /// 弧起点Z
        /// </summary>
        [DisplayName("弧起点Z")]
        [Category("弧起点")]
        public double Z1 { get; set; } = 0;

        /// <summary>
        /// 弧终点X
        /// </summary>
        [DisplayName("弧终点X")]
        [Category("弧终点")]
        public double X2 { get; set; } = 0;

        /// <summary>
        /// 弧终点Y
        /// </summary>
        [DisplayName("弧终点Y")]
        [Category("弧终点")]
        public double Y2 { get; set; } = 500;

        /// <summary>
        /// 弧终点Z
        /// </summary>
        [DisplayName("弧终点Z")]
        [Category("弧终点")]
        public double Z2 { get; set; } = 0;

        /// <summary>
        /// 弧方向
        /// </summary>
        [DisplayName("弧方向")]
        [Category("弧方向")]
        [Description("+1:逆时针,-1:顺时针")]
        public short Direction { get; set; } = -1;

        #endregion
    }
}
