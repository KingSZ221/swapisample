using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.app;
using wpfapp.bu.cmd.action;
using wpfapp.bu.log;
using wpfapp.basic.io;
using Xarial.XCad.SolidWorks;

namespace wpfapp.bu.file.action
{
    /// <summary>
    /// 文档操作基类
    /// </summary>
    public class SwDocActionBase : SwCmdActionBase
    {
        #region Fields

        /// <summary>
        /// SwApp
        /// </summary>
        private ISwApplication _swApp = null;

        #endregion

        #region Construction

        public SwDocActionBase()
        {

        }

        #endregion

        #region excute

        public override RespVo execute()
        {
            // 检查当前激活文档是否零件
            RespVo oRespVo = priCheckApp();
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            // 执行操作
            try
            {
                oRespVo = onExecute();
            }
            catch (Exception ex)
            {
                oRespVo = RespVoLogExt.genException(ex, "命令执行异常");
            }

            return oRespVo;
        }


        protected virtual RespVo onExecute()
        {
            return RespVoLogExt.genError("未实现");
        }

        #endregion

        #region get

        protected ISwApplication swApp
        {
            get
            {
                if (_swApp == null)
                {
                    _swApp = SwBuAppService.getInstance().getSwApp();
                }
                return _swApp;
            }
        }

        protected T actionInVo<T>()
        {
            if (CmdInVo != null)
            {
                return (T)CmdInVo;
            }
            return default(T);
        }

        #endregion

        #region 操作前准备

        /// <summary>
        /// 检查当前是否连接SolidWorks
        /// </summary>
        /// <returns>RespVo</returns>
        protected RespVo priCheckApp()
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            return RespVo.genOk();
        }

        #endregion
    }

}
