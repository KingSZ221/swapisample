using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.point
{
    [DisplayName("绘制点")]
    public class CreatePointInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// X
        /// </summary>
        [DisplayName("X")]
        [Category("位置")]
        public double X { get; set; } = 100;

        /// <summary>
        /// Y
        /// </summary>
        [DisplayName("Y")]
        [Category("位置")]
        public double Y { get; set; } = 100;

        /// <summary>
        /// Z
        /// </summary>
        [DisplayName("Z")]
        [Category("位置")]
        public double Z { get; set; } = 0;

        #endregion
    }
}
