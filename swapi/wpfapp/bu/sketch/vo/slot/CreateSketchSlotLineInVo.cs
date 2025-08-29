using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.slot
{
    /// <summary>
    /// 绘制直槽口
    /// </summary>
    [DisplayName("绘制直槽口")]
    public class CreateSketchSlotLineInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 槽口类型
        /// </summary>
        [DisplayName("槽口长度类型")]
        [Description("可选值：见swSketchSlotLengthType_e，0 = CenterCenter ,1 = FullLength")]
        [Category("普通")]
        public int SlotLengthType { get; set; } = 0;

        /// <summary>
        /// 槽口宽度
        /// </summary>
        [DisplayName("槽口宽度")]
        [Category("普通")]
        public double Width { get; set; } = 6;

        /// <summary>
        /// 第1点X
        /// </summary>
        [DisplayName("第1点X")]
        [Category("第1点")]
        public double X1 { get; set; } = 756;

        /// <summary>
        /// 第1点Y
        /// </summary>
        [DisplayName("第1点Y")]
        [Category("第1点")]
        public double Y1 { get; set; } = -50;

        /// <summary>
        /// 第1点Z
        /// </summary>
        [DisplayName("第1点Z")]
        [Category("第1点")]
        public double Z1 { get; set; } = 0;

        /// <summary>
        /// 第2点X
        /// </summary>
        [DisplayName("第2点X")]
        [Category("第2点")]
        public double X2 { get; set; } = 769;

        /// <summary>
        /// 第2点Y
        /// </summary>
        [DisplayName("第2点Y")]
        [Category("第2点")]
        public double Y2 { get; set; } = -50;

        /// <summary>
        /// 第2点Z
        /// </summary>
        [DisplayName("第2点Z")]
        [Category("第2点")]
        public double Z2 { get; set; } = 0;

        /// <summary>
        /// 第3点X
        /// </summary>
        [DisplayName("第3点X")]
        [Category("第3点")]
        public double X3 { get; set; } = 0;

        /// <summary>
        /// 第2点Y
        /// </summary>
        [DisplayName("第3点Y")]
        [Category("第3点")]
        public double Y3 { get; set; } = 0;

        /// <summary>
        /// 第2点Z
        /// </summary>
        [DisplayName("第3点Z")]
        [Category("第3点")]
        public double Z3 { get; set; } = 0;

        /// <summary>
        /// 中心圆弧方向
        /// </summary>
        [DisplayName("中心圆弧方向")]
        [Description("可选值：-1 = Clockwise (CW) ,1 = Counterclockwise (CCW)")]
        [Category("普通")]
        public int CenterArcDirection { get; set; } = -1;

        /// <summary>
        /// AddDimension
        /// </summary>
        [DisplayName("AddDimension")]
        [Category("普通")]
        [Description("True to automatically add dimensions, false to not")]
        public bool AddDimension { get; set; } = false;

        #endregion
    }
}
