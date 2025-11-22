using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.feature.vo.feature.hole
{
    /// <summary>
    /// 异形孔类型
    /// </summary>
    [Description("异形孔类型")]
    public enum swWzdGeneralHoleTypes_ext
    {
        [Description("柱形沉头孔")]
        swWzdCounterBore = 0,

        [Description("锥形沉头孔")]
        swWzdCounterSink = 1,

        [Description("孔")]
        swWzdHole = 2,

        [Description("锥形螺纹孔")]
        swWzdPipeTap = 3,

        [Description("直螺纹孔")]
        swWzdTap = 4,

        [Description("旧制孔")]
        swWzdLegacy = 5,

        [Description("柱孔槽口")]
        swWzdCounterBoreSlot = 6,

        [Description("锥孔槽口")]
        swWzdCounterSinkSlot = 7,

        [Description("槽口")]
        swWzdHoleSlot = 8
    }
}
