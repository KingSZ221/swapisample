using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.feature.vo.feature.fillet
{
    /// <summary>
    /// 倒角类型
    /// </summary>
    public enum swChamferType_ext
    {
        [Description("角度和距离")]
        swChamferAngleDistance = 1,

        [Description("距离和距离")]
        swChamferDistanceDistance = 2,

        [Description("顶点")]
        swChamferVertex = 3,

        [Description("等距离")]
        swChamferEqualDistance = 16
    }
}
