using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.draw.ellipse
{
    /// <summary>
    /// 绘制抛物线
    /// </summary>
    [DisplayName("绘制抛物线")]
    public class CreateParabolaInVo : SketchDrawInVoBase
    {
        #region Fields

        /// <summary>
        /// 焦点X
        /// </summary>
        [DisplayName("焦点X")]
        [Category("焦点")]
        public double XFocus { get; set; } = 0;

        /// <summary>
        /// 焦点Y
        /// </summary>
        [DisplayName("焦点Y")]
        [Category("焦点")]
        public double YFocus { get; set; } = 500;

        /// <summary>
        /// 焦点Z
        /// </summary>
        [DisplayName("焦点Z")]
        [Category("焦点")]
        public double ZFocus { get; set; } = 0;

        /// <summary>
        /// 顶点X
        /// </summary>
        [DisplayName("顶点X")]
        [Category("顶点")]
        public double XApex { get; set; } = 0;

        /// <summary>
        /// 顶点Y
        /// </summary>
        [DisplayName("顶点Y")]
        [Category("顶点")]
        public double YApex { get; set; } = 0;

        /// <summary>
        /// 顶点Z
        /// </summary>
        [DisplayName("顶点Z")]
        [Category("顶点")]
        public double ZApex { get; set; } = 0;

        /// <summary>
        /// 弧起点X
        /// </summary>
        [DisplayName("弧起点X")]
        [Category("弧起点")]
        public double X1 { get; set; } = -3000;

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
        public double X2 { get; set; } = 3000;

        /// <summary>
        /// 弧终点Y
        /// </summary>
        [DisplayName("弧终点Y")]
        [Category("弧终点")]
        public double Y2 { get; set; } = 0;

        /// <summary>
        /// 弧终点Z
        /// </summary>
        [DisplayName("弧终点Z")]
        [Category("弧终点")]
        public double Z2 { get; set; } = 0;

        #endregion
    }
}
