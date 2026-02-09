using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.edit.copy
{
    /// <summary>
    /// 旋转复制实体
    /// </summary>
    [DisplayName("旋转复制实体")]
    public class RotateOrCopyInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 旋转或复制
        /// </summary>
        [DisplayName("旋转或复制")]
        [Description("ture-复制，false-旋转")]
        public bool Copy { get; set; } = false;

        /// <summary>
        /// 复制数量
        /// </summary>
        [DisplayName("复制数量")]
        [Description("复制实体数量，不含原实体。")]
        public int NumCopies { get; set; } = 0;

        /// <summary>
        /// 复制时保持草图关系
        /// </summary>
        [DisplayName("复制时保持草图关系")]
        [Description("ture-复制时保持草图关系，false-不保持。")]
        public bool KeepRelations { get; set; } = false;

        /// <summary>
        /// 旋转基准点X
        /// </summary>
        [DisplayName("旋转基准点X")]
        [Description("旋转基准点")]
        public double BaseX { get; set; } = 0;

        /// <summary>
        /// 旋转基准点Y
        /// </summary>
        [DisplayName("旋转基准点X")]
        [Description("旋转基准点")]
        public double BaseY { get; set; } = 0;

        /// <summary>
        /// 旋转基准点Z
        /// </summary>
        [DisplayName("旋转基准点Z")]
        [Description("旋转基准点")]
        public double BaseZ { get; set; } = 0;

        /// <summary>
        /// 旋转轴向量X
        /// </summary>
        [DisplayName("旋转轴向量X")]
        [Description("旋转轴向量")]
        public double DestX { get; set; } = 0;

        /// <summary>
        /// 旋转轴向量Y
        /// </summary>
        [DisplayName("旋转轴向量Y")]
        [Description("旋转轴向量")]
        public double DestY { get; set; } = 0;

        /// <summary>
        /// 旋转轴向量Z
        /// </summary>
        [DisplayName("旋转轴向量Z")]
        [Description("旋转轴向量")]
        public double DestZ { get; set; } = 1;

        /// <summary>
        /// 旋转角度
        /// </summary>
        [DisplayName("旋转角度")]
        [Description("旋转角度")]
        public double Angle { get; set; } = 60;

        #endregion
    }
}
