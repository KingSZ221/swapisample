using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.feature.vo.feature.consts
{
    /// <summary>
    /// 引导线感应类型
    /// </summary>
    [Description("引导线感应类型")]
    public enum swGuideCurveInfluence_ext
    {
        [Description("到下一引线")]
        swGuideCurveInfluenceNextGuide = 0,

        [Description("到下一尖角")]
        swGuideCurveInfluenceNextSharp = 1,

        [Description("到下一边线")]
        swGuideCurveInfluenceNextEdge = 2,

        [Description("整体")]
        swGuideCurveInfluenceNextGlobal = 3
    }
}
