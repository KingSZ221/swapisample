using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.basic.io;
using swapilib.bu.app;
using swapilib.bu.assembly.cmd;
using swapilib.bu.cmd;
using swapilib.bu.cmd.cmdtype;
using Xarial.XCad.SolidWorks;

namespace swapilib.bu.assembly
{
    /// <summary>
    /// 装配体服务
    /// </summary>
    public class SwBuAssemblyService
    {
        #region Fields

        private static SwBuAssemblyService _instance = new SwBuAssemblyService();

        /// <summary>
        /// 模块名称
        /// </summary>
        public const string MoudleName = "assembly";

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuAssemblyService()
        {

        }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuAssemblyService getInstance()
        {
            return _instance;
        }

        #endregion

        #region init

        public void init()
        {
            // 注册命令
            SwCmdTypeManager.getInstance().registCmds(MoudleName, typeof(EnumSwAssemblyCmdType));
        }

        #endregion

        #region app

        private ISwApplication swApp
        {
            get { return SwBuAppService.getInstance().getSwApp(); }
        }

        #endregion

        #region 特征操作

        public RespVo executeCmdWithInVo(EnumSwAssemblyCmdType cmdType, object cmdInVo)
        {
            return SwBuCmdService.getInstance().executeCmdWithInVo(MoudleName, (int)cmdType, cmdInVo);
        }

        #endregion

    }
}
