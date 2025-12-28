using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.assembly.action.component;
using wpfapp.bu.assembly.action.mate;
using wpfapp.bu.assembly.vo.component;
using wpfapp.bu.assembly.vo.mate;
using wpfapp.bu.cmd.cmdtype;

namespace wpfapp.bu.assembly.cmd
{
    /// <summary>
    /// 装配体命令类型
    /// </summary>
    public enum EnumSwAssemblyCmdType
    {
        [SwCmdType("None", "None", "装配体", typeof(Object), typeof(Object))]
        None = 0,

        [SwCmdType("装配体插入单个零部件", "装配体插入单个零部件", "零部件", typeof(AddComponentInVo), typeof(AddComponentAction))]
        [Description("装配体插入单个零部件")]
        AddComponent,

        [SwCmdType("装配体插入多个零部件", "装配体插入多个零部件", "零部件", typeof(AddComponentsInVo), typeof(AddComponentsAction))]
        [Description("装配体插入多个零部件")]
        AddComponents,

        [SwCmdType("固定零部件", "固定零部件", "零部件", typeof(FixComponentInVo), typeof(FixComponentAction))]
        [Description("操作前需先选中1个零部件")]
        FixComponent,

        [SwCmdType("浮动零部件", "浮动零部件", "零部件", typeof(UnfixComponentInVo), typeof(UnfixComponentAction))]
        [Description("操作前需先选中1个零部件")]
        UnfixComponent,

        [SwCmdType("创建重合配合", "创建重合配合", "重合", typeof(CreateMateCoincidentInVo), typeof(CreateMateCoincidentAction))]
        [Description("操作前需先选中2个重合对象")]
        CreateMateCoincident
    }
}
