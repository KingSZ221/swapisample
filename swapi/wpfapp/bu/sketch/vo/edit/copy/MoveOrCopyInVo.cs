using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.edit.copy
{
    /// <summary>
    /// 移动复制实体
    /// </summary>
    [DisplayName("移动复制实体")]
    public class MoveOrCopyInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 移动或复制
        /// </summary>
        [DisplayName("移动或复制")]
        [Description("ture-复制，false-移动")]
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
        /// 移动基准点X
        /// </summary>
        [DisplayName("移动基准点X")]
        [Description("移动基准点")]
        public double BaseX { get; set; } = 0;

        /// <summary>
        /// 移动基准点Y
        /// </summary>
        [DisplayName("移动基准点X")]
        [Description("移动基准点")]
        public double BaseY { get; set; } = 0;

        /// <summary>
        /// 移动基准点Z
        /// </summary>
        [DisplayName("移动基准点Z")]
        [Description("移动基准点")]
        public double BaseZ { get; set; } = 0;

        /// <summary>
        /// 移动目的点X
        /// </summary>
        [DisplayName("移动目的点X")]
        [Description("移动目的点")]
        public double DestX { get; set; } = 500;

        /// <summary>
        /// 移动目的点Y
        /// </summary>
        [DisplayName("移动目的点Y")]
        [Description("移动目的点")]
        public double DestY { get; set; } = 500;

        /// <summary>
        /// 移动目的点Z
        /// </summary>
        [DisplayName("移动目的点Z")]
        [Description("移动目的点")]
        public double DestZ { get; set; } = 0;

        #endregion
    }
}
