using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.cmd.cmdtype
{
    /// <summary>
    /// 命令类型定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class SwCmdTypeAttribute : Attribute
    {
        /// <summary>
        /// 命令名称
        /// </summary>
        public string CmdName { get; }

        /// <summary>
        /// 命令描述
        /// </summary>
        public string CmdDesc { get; }

        /// <summary>
        /// 命令组
        /// </summary>
        public string CmdGroup { get; }

        /// <summary>
        /// 命令入参类型
        /// </summary>
        public Type CmdInVoType { get; }

        /// <summary>
        /// 命令动作类型
        /// </summary>
        public Type CmdActionType { get; }

        public SwCmdTypeAttribute(string cmdName, string cmdDesc, string cmdGroup, Type cmdInVoType, Type cmdActionType)
        {
            CmdName = cmdName;
            CmdDesc = cmdDesc;
            CmdInVoType = cmdInVoType;
            CmdActionType = cmdActionType;
            CmdGroup = cmdGroup;
        }
    }
}
