using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.assembly.vo.mate
{
    /// <summary>
    /// 添加零部件打开文档模式
    /// </summary>
    public enum swMateAlign_ext
    {
        [Description("ALIGNED")]
        swMateAlignALIGNED = 0,

        [Description("ANTI_ALIGNED")]
        swMateAlignANTI_ALIGNED = 1,

        [Description("CLOSEST")]
        swMateAlignCLOSEST = 2,
    }
}
