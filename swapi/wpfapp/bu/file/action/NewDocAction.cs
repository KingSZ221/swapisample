using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.file.vo;
using wpfapp.bu.log;

namespace wpfapp.bu.file.action
{
    /// <summary>
    /// 新建文档:零件、装配图、工程图
    /// </summary>
    public class NewDocAction : SwDocActionBase
    {
        #region Fields

        #endregion

        #region Construction

        public NewDocAction()
        {

        }

        #endregion

        #region execute

        protected override RespVo onExecute()
        {
            // 获取命令参数
            NewDocInVo oInVo = this.actionInVo<NewDocInVo>();

            var template = swApp.Sw.GetUserPreferenceStringValue((int)oInVo.getSwDefaultTemplateType());
            if (!File.Exists(template))
            {
                return RespVoLogExt.genError("未配置默认模板，无法新建文档");
            }

            var doc = swApp.Sw.INewDocument2(template, 0, 300d, 300d);

            return RespVoLogExt.genOk($"新建文档成功，标题: {doc.GetTitle()}");
        }

        #endregion
    }
}
