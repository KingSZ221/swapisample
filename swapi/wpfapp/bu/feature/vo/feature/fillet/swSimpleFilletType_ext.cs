using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.feature.vo.feature.fillet
{
    /// <summary>
    /// 圆角类型
    /// </summary>
    public enum swSimpleFilletType_ext
    {
        [Description("固定大小圆角")]
        swConstRadiusFillet = 0,

        [Description("面圆角")]
        swFaceFillet = 2,

        [Description("完整圆角")]
        swFullRoundFillet = 3
    }
}
