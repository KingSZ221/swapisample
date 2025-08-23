using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.vo
{
    public class NewDocInVo
    {
        /// <summary>
        /// 文档类型,可选值
        /// 零件 = 1,
        /// 装配体 = 2,
        /// 工程图 = 3,
        /// </summary>
        public int DocType { get; set; }

        public swUserPreferenceStringValue_e getSwDefaultTemplateType()
        {
            switch (DocType)
            {
                case 1:
                    return swUserPreferenceStringValue_e.swDefaultTemplatePart;
                case 2:
                    return swUserPreferenceStringValue_e.swDefaultTemplateAssembly;
                case 3:
                    return swUserPreferenceStringValue_e.swDefaultTemplateDrawing;
                default:
                    return swUserPreferenceStringValue_e.swDefaultTemplatePart;
            }
        }
    }
}
