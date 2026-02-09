using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.basic.io;
using swapilib.bu.file.export;
using swapilib.bu.file.vo;
using swapilib.bu.log;

namespace swapilib.bu.file.action
{
    /// <summary>
    /// 关闭文档:零件、装配图、工程图
    /// </summary>
    public class ExportDocAction : SwDocActionBase
    {
        #region Fields

        #endregion

        #region Construction

        public ExportDocAction()
        {

        }

        #endregion

        #region execute

        protected override RespVo onExecute()
        {
            // 获取命令参数
            ExportDocInVo oInVo = this.actionInVo<ExportDocInVo>();

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

            if (oInVo.ExportFileType == 1)
            {
                // 导出dxf
                return SwDocExportUtils.exportDxf(swApp.Sw, doc);
            }
            else if (oInVo.ExportFileType == 2)
            {
                // 导出svg
                return SwDocExportUtils.exportSvg(swApp.Sw, doc);
            }
            else if (oInVo.ExportFileType == 3)
            {
                // 导出Iges
                return SwDocExportUtils.exportIges(swApp.Sw, doc);
            }
            else
            {
                return RespVoLogExt.genError("不支持导出该文件类型");
            }
        }

        #endregion

    }
}
