using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo
{
    [DisplayName("绘制直线")]
    public class CreateLineInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 起点X
        /// </summary>
        [DisplayName("起点X")]
        [Category("起点")]
        public double X1 { get; set; } = 0;

        /// <summary>
        /// 起点Y
        /// </summary>
        [DisplayName("起点Y")]
        [Category("起点")]
        public double Y1 { get; set; } = 0;

        /// <summary>
        /// 起点Z
        /// </summary>
        [DisplayName("起点Z")]
        [Category("起点")]
        public double Z1 { get; set; } = 0;

        /// <summary>
        /// 终点X
        /// </summary>
        [DisplayName("终点X")]
        [Category("终点")]
        public double X2 { get; set; } = 100;

        /// <summary>
        /// 终点Y
        /// </summary>
        [DisplayName("终点Y")]
        [Category("终点")]
        public double Y2 { get; set; } = 100;

        /// <summary>
        /// 终点Z
        /// </summary>
        [DisplayName("终点Z")]
        [Category("终点")]
        public double Z2 { get; set; } = 0;

        #endregion
    }
}
