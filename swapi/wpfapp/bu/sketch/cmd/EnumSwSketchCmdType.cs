using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo;
using wpfapp.bu.sketch.vo.draw.arc;
using wpfapp.bu.sketch.vo.draw.circle;
using wpfapp.bu.sketch.vo.draw.ellipse;
using wpfapp.bu.sketch.vo.entity;
using wpfapp.bu.sketch.vo.edit.fillet;
using wpfapp.bu.sketch.vo.draw.point;
using wpfapp.bu.sketch.vo.draw.polygon;
using wpfapp.bu.sketch.vo.draw.rect;
using wpfapp.bu.sketch.vo.sketch;
using wpfapp.bu.sketch.vo.draw.slot;
using wpfapp.bu.sketch.vo.draw.spline;
using wpfapp.bu.sketch.vo.draw.text;
using wpfapp.basic.io;
using wpfapp.bu.sketch.vo.draw.line;
using wpfapp.bu.vo.compose.pipe;
using wpfapp.bu.sketch.vo.edit.trim;
using wpfapp.bu.sketch.vo.draw.define;
using wpfapp.bu.sketch.vo.compose.ladder;
using wpfapp.bu.feature.vo.feature.extrusion;
using wpfapp.bu.sketch.vo.edit.extend;
using wpfapp.bu.sketch.action.sketch;
using wpfapp.bu.sketch.action.entity;
using wpfapp.bu.sketch.action.draw.line;
using wpfapp.bu.sketch.action.draw.rect;
using wpfapp.bu.sketch.action.draw.slot;
using wpfapp.bu.sketch.action.draw.circle;
using wpfapp.bu.sketch.action.draw.arc;
using wpfapp.bu.sketch.action.draw.polygon;
using wpfapp.bu.sketch.action.draw.spline;
using wpfapp.bu.sketch.action.draw.ellipse;
using wpfapp.bu.sketch.action.draw.text;
using wpfapp.bu.sketch.action.draw.point;
using wpfapp.bu.sketch.action.edit.fillet;
using wpfapp.bu.sketch.action.edit.trim;
using wpfapp.bu.sketch.action.edit.extend;
using wpfapp.bu.sketch.action.draw.define;
using wpfapp.bu.feature.action.feature.extrusion;
using wpfapp.bu.sketch.action.compose.pipe;
using wpfapp.bu.sketch.action.compose.ladder;
using wpfapp.bu.sketch.vo.edit.offset;
using wpfapp.bu.sketch.action.edit.offset;
using wpfapp.bu.sketch.vo.edit.repeat;
using wpfapp.bu.sketch.action.edit.repeat;
using wpfapp.bu.sketch.vo.edit.mirror;
using wpfapp.bu.sketch.vo.edit.copy;
using wpfapp.bu.sketch.action.edit.mirror;
using wpfapp.bu.sketch.action.edit.copy;
using wpfapp.bu.sketch.vo.edit.relation;
using wpfapp.bu.sketch.action.edit.relation;
using wpfapp.bu.feature.vo.feature.revolve;
using wpfapp.bu.feature.action.feature.revolve;
using wpfapp.bu.sketch.vo.compose.cube;
using wpfapp.bu.sketch.action.compose.cube;
using wpfapp.bu.feature.vo.feature.sweep;
using wpfapp.bu.feature.vo.feature.loft;
using wpfapp.bu.feature.action.feature.sweep;
using wpfapp.bu.feature.action.feature.loft;
using wpfapp.bu.cmd.cmdtype;
using wpfapp.bu.sketch.vo.select;
using wpfapp.bu.sketch.action.select;
using wpfapp.bu.sketch.vo.view;
using wpfapp.bu.sketch.action.view;

namespace wpfapp.bu.sketch.action
{
    /// <summary>
    /// 草图命令类型
    /// </summary>
    public enum EnumSwSketchCmdType
    {
        [SwCmdType("None", "None", typeof(Object), typeof(Object))]
        None = 0,

        [SwCmdType("插入草图", "编辑草图", typeof(InsertSketchInVo), typeof(InsertSketchAction))]
        InsertSketch = 1,

        [SwCmdType("草图绘制", "编辑草图", typeof(EditSketchInVo), typeof(EditSketchAction))]
        EditSketch,

        [SwCmdType("退出草图", "退出草图编辑", typeof(ExitSketchInVo), typeof(ExitSketchAction))]
        ExitSketch,

        [SwCmdType("清空选择对象列表", "清空选择对象列表", typeof(ClearSelectionInVo), typeof(ClearSelectionAction))]
        ClearSelection,

        [SwCmdType("通过名称或位置选中对象", "通过名称或位置选中对象", typeof(SelectByIDInVo), typeof(SelectByIDAction))]
        SelectByID,

        [SwCmdType("通过射线选中对象", "通过射线选中对象", typeof(SelectByRayInVo), typeof(SelectByRayAction))]
        SelectByRay,

        [SwCmdType("获取草图实体", "获取草图实体", typeof(GetSketchEntityInfoInVo), typeof(GetSketchEntityInfoAction))]
        GetSketchEntityInfo,

        [SwCmdType("绘制直线", "绘制直线", typeof(CreateLineInVo), typeof(CreateLineAction))]
        CreateLine,

        [SwCmdType("绘制中心直线", "绘制中心直线", typeof(CreateCenterLineInVo), typeof(CreateCenterLineAction))]
        CreateCenterLine,

        [SwCmdType("绘制边角矩形", "绘制边角矩形", typeof(CreateCornerRectangleInVo), typeof(CreateCornerRectangleAction))]
        CreateCornerRectangle,

        [SwCmdType("绘制中心矩形", "绘制中心矩形", typeof(CreateCenterRectangleInVo), typeof(CreateCenterRectangleAction))]
        CreateCenterRectangle,

        [SwCmdType("绘制3点边角矩形", "绘制3点边角矩形", typeof(Create3PointCornerRectangleInVo), typeof(Create3PointCornerRectangleAction))]
        Create3PointCornerRectangle,

        [SwCmdType("绘制3点中心矩形", "绘制3点中心矩形", typeof(Create3PointCenterRectangleInVo), typeof(Create3PointCenterRectangleAction))]
        Create3PointCenterRectangle,

        [SwCmdType("绘制平行四边形", "绘制平行四边形", typeof(CreateParallelogramInVo), typeof(CreateParallelogramAction))]
        CreateParallelogram,

        [SwCmdType("绘制直槽口", "绘制直槽口", typeof(CreateSketchSlotLineInVo), typeof(CreateSketchSlotLineAction))]
        CreateSketchSlot_line,

        [SwCmdType("绘制中心点直槽口", "绘制中心点直槽口", typeof(CreateSketchSlotCenterLineInVo), typeof(CreateSketchSlotCenterLineAction))]
        CreateSketchSlot_center_line,

        [SwCmdType("绘制三点圆弧槽口", "绘制三点圆弧槽口", typeof(CreateSketchSlot3PointArcInVo), typeof(CreateSketchSlot3PointArcAction))]
        CreateSketchSlot_3pointarc,

        [SwCmdType("绘制中心点圆弧槽口", "绘制中心点圆弧槽口", typeof(CreateSketchSlotArcInVo), typeof(CreateSketchSlotArcAction))]
        CreateSketchSlot_arc,

        [SwCmdType("绘制半径圆", "绘制半径圆", typeof(CreateCircleByRadiusInVo), typeof(CreateCircleByRadiusAction))]
        CreateCircleByRadius, 

        [SwCmdType("绘制圆", "绘制圆", typeof(CreateCircleInVo), typeof(CreateCircleAction))]
        CreateCircle,

        [SwCmdType("绘制周边圆", "绘制周边圆", typeof(PerimeterCircleInVo), typeof(PerimeterCircleAction))]
        PerimeterCircle,

        [SwCmdType("绘制圆心/起/终点画弧", "绘制圆心/起/终点画弧", typeof(CreateArcInVo), typeof(CreateArcAction))]
        CreateArc,

        [SwCmdType("绘制切线弧", "绘制切线弧", typeof(CreateTangentArcInVo), typeof(CreateTangentArcAction))]
        CreateTangentArc,

        [SwCmdType("绘制3点圆弧", "绘制3点圆弧", typeof(Create3PointArcInVo), typeof(Create3PointArcAction))]
        Create3PointArc,

        [SwCmdType("绘制多边形", "绘制多边形", typeof(CreatePolygonInVo), typeof(CreatePolygonAction))]
        CreatePolygon,

        [SwCmdType("绘制B样条曲线", "绘制B样条曲线", typeof(CreateSplineInVo), typeof(CreateSplineAction))]
        CreateSpline,

        [SwCmdType("绘制方程式驱动曲线", "绘制方程式驱动曲线", typeof(CreateEquationSplineInVo), typeof(CreateEquationSplineAction))]
        CreateEquationSpline,

        [SwCmdType("绘制椭圆", "绘制椭圆", typeof(CreateEllipseInVo), typeof(CreateEllipseAction))]
        CreateEllipse,

        [SwCmdType("绘制部分椭圆", "绘制部分椭圆", typeof(CreateEllipticalArcInVo), typeof(CreateEllipticalArcAction))]
        CreateEllipticalArc,

        [SwCmdType("绘制抛物线", "绘制抛物线", typeof(CreateParabolaInVo), typeof(CreateParabolaAction))]
        CreateParabola,

        [SwCmdType("绘制圆锥", "绘制圆锥", typeof(CreateConicInVo), typeof(CreateConicAction))]
        CreateConic,

        [SwCmdType("绘制文本", "绘制文本", typeof(InsertSketchTextInVo), typeof(InsertSketchTextAction))]
        InsertSketchText,

        [SwCmdType("绘制点", "绘制点", typeof(CreatePointInVo), typeof(CreatePointAction))]
        CreatePoint,

        [SwCmdType("绘制圆角", "绘制圆角", typeof(CreateFilletInVo), typeof(CreateFilletAction))]
        CreateFillet,

        [SwCmdType("绘制导角", "绘制导角", typeof(CreateChamferInVo), typeof(CreateChamferAction))]
        CreateChamfer,

        [SwCmdType("裁剪实体", "裁剪实体", typeof(SketchTrimInVo), typeof(SketchTrimAction))]
        SketchTrim,

        [SwCmdType("延伸实体", "延伸实体", typeof(SketchExtendInVo), typeof(SketchExtendAction))]
        [Description("会增加所选草图实体（即直线、中心线或弧）的长度，以使其与最近的草图实体相交")]
        SketchExtend,

        [SwCmdType("偏移实体", "偏移实体", typeof(SketchOffsetInVo), typeof(SketchOffsetAction))]
        [Description("对所选的草图实体进行偏移操作")]
        SketchOffset,

        [SwCmdType("线性阵列", "线性阵列", typeof(CreateLinearSketchStepAndRepeatInVo), typeof(CreateLinearSketchStepAndRepeatAction))]
        [Description("对所选的草图实体进行线性阵列")]
        CreateLinearSketchStepAndRepeat,

        [SwCmdType("圆周阵列", "圆周阵列", typeof(CreateCircularSketchStepAndRepeatInVo), typeof(CreateCircularSketchStepAndRepeatAction))]
        [Description("对所选的草图实体进行圆周阵列")]
        CreateCircularSketchStepAndRepeat,

        [SwCmdType("镜像实体", "镜像实体", typeof(SketchMirrorInVo), typeof(SketchMirrorAction))]
        [Description("对所选的草图实体进行镜像操作")]
        SketchMirror,

        [SwCmdType("移动复制实体", "移动复制实体", typeof(MoveOrCopyInVo), typeof(MoveOrCopyAction))]
        [Description("对所选的草图实体进行移动或复制操作")]
        MoveOrCopy,

        [SwCmdType("旋转复制实体", "旋转复制实体", typeof(RotateOrCopyInVo), typeof(RotateOrCopyAction))]
        [Description("对所选的草图实体进行旋转或复制操作")]
        RotateOrCopy,

        [SwCmdType("显示隐藏草图约束关系", "显示隐藏草图约束关系", typeof(ShowSketchRelationsInVo), typeof(ShowSketchRelationsAction))]
        [Description("显示隐藏草图约束关系")]
        ShowSketchRelations,

        [SwCmdType("添加草图约束关系", "添加草图约束关系", typeof(SketchAddConstraintsInVo), typeof(SketchAddConstraintsAction))]
        [Description("添加草图约束关系")]
        SketchAddConstraints,

        [SwCmdType("标注草图尺寸", "标注草图尺寸", typeof(AddDimensionInVo), typeof(AddDimensionAction))]
        [Description("标注草图尺寸")]
        AddDimension,

        [SwCmdType("完全草图定义", "完全草图定义", typeof(FullyDefineSketchInVo), typeof(FullyDefineSketchAction))]
        FullyDefineSketch,

        [SwCmdType("显示视图", "显示视图", typeof(ShowNamedViewInVo), typeof(ShowNamedViewAction))]
        ShowNamedView,

        [SwCmdType("绘制圆管", "绘制圆管", typeof(CreateCirclePipeInVo), typeof(CreateCirclePipeAction))]
        CreateCirclePipe,

        [SwCmdType("绘制立方体", "绘制立方体", typeof(CreateCubeInVo), typeof(CreateCubeAction))]
        CreateCube,

        [SwCmdType("绘制扶梯", "绘制扶梯", typeof(CreateLadderInVo), typeof(CreateLadderAction))]
        CreateLadder
    }
}
