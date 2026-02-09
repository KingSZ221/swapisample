using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.app;
using swapilib.bu.cmd;
using swapilib.bu.cmd.cmdtype;
using swapilib.bu.feature.cmd;
using swapilib.bu.log;
using swapilib.bu.sketch.action;
using swapilib.bu.sketch.vo;
using swapilib.basic.io;
using Xarial.XCad.SolidWorks;

namespace swapilib.bu.sketch
{
    /// <summary>
    /// 草图服务
    /// </summary>
    public class SwBuSketchService
    {
        #region Fields

        private static SwBuSketchService _instance = new SwBuSketchService();

        /// <summary>
        /// 模块名称
        /// </summary>
        public const string MoudleName = "sketch";

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuSketchService() 
        {
            
        }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuSketchService getInstance()
        {
            return _instance;
        }

        #endregion

        #region init

        public void init()
        {
            // 注册命令
            SwCmdTypeManager.getInstance().registCmds(MoudleName, typeof(EnumSwSketchCmdType));
        }

        #endregion

        #region app

        private ISwApplication swApp
        {
            get { return SwBuAppService.getInstance().getSwApp(); }
        }

        #endregion

        #region 草图绘制操作

        public RespVo executeCmdWithInVo(EnumSwSketchCmdType cmdType, object cmdInVo)
        {
            return SwBuCmdService.getInstance().executeCmdWithInVo(MoudleName, (int)cmdType, cmdInVo);
        }

        #endregion

    }
}
