using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.feature.vo.feature.consts
{
    /// <summary>
    /// 结束条件
    /// </summary>
    public enum swEndConditions_ext
    {
        [Description("给定深度")]
        swEndCondBlind = 0,

        [Description("两侧对称")]
        swEndCondMidPlane = 6,

        [Description("到离指定面指定的距离")]
        swEndCondOffsetFromSurface = 5,

        [Description("完全贯穿(拉伸切除时)")]
        swEndCondThroughAll = 1,

        [Description("完全贯穿-两者(拉伸切除时)")]
        swEndCondThroughAllBoth = 9,

        [Description("贯穿到下一个面(拉伸切除时)")]
        swEndCondThroughNext = 2,

        [Description("成型到实体(拉伸凸台时)")]
        swEndCondUpToBody = 7,

        [Description("成型到下一个面(拉伸凸台时)")]
        swEndCondUpToNext = 11,

        [Description("成型到选中顶点或面")]
        swEndCondUpToSelection = 10
    }

}
