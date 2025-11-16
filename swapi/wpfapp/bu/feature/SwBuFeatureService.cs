using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.app;
using wpfapp.bu.cmd;
using wpfapp.bu.cmd.cmdtype;
using wpfapp.bu.feature.cmd;
using wpfapp.basic.io;
using Xarial.XCad.SolidWorks;

namespace wpfapp.bu.feature
{
    /// <summary>
    /// 特征服务
    /// </summary>
    public class SwBuFeatureService
    {
        #region Fields

        private static SwBuFeatureService _instance = new SwBuFeatureService();

        /// <summary>
        /// 模块名称
        /// </summary>
        public const string MoudleName = "feature";

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuFeatureService()
        {

        }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuFeatureService getInstance()
        {
            return _instance;
        }

        #endregion

        #region init

        public void init()
        {
            // 注册命令
            SwCmdTypeManager.getInstance().registCmds(MoudleName, typeof(EnumSwFeatureCmdType));
        }

        #endregion

        #region app

        private ISwApplication swApp
        {
            get { return SwBuAppService.getInstance().getSwApp(); }
        }

        #endregion

        #region 特征操作

        public RespVo executeCmdWithInVo(EnumSwFeatureCmdType cmdType, object cmdInVo)
        {
            return SwBuCmdService.getInstance().executeCmdWithInVo(MoudleName, (int)cmdType, cmdInVo);
        }

        #endregion

    }
}
