using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.cmd.cmdtype;
using wpfapp.bu.modeldoc.action.select;
using wpfapp.bu.modeldoc.action.view;
using wpfapp.bu.modeldoc.vo.select;
using wpfapp.bu.modeldoc.vo.view;

namespace wpfapp.bu.modeldoc.cmd
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
