using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.basic.io;
using swapilib.bu.app;
using swapilib.bu.cmd;
using swapilib.bu.cmd.cmdtype;
using swapilib.bu.file.cmd;
using swapilib.bu.file.export;
using swapilib.bu.log;
using swapilib.bu.utils;
using Xarial.XCad.SolidWorks;

namespace swapilib.bu.file
{
    /// <summary>
    /// 文档服务
    /// </summary>
    public class SwBuFileService
    {
        #region Fields

        private static SwBuFileService _instance = new SwBuFileService();

        /// <summary>
        /// 模块名称
        /// </summary>
        public const string MoudleName = "doc";

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuFileService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuFileService getInstance()
        {
            return _instance;
        }

        #endregion

        #region init

        public void init()
        {
            // 注册命令
            SwCmdTypeManager.getInstance().registCmds(MoudleName, typeof(EnumSwDocCmdType));
        }

        #endregion

        #region 文档操作

        public RespVo executeCmdWithInVo(EnumSwDocCmdType cmdType, object cmdInVo)
        {
            return SwBuCmdService.getInstance().executeCmdWithInVo(MoudleName, (int)cmdType, cmdInVo);
        }

        #endregion
    }
}

