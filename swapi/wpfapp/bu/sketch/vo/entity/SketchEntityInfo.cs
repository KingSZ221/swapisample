using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.entity
{
    /// <summary>
    /// 草图内部实体
    /// </summary>
    [DisplayName("草图实体信息")]
    public class SketchEntityInfo
    {
        #region Fields

        /// <summary>
        /// 边集合
        /// </summary>
        [DisplayName("段集合")]
        [Category("实体")]
        public List<SketchSegmentInfo> Segments { get; set; }

        /// <summary>
        /// 顶点集合
        /// </summary>
        [DisplayName("顶点集合")]
        [Category("实体")]
        public List<SketchPointInfo> Points { get; set; }

        #endregion
    }
}
