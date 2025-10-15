using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.edit.extend
{
    /// <summary>
    /// 延伸实体
    /// </summary>
    [DisplayName("延伸实体")]
    public class SketchExtendInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// X
        /// </summary>
        [DisplayName("X")]
        [Description("固定填0")]
        public double X { get; set; } = 0;

        /// <summary>
        /// Y
        /// </summary>
        [DisplayName("Y")]
        [Description("固定填0")]
        public double Y { get; set; } = 0;

        /// <summary>
        /// Z
        /// </summary>
        [DisplayName("Z")]
        [Description("固定填0")]
        public double Z { get; set; } = 0;

        #endregion
    }
}
