using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.feature.vo.feature.hole
{
    /// <summary>
    /// 螺钉套合类型
    /// </summary>
    public enum swWzdHoleScrewClearanceTypes_ext
    {
        [Description("紧密")]
        swScrewClearanceClose = 0,

        [Description("正常")]
        swScrewClearanceNormal = 1,

        [Description("松弛")]
        swScrewClearanceLoose = 2
    }
}
