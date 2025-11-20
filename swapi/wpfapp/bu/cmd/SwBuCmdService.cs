using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.cmd.action;
using wpfapp.bu.cmd.cmdtype;
using wpfapp.bu.log;
using wpfapp.ui.prop;

namespace wpfapp.bu.cmd
{
    /// <summary>
    /// 命令服务
    /// </summary>
    public class SwBuCmdService
    {
        #region Fields

        private static SwBuCmdService _instance = new SwBuCmdService();

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuCmdService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuCmdService getInstance()
        {
            return _instance;
        }

        #endregion

        #region regist

        public void registCmd()
        {

        }

        #endregion

        #region execute

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmdModule">命令模块</param>
        /// <param name="cmdTypeId">命令类型ID</param>
        /// <param name="cmdInVo">命令参数</param>
        /// <returns>RespVo</returns>
        public RespVo executeCmdWithInVo(string cmdModule, int cmdTypeId, object cmdInVo)
        {
            SwCmdType cmdType = SwCmdTypeManager.getInstance().getByTypeId(cmdModule, cmdTypeId);
            if (cmdType == null)
            {
                return RespVoLogExt.genError($"未找到命令: {cmdModule} {cmdTypeId}");
            }

            return executeCmdWithInVo(cmdType, cmdInVo);
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmdModule">命令模块</param>
        /// <param name="cmdTypeId">命令类型ID</param>
        /// <param name="cmdInVo">命令参数</param>
        /// <returns>RespVo</returns>
        public RespVo executeCmdWithInVo2(string cmdModule, string cmdTypeIdStr, object cmdInVo)
        {
            SwCmdType cmdType = SwCmdTypeManager.getInstance().getByTypeIdStr(cmdModule, cmdTypeIdStr);
            if (cmdType == null)
            {
                return RespVoLogExt.genError($"未找到命令: {cmdModule} {cmdTypeIdStr}");
            }

            return executeCmdWithInVo(cmdType, cmdInVo);
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdInVo">命令参数</param>
        /// <returns>RespVo</returns>
        public RespVo executeCmdWithInVo(SwCmdType cmdType, object cmdInVo)
        {
            Type actionObjType = cmdType.ActionType;
            if (actionObjType == null)
            {
                return RespVoLogExt.genError($"不支持的命令: {cmdType.CmdTypeName}");
            }

            // 获取特定构造函数（参数为object）
            ConstructorInfo ctor = actionObjType.GetConstructor(Type.EmptyTypes);
            if (ctor == null)
            {
                return RespVoLogExt.genError($"构造命令异常: {cmdType.CmdTypeName}");
            }

            // 准备参数
            object[] parameters = new object[] {};

            // 调用构造函数创建实例
            object actionObj = ctor.Invoke(parameters);
            if (actionObj == null)
            {
                return RespVoLogExt.genError($"构造命令异常: {cmdType.CmdTypeName}");
            }

            SwCmdActionBase swActionBase = (SwCmdActionBase)actionObj;
            if (swActionBase == null)
            {
                return RespVoLogExt.genError($"构造命令异常, {cmdType.CmdTypeName}");
            }

            RespVo oRespVo = null;
            try
            {
                // 初始化命令参数
                swActionBase.CmdInVo = cmdInVo;

                // 执行命令
                oRespVo = swActionBase.execute();
            }
            catch (Exception ex)
            {
                oRespVo = RespVoLogExt.genException(ex, $"执行命令异常, {cmdType.CmdTypeName}");
            }
            return oRespVo;
        }

        #endregion
    }
}
