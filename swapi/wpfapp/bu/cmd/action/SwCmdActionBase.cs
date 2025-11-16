using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.basic.io;

namespace wpfapp.bu.cmd.action
{
    /// <summary>
    /// SW命令接口
    /// </summary>
    public class SwCmdActionBase
    {
        #region Fields

        /// <summary>
        /// 命令参数
        /// </summary>
        private object _cmdInVo = null;

        #endregion

        #region Construction

        public SwCmdActionBase()
        {

        }

        #endregion

        #region excuete

        public object CmdInVo 
        { 
            get { return _cmdInVo; }
            set { _cmdInVo = value; }
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <returns>RespVo</returns>
        public virtual RespVo execute()
        {
            return RespVoLogExt.genError("未实现");
        }

        #endregion
    }
}
