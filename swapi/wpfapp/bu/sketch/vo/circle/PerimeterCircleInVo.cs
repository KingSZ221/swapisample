using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.circle
{
    [DisplayName("绘制周边圆")]
    public class PerimeterCircleInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 圆上第1点X
        /// </summary>
        [DisplayName("圆上第1点X")]
        [Category("圆上第1点")]
        public double X1 { get; set; } = 0;

        /// <summary>
        /// 圆上第1点Y
        /// </summary>
        [DisplayName("圆上第1点Y")]
        [Category("圆上第1点")]
        public double Y1 { get; set; } = 0;

        /// <summary>
        /// 圆上第2点X
        /// </summary>
        [DisplayName("圆上第2点X")]
        [Category("圆上第2点")]
        public double X2 { get; set; } = 0;

        /// <summary>
        /// 圆上第2点Y
        /// </summary>
        [DisplayName("圆上第2点Y")]
        [Category("圆上第2点")]
        public double Y2 { get; set; } = 100;

        /// <summary>
        /// 圆上第3点X
        /// </summary>
        [DisplayName("圆上第3点X")]
        [Category("圆上第3点")]
        public double X3 { get; set; } = 100;

        /// <summary>
        /// 圆上第3点Y
        /// </summary>
        [DisplayName("圆上第3点Y")]
        [Category("圆上第3点")]
        public double Y3 { get; set; } = 0;

        #endregion
    }
}
