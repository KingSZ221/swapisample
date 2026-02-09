using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.feature.vo.feature.hole
{
    /// <summary>
    /// 异形孔标准
    /// </summary>
    [Description("异形孔标准")]
    public enum swWzdHoleStandards_ext
    {
        [Description("AnsiInch")]
        swStandardAnsiInch = 0,

        [Description("AnsiMetric")]
        swStandardAnsiMetric = 1,

        [Description("BSI")]
        swStandardBSI = 2,

        [Description("DME")]
        swStandardDME = 3,

        [Description("DIN")]
        swStandardDIN = 4,

        [Description("HascoMetric")]
        swStandardHascoMetric = 5,

        [Description("HelicoilInch")]
        swStandardHelicoilInch = 6,

        [Description("HelicoilMetric")]
        swStandardHelicoilMetric = 7,

        [Description("ISO")]
        swStandardISO = 8,

        [Description("JIS")]
        swStandardJIS = 9,

        [Description("PCS")]
        swStandardPCS = 10,

        [Description("Progressive")]
        swStandardProgressive = 11,

        [Description("Superior")]
        swStandardSuperior = 12,

        [Description("GB")]
        swStandardGB = 13,

        [Description("KS")]
        swStandardKS = 14,

        [Description("IS")]
        swStandardIS = 15,

        [Description("AS")]
        swStandardAS = 16,

        [Description("PEMInch")]
        swStandardPEMInch = 17,

        [Description("PEMMetric")]
        swStandardPEMMetric = 18
    }
}
