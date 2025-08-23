using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.vo
{
    public class SaveDocInVo
    {
        /// <summary>
        /// 保存文档标题，如果传空字符串，则是当前文档
        /// </summary>
        public string DocTitle { get; set; }

        ///// <summary>
        ///// 保存文档文件路径
        ///// </summary>
        //public string SaveDocFilePath { get; set; }
    }
}
