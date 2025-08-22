using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.vo
{
    /// <summary>
    /// 导出文档参数
    /// </summary>
    public class ExportDocInVo
    {
        /// <summary>
        /// 导出文档标题，如果传空字符串，则是当前文档
        /// </summary>
        public string DocTitle { get; set; }

        /// <summary>
        /// 导出文档类型
        /// 可选值:1-dxf，2-svg，3-igs
        /// </summary>
        public int ExportFileType { get; set; }
    }
}
