using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.arc
{
    [DisplayName("绘制圆心/起/终点画弧")]
    public class CreateArcInVo : SketchEditInVoBase
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
        /// 圆弧起点X
        /// </summary>
        [DisplayName("圆弧起点X")]
        [Category("圆弧起点(圆上点)")]
        public double X1 { get; set; } = 100;

        /// <summary>
        /// 圆弧起点Y
        /// </summary>
        [DisplayName("圆弧起点Y")]
        [Category("圆弧起点(圆上点)")]
        public double Y1 { get; set; } = 0;

        /// <summary>
        /// 圆弧起点Z
        /// </summary>
        [DisplayName("圆弧起点Z")]
        [Category("圆弧起点(圆上点)")]
        public double Z1 { get; set; } = 0;

        /// <summary>
        /// 圆弧终点X
        /// </summary>
        [DisplayName("圆弧终点X")]
        [Category("圆弧终点(圆上点)")]
        public double X2 { get; set; } = 0;

        /// <summary>
        /// 圆弧终点Y
        /// </summary>
        [DisplayName("圆弧终点Y")]
        [Category("圆弧终点(圆上点)")]
        public double Y2 { get; set; } = 100;

        /// <summary>
        /// 圆弧终点Z
        /// </summary>
        [DisplayName("圆弧终点Z")]
        [Category("圆弧终点(圆上点)")]
        public double Z2 { get; set; } = 0;

        /// <summary>
        /// 圆弧方向
        /// </summary>
        [DisplayName("圆弧方向")]
        [Category("圆弧方向")]
        [Description("可选值：+1 起点到终点沿着逆时针方向，-1 起点到终点沿着顺时针方向")]
        public short Direction { get; set; } = -1;

        #endregion
    }
}
