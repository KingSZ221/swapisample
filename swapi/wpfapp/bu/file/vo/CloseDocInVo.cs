using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.vo
{
    /// <summary>
    /// 关闭文档参数
    /// </summary>
    public class CloseDocInVo
    {
        /// <summary>
        /// 关闭文档标题，如果传空字符串，则是当前文档
        /// </summary>
        public string DocTitle { get; set; }
    }
}
