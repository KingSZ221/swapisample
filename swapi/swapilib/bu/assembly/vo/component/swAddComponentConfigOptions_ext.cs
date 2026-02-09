using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.assembly.vo.component
{
    /// <summary>
    /// 添加零部件打开文档模式
    /// </summary>
    public enum swAddComponentConfigOptions_ext
    {
        [Description("CurrentSelectedConfig")]
        swAddComponentConfigOptions_CurrentSelectedConfig = 0,

        [Description("NewConfigWithAllReferenceModels")]
        swAddComponentConfigOptions_NewConfigWithAllReferenceModels = 1,

        [Description("NewConfigWithAsmStructure")]
        swAddComponentConfigOptions_NewConfigWithAsmStructure = 2
    }
}
