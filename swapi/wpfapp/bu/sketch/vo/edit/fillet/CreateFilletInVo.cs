using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.sketch.vo.edit.fillet
{
    /// <summary>
    /// 绘制圆角
    /// </summary>
    [DisplayName("绘制圆角")]
    public class CreateFilletInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 圆心Y
        /// </summary>
        [DisplayName("半径")]
        [Category("圆角")]
        public double Radius { get; set; } = 10;

        /// <summary>
        /// 圆心Z
        /// </summary>
        [DisplayName("保留约束")]
        [Category("圆角")]
        [Description("可选值:见swConstrainedCornerAction_e，默认值:2 = Delete the constraint or dimension and add the fillet")]
        public int ConstrainedCorners { get; set; } = 2;

        #endregion
    }
}
