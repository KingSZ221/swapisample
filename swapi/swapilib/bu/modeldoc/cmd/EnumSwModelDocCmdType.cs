using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.cmd.cmdtype;
using swapilib.bu.modeldoc.action.select;
using swapilib.bu.modeldoc.action.view;
using swapilib.bu.modeldoc.vo.select;
using swapilib.bu.modeldoc.vo.view;

namespace swapilib.bu.modeldoc.cmd
{
    /// <summary>
    /// 零件装配体文档通用操作命令类型
    /// </summary>
    public enum EnumSwModelDocCmdType
    {
        [SwCmdType("None", "None", "模型文档", typeof(Object), typeof(Object))]
        None = 0,

        [SwCmdType("清空选择对象列表", "清空选择对象列表", "选择对象", typeof(ClearSelectionInVo), typeof(ClearSelectionAction))]
        ClearSelection,

        [SwCmdType("通过名称或位置选中对象", "通过名称或位置选中对象", "选择对象", typeof(SelectByIDInVo), typeof(SelectByIDAction))]
        SelectByID,

        [SwCmdType("通过射线选中对象", "通过射线选中对象", "选择对象", typeof(SelectByRayInVo), typeof(SelectByRayAction))]
        SelectByRay,

        [SwCmdType("选中指定序号特征", "选中特征", "选择", typeof(SelectFeatureByPositionReverseInVo), typeof(SelectFeatureByPositionReverseAction))]
        [Description("选中指定序号特征")]
        SelectFeatureByPositionReverse,

        [SwCmdType("显示视图", "显示视图", "视图", typeof(ShowNamedViewInVo), typeof(ShowNamedViewAction))]
        ShowNamedView,

    }
}
