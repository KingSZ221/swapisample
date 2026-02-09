using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.basic.io;
using swapilib.bu.cmd;
using swapilib.bu.cmd.cmdtype;
using swapilib.bu.modeldoc.cmd;

namespace swapilib.bu.modeldoc
{
    /// <summary>
    /// 模型文档服务
    /// </summary>
    public class SwBuModelDocService
    {
        #region Fields

        private static SwBuModelDocService _instance = new SwBuModelDocService();

        /// <summary>
        /// 模块名称
        /// </summary>
        public const string MoudleName = "modeldoc";

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuModelDocService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuModelDocService getInstance()
        {
            return _instance;
        }

        #endregion

        #region init

        public void init()
        {
            // 注册命令
            SwCmdTypeManager.getInstance().registCmds(MoudleName, typeof(EnumSwModelDocCmdType));
        }

        #endregion

        #region 文档操作

        public RespVo executeCmdWithInVo(EnumSwModelDocCmdType cmdType, object cmdInVo)
        {
            return SwBuCmdService.getInstance().executeCmdWithInVo(MoudleName, (int)cmdType, cmdInVo);
        }

        #endregion
    }
}
