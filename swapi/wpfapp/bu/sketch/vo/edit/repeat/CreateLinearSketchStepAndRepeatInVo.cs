using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.edit.repeat
{
    /// <summary>
    /// 线性草图阵列
    /// </summary>
    [DisplayName("线性草图阵列")]
    public class CreateLinearSketchStepAndRepeatInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// x 轴上的总实例数（包括种子）
        /// </summary>
        [DisplayName("NumX")]
        [Description("x 轴上的总实例数（包括种子）")]
        public int NumX { get; set; } = 4;

        /// <summary>
        /// y 轴上的总实例数（包括种子）
        /// </summary>
        [DisplayName("NumY")]
        [Description("y 轴上的总实例数（包括种子）")]
        public int NumY { get; set; } = 4;

        /// <summary>
        /// 沿 x 轴方向各实例之间的间距
        /// </summary>
        [DisplayName("SpacingX")]
        [Description("沿 x 轴方向各实例之间的间距")]
        public double SpacingX { get; set; } = 400;

        /// <summary>
        /// 沿 y 轴方向各实例之间的间距
        /// </summary>
        [DisplayName("SpacingY")]
        [Description("沿 y 轴方向各实例之间的间距")]
        public double SpacingY { get; set; } = 600;

        /// <summary>
        /// 相对于 x 轴的方向 1 的角度
        /// </summary>
        [DisplayName("AngleX")]
        [Description("相对于 x 轴的方向 1 的角度")]
        public double AngleX { get; set; } = 30;

        /// <summary>
        /// 相对于 y 轴的方向 2 的角度
        /// </summary>
        [DisplayName("AngleY")]
        [Description("相对于 y 轴的方向 2 的角度")]
        public double AngleY { get; set; } = 60;

        /// <summary>
        /// 要删除的实例数量，以字符串形式传递，格式为：“(a) (b) (c)”
        /// </summary>
        [DisplayName("DeleteInstances")]
        [Description("要删除的实例数量，以字符串形式传递，格式为：“(1) (3) (4)”")]
        public string DeleteInstances { get; set; } = "";

        /// <summary>
        /// 在图形区域中，若为“真”则显示实例之间沿 x 轴的间距，若为“假”则不显示。
        /// </summary>
        [DisplayName("XSpacingDim")]
        [Description("在图形区域中，若为“真”则显示实例之间沿 x 轴的间距，若为“假”则不显示。")]
        public bool XSpacingDim { get; set; } = true;

        /// <summary>
        /// 在图形区域中，若为“真”则显示实例之间沿 y 轴的间距，若为“假”则不显示。
        /// </summary>
        [DisplayName("YSpacingDim")]
        [Description("在图形区域中，若为“真”则显示实例之间沿 y 轴的间距，若为“假”则不显示。")]
        public bool YSpacingDim { get; set; } = true;

        /// <summary>
        /// 在图形区域中显示坐标轴之间的角度标注，请选“是”；不显示，请选“否”。
        /// </summary>
        [DisplayName("AngleDim")]
        [Description("在图形区域中显示坐标轴之间的角度标注，请选“是”；不显示，请选“否”。")]
        public bool AngleDim { get; set; } = true;

        /// <summary>
        /// 在图形区域中显示 x 方向维度中的实例数量（若为“真”则显示，否则不显示）
        /// </summary>
        [DisplayName("CreateNumOfInstancesDimInXDir")]
        [Description("在图形区域中显示 x 方向维度中的实例数量（若为“真”则显示，否则不显示）")]
        public bool CreateNumOfInstancesDimInXDir { get; set; } = true;

        /// <summary>
        /// 在图形区域中显示沿 y 方向的实例数量（若为“真”则显示，否则不显示）
        /// </summary>
        [DisplayName("CreateNumOfInstancesDimInYDir")]
        [Description("在图形区域中显示沿 y 方向的实例数量（若为“真”则显示，否则不显示）")]
        public bool CreateNumOfInstancesDimInYDir { get; set; } = true;

        #endregion
    }
}
