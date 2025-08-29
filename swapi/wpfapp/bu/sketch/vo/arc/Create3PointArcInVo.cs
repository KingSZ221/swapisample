using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.arc
{
    /// <summary>
    /// 绘制3点圆弧
    /// </summary>
    [DisplayName("绘制3点圆弧")]
    public class Create3PointArcInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 第1点X
        /// </summary>
        [DisplayName("第1点X")]
        [Category("第1点(圆上点)")]
        public double X1 { get; set; } = 0;

        /// <summary>
        /// 第1点Y
        /// </summary>
        [DisplayName("第1点Y")]
        [Category("第1点(圆上点)")]
        public double Y1 { get; set; } = 0;

        /// <summary>
        /// 第1点Z
        /// </summary>
        [DisplayName("第1点Z")]
        [Category("第1点(圆上点)")]
        public double Z1 { get; set; } = 0;

        /// <summary>
        /// 第2点X
        /// </summary>
        [DisplayName("第2点X")]
        [Category("第2点(圆上点)")]
        public double X2 { get; set; } = 100;

        /// <summary>
        /// 第2点Y
        /// </summary>
        [DisplayName("第2点Y")]
        [Category("第2点(圆上点)")]
        public double Y2 { get; set; } = 0;

        /// <summary>
        /// 第2点Z
        /// </summary>
        [DisplayName("第2点Z")]
        [Category("第2点(圆上点)")]
        public double Z2 { get; set; } = 0;

        /// <summary>
        /// 第3点X
        /// </summary>
        [DisplayName("第3点X")]
        [Category("第3点(圆上点)")]
        public double X3 { get; set; } = 0;

        /// <summary>
        /// 第3点Y
        /// </summary>
        [DisplayName("第3点Y")]
        [Category("第3点(圆上点)")]
        public double Y3 { get; set; } = 100;

        /// <summary>
        /// 第3点Z
        /// </summary>
        [DisplayName("第3点Z")]
        [Category("第3点(圆上点)")]
        public double Z3 { get; set; } = 0;

        #endregion
    }
}
