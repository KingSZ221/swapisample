using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.cmd.cmdtype;
using swapilib.bu.file.action;
using swapilib.bu.file.vo;

namespace swapilib.bu.file.cmd
{
    /// <summary>
    /// 文档命令类型
    /// </summary>
    public enum EnumSwDocCmdType
    {
        [SwCmdType("None", "None", "", typeof(Object), typeof(Object))]
        None = 0,

        [SwCmdType("新建文档", "新建文档", "", typeof(NewDocInVo), typeof(NewDocAction))]
        [Description("新建文档")]
        NewDoc,

        [SwCmdType("打开文档", "打开文档", "", typeof(OpenDocInVo), typeof(OpenDocAction))]
        [Description("打开文档")]
        OpenDoc,

        [SwCmdType("保存文档", "保存文档", "", typeof(SaveDocInVo), typeof(SaveDocAction))]
        [Description("保存文档")]
        SaveDoc,

        [SwCmdType("另存文档", "另存文档", "", typeof(SaveAsDocInVo), typeof(SaveAsDocAction))]
        [Description("另存文档")]
        SaveAsDoc,

        [SwCmdType("关闭文档", "关闭文档", "", typeof(CloseDocInVo), typeof(CloseDocAction))]
        [Description("关闭文档")]
        CloseDoc,

        [SwCmdType("导出文档", "导出文档", "", typeof(ExportDocInVo), typeof(ExportDocAction))]
        [Description("导出文档")]
        ExportDoc
    }
}
