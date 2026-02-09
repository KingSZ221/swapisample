using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.entity
{
    /// <summary>
    /// 草图点
    /// </summary>
    [DisplayName("草图点")]
    public class SketchPointInfo : SketchEntityItemInfo
    {
        #region Fields

        /// <summary>
        /// X
        /// </summary>
        [DisplayName("位置")]
        [Category("位置")]
        public SketchMathPointInfo Position { get; set; }

        #endregion
    }
}
