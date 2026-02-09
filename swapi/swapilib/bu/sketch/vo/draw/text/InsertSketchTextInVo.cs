using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.draw.text
{
    [DisplayName("绘制文本")]
    public class InsertSketchTextInVo : SketchDrawInVoBase
    {
        #region Fields

        /// <summary>
        /// X
        /// </summary>
        [DisplayName("X")]
        [Category("位置")]
        public double Ptx { get; set; } = 100;

        /// <summary>
        /// Y
        /// </summary>
        [DisplayName("Y")]
        [Category("位置")]
        public double Pty { get; set; } = 100;

        /// <summary>
        /// Z
        /// </summary>
        [DisplayName("Z")]
        [Category("位置")]
        public double Ptz { get; set; } = 0;

        /// <summary>
        /// 文字
        /// </summary>
        [DisplayName("文字")]
        [Category("文字")]
        public string Text { get; set; } = "Hello SolidWorks";

        /// <summary>
        /// 对齐方式
        /// </summary>
        [DisplayName("对齐方式")]
        [Category("样式")]
        [Description("0 = 左对齐,1 = 居中,2 = 右对齐,3 = 两端对齐")]
        public int Alignment { get; set; } = 0;

        /// <summary>
        /// 竖直反转方向
        /// </summary>
        [DisplayName("竖直反转方向")]
        [Category("样式")]
        [Description("0 = 不反转,1 = 反转")]
        public int FlipDirection { get; set; } = 0;

        /// <summary>
        /// 水平反转方向
        /// </summary>
        [DisplayName("水平反转方向")]
        [Category("样式")]
        [Description("0 = 不反转,1 = 反转")]
        public int HorizontalMirror { get; set; } = 0;

        /// <summary>
        /// WidthFactor
        /// </summary>
        [DisplayName("WidthFactor")]
        [Category("样式")]
        [Description("Width factor of the text")]
        public int WidthFactor { get; set; } = 100;

        /// <summary>
        /// SpaceBetweenChars
        /// </summary>
        [DisplayName("SpaceBetweenChars")]
        [Category("样式")]
        [Description("Amount of space between the characters in the text block")]
        public int SpaceBetweenChars { get; set; } = 100;

        #endregion
    }
}
