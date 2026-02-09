using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.edit.relation
{
    /// <summary>
    /// 标注草图尺寸
    /// </summary>
    [DisplayName("标注草图尺寸")]
    public class AddDimensionInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 标注文本位置X
        /// </summary>
        [DisplayName("标注文本位置X")]
        [Description("标注文本位置X")]
        public double X { get; set; } = 0;

        /// <summary>
        /// 标注文本位置Y
        /// </summary>
        [DisplayName("标注文本位置Y")]
        [Description("标注文本位置Y")]
        public double Y { get; set; } = 0;

        /// <summary>
        /// 标注文本位置Z
        /// </summary>
        [DisplayName("标注文本位置Z")]
        [Description("标注文本位置Z")]
        public double Z { get; set; } = 0;

        #endregion
    }
}
