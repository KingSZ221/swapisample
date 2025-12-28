using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.assembly.action.mate
{
    /// <summary>
    /// 创建零部件返回错误码
    /// </summary>
    public enum swAddMateError_ext
    {
        [Description("ErrorUknown")]
        swAddMateError_ErrorUknown = 0,

        [Description("NoError")]
        swAddMateError_NoError = 1,

        [Description("IncorrectMateType")]
        swAddMateError_IncorrectMateType = 2,

        [Description("IncorrectAlignment")]
        swAddMateError_IncorrectAlignment = 3,

        [Description("IncorrectSelections")]
        swAddMateError_IncorrectSelections = 4,

        [Description("OverDefinedAssembly")]
        swAddMateError_OverDefinedAssembly = 5,

        [Description("IncorrectGearRatios")]
        swAddMateError_IncorrectGearRatios = 6
    }
}

