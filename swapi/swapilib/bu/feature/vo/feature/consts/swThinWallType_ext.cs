using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.feature.vo.feature.consts
{
    /// <summary>
    /// 薄壁类型
    /// </summary>
    [Description("薄壁类型")]
    public enum swThinWallType_ext
    {
        [Description("两侧对称")]
        swThinWallMidPlane = 2,

        [Description("单向")]
        swThinWallOneDirection = 0,

        [Description("单向反向")]
        swThinWallOppDirection = 1,

        [Description("双向")]
        swThinWallTwoDirection = 3
    }
}
