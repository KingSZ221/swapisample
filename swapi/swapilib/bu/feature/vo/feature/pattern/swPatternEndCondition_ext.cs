using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.feature.vo.feature.pattern
{
    /// <summary>
    /// 阵列终止条件类型
    /// </summary>
    public enum swPatternEndCondition_ext
    {
        [Description("间距与实例数")]
        swPatternEndCondition_SpacingAndInstances = 0,

        [Description("到参考")]
        swPatternEndCondition_UpToReference = 1
    }
}
