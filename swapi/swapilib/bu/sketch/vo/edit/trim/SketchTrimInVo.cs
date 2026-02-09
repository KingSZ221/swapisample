using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.edit.trim
{
    /// <summary>
    /// 裁剪实体
    /// </summary>
    [DisplayName("裁剪实体")]
    public class SketchTrimInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 裁剪方式
        /// </summary>
        [DisplayName("裁剪方式")]
        [Category("裁剪方式")]
        [Description("可选值:参考swSketchTrimChoice_e，默认值:2 = Delete the constraint or dimension and add the fillet" +
            "\r\n 0:swSketchTrimClosest，裁剪到最近段，仅对一个草图段进行修剪，使其与另一个草图实体的交点距离最短。" +
            "\r\n 1:swSketchTrimCorner，边角，仅对两个草图段进行延伸或修剪，以形成一个拐角。" +
            "\r\n 2:swSketchTrimTwoEntities，强劲裁剪，选择两条相交的草图段；将第一个选定的草图段修剪至第二个相交的草图段。" +
            "\r\n 3:swSketchTrimEntityPoint，强劲裁剪，将草图段修剪至特定点。使用此方法，需指定非零的 X、Y 和 Z 值，即要修选定草图段的截断点。所指定的点必须位于该草图段上。" +
            "\r\n 4:swSketchTrimEntities，强劲裁剪，选择一个或多个草图段，并指定其选取点。这些草图段将被修剪至与选取点最近的草图段处。" +
            "\r\n 5:swSketchTrimOutside，裁剪外部，选择至少三个草图段；其中两个用于创建修剪边界，还有一个或多个与边界中的两个草图段相交。所有与边界相交的已选草图段都将在其外部进行修剪，而不受边界段的限制。" +
            "\r\n 6:swSketchTrimInside，裁剪内部，选择至少三个草图段：两个用于划定边界，还有一个或多个与这两个草图段相交，并且与边界相交的草图段。所有与边界相交的已选草图段都会在边界段内部进行修剪。")]
        public int Option { get; set; } = 0;

        /// <summary>
        /// X
        /// </summary>
        [DisplayName("X")]
        [Category("强劲截断点")]
        public double X { get; set; } = 0;

        /// <summary>
        /// Y
        /// </summary>
        [DisplayName("Y")]
        [Category("强劲截断点")]
        public double Y { get; set; } = 0;

        /// <summary>
        /// Z
        /// </summary>
        [DisplayName("Z")]
        [Category("强劲截断点")]
        public double Z { get; set; } = 0;

        #endregion
    }
}
