using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.cmd
{
    public class SwCmdGroupType
    {
        #region Fields

        /// <summary>
        /// 命令类型ID
        /// </summary>
        public int CmdTypeId { get; set; }

        /// <summary>
        /// 命令名称
        /// </summary>
        public string CmdTypeName { get; set; }

        /// <summary>
        /// 命令组描述
        /// </summary>
        public string CmdGroupName { get; set; }

        /// <summary>
        /// 命令描述
        /// </summary>
        public string CdmDesc { get; set; }

        /// <summary>
        /// 子命令
        /// </summary>
        public List<SwCmdType> SubCmds { get; set; } = new List<SwCmdType>();

        #endregion
    }
}
