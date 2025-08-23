using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.vo
{
    [DisplayName("新建圆管")]
    public class NewCirclePipeInVo
    {
        #region Fields

        /// <summary>
        /// 圆管半径(mm)
        /// </summary>
        [DisplayName("圆管半径(mm)")]
        [Description("mm")]
        public double CircleRadius { get; set; } = 30;

        /// <summary>
        /// 圆管长度(mm)
        /// </summary>
        [DisplayName("圆管长度(mm)")]
        public double Length { get; set; } = 100;

        /// <summary>
        /// 圆管厚度(mm)
        /// </summary>
        [DisplayName("圆管厚度(mm)")]
        public double Thickness { get; set; } = 2;

        #endregion
    }
}
