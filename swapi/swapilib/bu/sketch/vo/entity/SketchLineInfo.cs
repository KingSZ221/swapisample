using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.entity
{
    /// <summary>
    /// 草图直线
    /// </summary>
    [DisplayName("草图直线")]
    public class SketchLineInfo : SketchSegmentInfo
    {
        #region Fields

        /// <summary>
        /// 起点
        /// </summary>
        [DisplayName("起点")]
        [Category("位置")]
        public SketchMathPointInfo StartPoint { get; set; } = new SketchMathPointInfo();

        /// <summary>
        /// 终点
        /// </summary>
        [DisplayName("终点")]
        [Category("位置")]
        public SketchMathPointInfo EndPoint { get; set; } = new SketchMathPointInfo();

        #endregion
    }
}
