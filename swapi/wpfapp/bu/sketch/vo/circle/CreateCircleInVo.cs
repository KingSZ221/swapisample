using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.circle
{
    [DisplayName("绘制圆")]
    public class CreateCircleInVo : SketchEditInVoBase
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
        /// 圆上点X
        /// </summary>
        [DisplayName("圆上点X")]
        [Category("圆上点")]
        public double XP { get; set; } = 100;

        /// <summary>
        /// 圆上点Y
        /// </summary>
        [DisplayName("圆上点Y")]
        [Category("圆上点")]
        public double YP { get; set; } = 100;

        /// <summary>
        /// 圆上点Z
        /// </summary>
        [DisplayName("圆上点Z")]
        [Category("圆上点")]
        public double ZP { get; set; } = 0;

        #endregion
    }
}
