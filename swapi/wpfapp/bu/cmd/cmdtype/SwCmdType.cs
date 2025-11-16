using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.cmd.cmdtype
{
    /// <summary>
    /// 命令类型:命令模块名称和命令类型ID作为唯一命令标识
    /// </summary>
    public class SwCmdType
    {
        #region Fields

        /// <summary>
        /// 命令模块名称
        /// </summary>
        public string CmdModule { get; set; }

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
        /// 系统命令的操作入参类型
        /// </summary>
        public Type ActionInVoType { get; set; }

        /// <summary>
        /// 系统命令的操作动作类型
        /// </summary>
        public Type ActionType { get; set; }

        #endregion
    }
}
