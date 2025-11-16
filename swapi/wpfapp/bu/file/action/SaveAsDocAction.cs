using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.app;
using wpfapp.bu.file.vo;
using wpfapp.bu.log;

namespace wpfapp.bu.file.action
{
    /// <summary>
    /// 另存为文档:零件、装配图、工程图
    /// </summary>
    public class SaveAsDocAction : SwDocActionBase
    {
        #region Fields

        #endregion

        #region Construction

        public SaveAsDocAction()
        {

        }

        #endregion

        #region execute

        protected override RespVo onExecute()
        {
            // 获取命令参数
            SaveAsDocInVo oInVo = this.actionInVo<SaveAsDocInVo>();

            ModelDoc2 doc = null;
            if (string.IsNullOrEmpty(oInVo.DocTitle))
            {
                //获取当前打开的文档
                doc = swApp.Sw.IActiveDoc2;
            }
            else
            {
                doc = swApp.Sw.GetOpenDocument(oInVo.DocTitle);
            }

            if (doc == null)
            {
                return RespVoLogExt.genError("文档没有打开");
            }

            // 获取文档文件路径
            string strDocPath = doc.GetPathName();
            string strDocFileName = doc.GetTitle();
            string strDocFileType = ".sldprt";
            switch ((swDocumentTypes_e)doc.GetType())
            {
                case swDocumentTypes_e.swDocPART:
                    strDocFileType = ".sldprt";
                    break;
                case swDocumentTypes_e.swDocASSEMBLY:
                    strDocFileType = ".sldasm";
                    break;
                case swDocumentTypes_e.swDocDRAWING:
                    strDocFileType = ".slddrw";
                    break;
                default:
                    strDocFileType = ".sldprt";
                    break;
            }
            strDocPath = SwBuAppService.getAppResFilePath(oInVo.SaveAsDocTitle + strDocFileType);
            int errors = 0;
            int warnings = 0;
            bool oOk = doc.Extension.SaveAs3(strDocPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, null, ref errors, ref warnings);
            if (!oOk)
            {
                return RespVoLogExt.genError($"保存文档失败，错误代码： {errors}");
            }

            return RespVoLogExt.genOk($"保存文档成功, {strDocPath}");
        }

        #endregion
    }
}
