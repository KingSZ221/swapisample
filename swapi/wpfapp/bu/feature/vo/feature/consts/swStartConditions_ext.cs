using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.feature.vo.feature.consts
{
    /// <summary>
    /// 开始条件
    /// </summary>
    public enum swStartConditions_ext
    {
        [Description("等距")]
        swStartOffset = 3,

        [Description("草图基准面")]
        swStartSketchPlane = 0,

        [Description("曲面/面/基准平面")]
        swStartSurface = 1,

        [Description("顶点")]
        swStartVertex = 2
    }
}
