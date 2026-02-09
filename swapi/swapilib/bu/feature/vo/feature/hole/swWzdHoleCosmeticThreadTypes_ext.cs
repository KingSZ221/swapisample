using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.feature.vo.feature.hole
{
    /// <summary>
    /// 装饰螺纹线类型
    /// </summary>
    public enum swWzdHoleCosmeticThreadTypes_ext
    {
        [Description("None ")]
        swCosmeticThreadNone = 0,

        [Description("WithCallout")]
        swCosmeticThreadWithCallout = 1,

        [Description("WithoutCallout")]
        swCosmeticThreadWithoutCallout = 2
    }
}
