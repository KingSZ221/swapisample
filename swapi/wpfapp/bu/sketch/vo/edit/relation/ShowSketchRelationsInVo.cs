using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.edit.relation
{
    /// <summary>
    /// 显示隐藏草图约束关系
    /// </summary>
    [DisplayName("显示隐藏草图约束关系")]
    public class ShowSketchRelationsInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 显示隐藏
        /// </summary>
        [DisplayName("显示隐藏")]
        [Description("ture-显示，false-隐藏")]
        public bool Show { get; set; } = false;

        #endregion
    }
}
