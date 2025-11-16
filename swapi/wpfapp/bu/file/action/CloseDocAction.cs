using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.file.vo;
using wpfapp.bu.log;

namespace wpfapp.bu.file.action
{
    /// <summary>
    /// 关闭文档:零件、装配图、工程图
    /// </summary>
    public class CloseDocAction : SwDocActionBase
    {
        #region Fields

        #endregion

        #region Construction

        public CloseDocAction()
        {

        }

        #endregion

        #region execute

        protected override RespVo onExecute()
        {
            // 获取命令参数
            CloseDocInVo oInVo = this.actionInVo<CloseDocInVo>();

            string strDocTitle = oInVo.DocTitle;
            if (string.IsNullOrEmpty(strDocTitle))
            {
                // 关闭当前文档
                //获取当前打开的文档
                var doc = swApp.Sw.IActiveDoc2;
                if (doc == null)
                {
                    return RespVoLogExt.genError("没有打开的文档"); ;
                }

                //获取当前打开文档标题
                strDocTitle = doc.GetTitle();
            }

            //关闭文档
            swApp.Sw.CloseDoc(strDocTitle);

            return RespVoLogExt.genOk($"关闭文档成功, {strDocTitle}");
        }

        #endregion
    }
}
