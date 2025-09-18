using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.sketch.vo.rect
{
    /// <summary>
    /// 绘制矩形信息
    /// </summary>
    [DisplayName("绘制矩形信息")]
    public class CreateRectangleOutVo
    {
        #region Fields

        /// <summary>
        /// 矩形边集合
        /// </summary>
        [DisplayName("矩形边集合")]
        [Category("实体")]
        public List<SketchLineInfo> Lines { get; set; } = new List<SketchLineInfo>();

        #endregion
    }
}
