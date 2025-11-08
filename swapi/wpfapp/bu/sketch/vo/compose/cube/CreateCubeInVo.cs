using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.compose.cube
{
    [DisplayName("创建立方体")]
    public class CreateCubeInVo
    {
        #region Fields

        /// <summary>
        /// 长度mm(mm)
        /// </summary>
        [DisplayName("长度mm)")]
        [Description("mm")]
        public double Length { get; set; } = 100;

        /// <summary>
        /// 宽度(mm)
        /// </summary>
        [DisplayName("宽度(mm)")]
        public double Width { get; set; } = 150;

        /// <summary>
        /// 高度(mm)
        /// </summary>
        [DisplayName("高度(mm)")]
        public double Height { get; set; } = 200;

        #endregion
    }
}
