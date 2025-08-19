using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.vo
{
    public class OpenDocInVo
    {
        /// <summary>
        /// 文档类型,可选值
        /// 零件 = 1,
        /// 装配体 = 2,
        /// 工程图 = 3,
        /// </summary>
        public int DocType { get; set; }

        public swDocumentTypes_e getSwDocType()
        {
            switch(DocType)
            {
                case 1:
                    return swDocumentTypes_e.swDocPART;
                case 2:
                    return swDocumentTypes_e.swDocASSEMBLY;
                case 3:
                    return swDocumentTypes_e.swDocDRAWING;
                default:
                    return swDocumentTypes_e.swDocPART;
            }
        }

        public string getTestDocName()
        {
            switch (DocType)
            {
                case 1:
                    return "零件测试1.SLDPRT";
                case 2:
                    return "装配体测试1.SLDASM";
                case 3:
                    return "工程图测试1.SLDDRW";
                default:
                    return "零件测试1.SLDPRT";
            }
        }
    }
}
