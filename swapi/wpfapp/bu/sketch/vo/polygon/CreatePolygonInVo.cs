using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.polygon
{
    [DisplayName("绘制多边形")]
    public class CreatePolygonInVo : SketchEditInVoBase
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
        /// 多边形顶点X
        /// </summary>
        [DisplayName("多边形顶点X")]
        [Category("多边形顶点")]
        public double XP { get; set; } = 100;

        /// <summary>
        /// 多边形顶点Y
        /// </summary>
        [DisplayName("多边形顶点Y")]
        [Category("多边形顶点")]
        public double YP { get; set; } = 100;

        /// <summary>
        /// 多边形顶点Z
        /// </summary>
        [DisplayName("多边形顶点Z")]
        [Category("多边形顶点")]
        public double ZP { get; set; } = 0;

        /// <summary>
        /// 多边形边数量
        /// </summary>
        [DisplayName("边数量")]
        [Category("多边形")]
        public int Sides { get; set; } = 6;

        /// <summary>
        /// 多边形边数量
        /// </summary>
        [DisplayName("内切圆")]
        [Category("多边形")]
        [Description("true-内切圆, false-外接圆")]
        public bool Inscribed { get; set; } = true;

        #endregion
    }
}
