using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.edit.pattern
{
    /// <summary>
    /// 圆周草图阵列
    /// </summary>
    [DisplayName("圆周草图阵列")]
    public class CreateCircularSketchStepAndRepeatInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 圆形草图阵列的半径
        /// </summary>
        [DisplayName("ArcRadius")]
        [Description("圆形草图阵列的半径")]
        public double ArcRadius { get; set; } = 500;

        /// <summary>
        /// 与所要复制的图形元素的相对角度
        /// </summary>
        [DisplayName("ArcAngle")]
        [Description("与所要复制的图形元素的相对角度")]
        public double ArcAngle { get; set; } = 30;

        /// <summary>
        /// 包括种子几何体在内的总实例数量
        /// </summary>
        [DisplayName("PatternNum")]
        [Description("包括种子几何体在内的总实例数量")]
        public int PatternNum { get; set; } = 5;

        /// <summary>
        /// 图案实例之间的角度
        /// </summary>
        [DisplayName("PatternSpacing")]
        [Description("图案实例之间的间距")]
        public double PatternSpacing { get; set; } = 60;

        /// <summary>
        /// True的话要旋转图案，False的话则不要旋转
        /// </summary>
        [DisplayName("PatternRotate")]
        [Description("True的话要旋转图案，False的话则不要旋转")]
        public bool PatternRotate { get; set; } = true;

        /// <summary>
        /// 要删除的实例数量，以字符串形式传递，格式为：“(1) (2) (4)”
        /// </summary>
        [DisplayName("DeleteInstances")]
        [Description("要删除的实例数量，以字符串形式传递，格式为：“(a) (b) (c)”")]
        public string DeleteInstances { get; set; } = "";

        /// <summary>
        /// 在图形区域中显示半径尺寸（设为“真”）；不显示（设为“假”）
        /// </summary>
        [DisplayName("RadiusDim")]
        [Description("在图形区域中显示半径尺寸（设为“真”）；不显示（设为“假”）")]
        public bool RadiusDim { get; set; } = true;

        /// <summary>
        /// 在图形区域中显示角度尺寸时选择“是”，不显示时选择“否”
        /// </summary>
        [DisplayName("AngleDim")]
        [Description("在图形区域中显示角度尺寸时选择“是”，不显示时选择“否”")]
        public bool AngleDim { get; set; } = true;

        /// <summary>
        /// 在图形区域中显示实例数量，请选“是”；不显示，请选“否”。
        /// </summary>
        [DisplayName("CreateNumOfInstancesDim")]
        [Description("在图形区域中显示实例数量，请选“是”；不显示，请选“否”。")]
        public bool CreateNumOfInstancesDim { get; set; } = true;

        #endregion
    }
}
