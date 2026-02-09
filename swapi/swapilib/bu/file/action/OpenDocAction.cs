using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.file.vo;
using swapilib.basic.io;
using swapilib.bu.app;

namespace swapilib.bu.file.action
{
    /// <summary>
    /// 打开文档:零件、装配图、工程图
    /// </summary>
    public class OpenDocAction : SwDocActionBase
    {
        #region Fields

        #endregion

        #region Construction

        public OpenDocAction()
        {

        }

        #endregion

        #region execute

        protected override RespVo onExecute()
        {
            // 获取命令参数
            OpenDocInVo oInVo = this.actionInVo<OpenDocInVo>();

            string strDocPath = SwBuAppService.getAppResFilePath(oInVo.DocFileName);

            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            if (!File.Exists(strDocPath))
            {
                return RespVoLogExt.genError($"此文件不存在 {strDocPath}");
            }

            int errors = 0;
            int warnings = 0;

            var doc = swApp.Sw.OpenDoc6(strDocPath, oInVo.DocType, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            if (doc == null)
            {
                return RespVoLogExt.genError($"打开文档失败, {strDocPath} ，错误代码： {errors}");
            }
            return RespVoLogExt.genOk($"打开文档成功, {strDocPath}");
        }

        #endregion
    }
}
