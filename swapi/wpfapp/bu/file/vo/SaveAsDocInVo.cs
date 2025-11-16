using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.file.vo
{
    public class SaveAsDocInVo
    {
        /// <summary>
        /// 要保存的文档标题，如果传空字符串，则是当前文档
        /// </summary>
        public string DocTitle { get; set; }

        /// <summary>
        /// 另存为的文档标题，不含后缀
        /// </summary>
        public string SaveAsDocTitle { get; set; }
    }
}
