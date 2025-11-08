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
using wpfapp.bu.vo;
using wpfapp.bu.sketch.vo.draw.line;
using wpfapp.bu.vo.compose.pipe;
using wpfapp.bu.sketch.vo.edit.trim;
using wpfapp.bu.sketch.vo.draw.define;
using wpfapp.bu.sketch.vo.compose.ladder;
using wpfapp.bu.sketch.vo.feature.extrusion;
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
using wpfapp.bu.sketch.action.feature.extrusion;
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
using wpfapp.bu.sketch.vo.feature.revolve;
using wpfapp.bu.sketch.action.feature.revolve;
using wpfapp.bu.sketch.vo.compose.cube;
using wpfapp.bu.sketch.action.compose.cube;

namespace wpfapp.bu.sketch.action
{
    /// <summary>
    /// 草图操作类型
    /// </summary>
    public enum EnumSwSketchActionType
    {
        [SwSketchAction("草图绘制", "编辑草图", typeof(EditSketchInVo), typeof(EditSketchAction))]
        EditSketch = 1,

        [SwSketchAction("退出草图", "退出草图编辑", typeof(ExitSketchInVo), typeof(ExitSketchAction))]
        ExitSketch,

        [SwSketchAction("获取草图实体", "获取草图实体", typeof(GetSketchEntityInfoInVo), typeof(GetSketchEntityInfoAction))]
        GetSketchEntityInfo,

        [SwSketchAction("绘制直线", "绘制直线", typeof(CreateLineInVo), typeof(CreateLineAction))]
        CreateLine,

        [SwSketchAction("绘制中心直线", "绘制中心直线", typeof(CreateCenterLineInVo), typeof(CreateCenterLineAction))]
        CreateCenterLine,

        [SwSketchAction("绘制边角矩形", "绘制边角矩形", typeof(CreateCornerRectangleInVo), typeof(CreateCornerRectangleAction))]
        CreateCornerRectangle,

        [SwSketchAction("绘制中心矩形", "绘制中心矩形", typeof(CreateCenterRectangleInVo), typeof(CreateCenterRectangleAction))]
        CreateCenterRectangle,

        [SwSketchAction("绘制3点边角矩形", "绘制3点边角矩形", typeof(Create3PointCornerRectangleInVo), typeof(Create3PointCornerRectangleAction))]
        Create3PointCornerRectangle,

        [SwSketchAction("绘制3点中心矩形", "绘制3点中心矩形", typeof(Create3PointCenterRectangleInVo), typeof(Create3PointCenterRectangleAction))]
        Create3PointCenterRectangle,

        [SwSketchAction("绘制平行四边形", "绘制平行四边形", typeof(CreateParallelogramInVo), typeof(CreateParallelogramAction))]
        CreateParallelogram,

        [SwSketchAction("绘制直槽口", "绘制直槽口", typeof(CreateSketchSlotLineInVo), typeof(CreateSketchSlotLineAction))]
        CreateSketchSlot_line,

        [SwSketchAction("绘制中心点直槽口", "绘制中心点直槽口", typeof(CreateSketchSlotCenterLineInVo), typeof(CreateSketchSlotCenterLineAction))]
        CreateSketchSlot_center_line,

        [SwSketchAction("绘制三点圆弧槽口", "绘制三点圆弧槽口", typeof(CreateSketchSlot3PointArcInVo), typeof(CreateSketchSlot3PointArcAction))]
        CreateSketchSlot_3pointarc,

        [SwSketchAction("绘制中心点圆弧槽口", "绘制中心点圆弧槽口", typeof(CreateSketchSlotArcInVo), typeof(CreateSketchSlotArcAction))]
        CreateSketchSlot_arc,

        [SwSketchAction("绘制圆", "绘制圆", typeof(CreateCircleInVo), typeof(CreateCircleAction))]
        CreateCircle,

        [SwSketchAction("绘制周边圆", "绘制周边圆", typeof(PerimeterCircleInVo), typeof(PerimeterCircleAction))]
        PerimeterCircle,

        [SwSketchAction("绘制圆心/起/终点画弧", "绘制圆心/起/终点画弧", typeof(CreateArcInVo), typeof(CreateArcAction))]
        CreateArc,

        [SwSketchAction("绘制切线弧", "绘制切线弧", typeof(CreateTangentArcInVo), typeof(CreateTangentArcAction))]
        CreateTangentArc,

        [SwSketchAction("绘制3点圆弧", "绘制3点圆弧", typeof(Create3PointArcInVo), typeof(Create3PointArcAction))]
        Create3PointArc,

        [SwSketchAction("绘制多边形", "绘制多边形", typeof(CreatePolygonInVo), typeof(CreatePolygonAction))]
        CreatePolygon,

        [SwSketchAction("绘制B样条曲线", "绘制B样条曲线", typeof(CreateSplineInVo), typeof(CreateSplineAction))]
        CreateSpline,

        [SwSketchAction("绘制方程式驱动曲线", "绘制方程式驱动曲线", typeof(CreateEquationSplineInVo), typeof(CreateEquationSplineAction))]
        CreateEquationSpline,

        [SwSketchAction("绘制椭圆", "绘制椭圆", typeof(CreateEllipseInVo), typeof(CreateEllipseAction))]
        CreateEllipse,

        [SwSketchAction("绘制部分椭圆", "绘制部分椭圆", typeof(CreateEllipticalArcInVo), typeof(CreateEllipticalArcAction))]
        CreateEllipticalArc,

        [SwSketchAction("绘制抛物线", "绘制抛物线", typeof(CreateParabolaInVo), typeof(CreateParabolaAction))]
        CreateParabola,

        [SwSketchAction("绘制圆锥", "绘制圆锥", typeof(CreateConicInVo), typeof(CreateConicAction))]
        CreateConic,

        [SwSketchAction("绘制文本", "绘制文本", typeof(InsertSketchTextInVo), typeof(InsertSketchTextAction))]
        InsertSketchText,

        [SwSketchAction("绘制点", "绘制点", typeof(CreatePointInVo), typeof(CreatePointAction))]
        CreatePoint,

        [SwSketchAction("绘制圆角", "绘制圆角", typeof(CreateFilletInVo), typeof(CreateFilletAction))]
        CreateFillet,

        [SwSketchAction("绘制导角", "绘制导角", typeof(CreateChamferInVo), typeof(CreateChamferAction))]
        CreateChamfer,

        [SwSketchAction("裁剪实体", "裁剪实体", typeof(SketchTrimInVo), typeof(SketchTrimAction))]
        SketchTrim,

        [SwSketchAction("延伸实体", "延伸实体", typeof(SketchExtendInVo), typeof(SketchExtendAction))]
        [Description("会增加所选草图实体（即直线、中心线或弧）的长度，以使其与最近的草图实体相交")]
        SketchExtend,

        [SwSketchAction("偏移实体", "偏移实体", typeof(SketchOffsetInVo), typeof(SketchOffsetAction))]
        [Description("对所选的草图实体进行偏移操作")]
        SketchOffset,

        [SwSketchAction("线性阵列", "线性阵列", typeof(CreateLinearSketchStepAndRepeatInVo), typeof(CreateLinearSketchStepAndRepeatAction))]
        [Description("对所选的草图实体进行线性阵列")]
        CreateLinearSketchStepAndRepeat,

        [SwSketchAction("圆周阵列", "圆周阵列", typeof(CreateCircularSketchStepAndRepeatInVo), typeof(CreateCircularSketchStepAndRepeatAction))]
        [Description("对所选的草图实体进行圆周阵列")]
        CreateCircularSketchStepAndRepeat,

        [SwSketchAction("镜像实体", "镜像实体", typeof(SketchMirrorInVo), typeof(SketchMirrorAction))]
        [Description("对所选的草图实体进行镜像操作")]
        SketchMirror,

        [SwSketchAction("移动复制实体", "移动复制实体", typeof(MoveOrCopyInVo), typeof(MoveOrCopyAction))]
        [Description("对所选的草图实体进行移动或复制操作")]
        MoveOrCopy,

        [SwSketchAction("旋转复制实体", "旋转复制实体", typeof(RotateOrCopyInVo), typeof(RotateOrCopyAction))]
        [Description("对所选的草图实体进行旋转或复制操作")]
        RotateOrCopy,

        [SwSketchAction("显示隐藏草图约束关系", "显示隐藏草图约束关系", typeof(ShowSketchRelationsInVo), typeof(ShowSketchRelationsAction))]
        [Description("显示隐藏草图约束关系")]
        ShowSketchRelations,

        [SwSketchAction("添加草图约束关系", "添加草图约束关系", typeof(SketchAddConstraintsInVo), typeof(SketchAddConstraintsAction))]
        [Description("添加草图约束关系")]
        SketchAddConstraints,

        [SwSketchAction("标注草图尺寸", "标注草图尺寸", typeof(AddDimensionInVo), typeof(AddDimensionAction))]
        [Description("标注草图尺寸")]
        AddDimension,

        [SwSketchAction("完全草图定义", "完全草图定义", typeof(FullyDefineSketchInVo), typeof(FullyDefineSketchAction))]
        FullyDefineSketch,

        [SwSketchAction("拉伸基体", "拉伸基体", typeof(FeatureExtrusionThinInVo), typeof(FeatureExtrusionThinAction))]
        FeatureExtrusion,

        [SwSketchAction("拉伸薄壁", "拉伸薄壁", typeof(FeatureExtrusionThinInVo), typeof(FeatureExtrusionThinAction))]
        FeatureExtrusionThin,

        [SwSketchAction("创建旋转基体/凸台", "旋转基体", typeof(FeatureRevolveInVo), typeof(FeatureRevolveAction))]
        [Description("创建旋转基体、凸台或切除特征")]
        FeatureRevolve,

        [SwSketchAction("拉伸切除", "拉伸切除", typeof(FeatureExtrusionCutInVo), typeof(FeatureExtrusionCutAction))]
        FeatureExtrusionCut,

        [SwSketchAction("旋转切除", "旋转切除", typeof(FeatureExtrusionCutInVo), typeof(FeatureExtrusionCutAction))]
        FeatureRevolveCut,

        [SwSketchAction("绘制圆管", "绘制圆管", typeof(CreateCirclePipeInVo), typeof(CreateCirclePipeAction))]
        CreateCirclePipe,

        [SwSketchAction("绘制立方体", "绘制立方体", typeof(CreateCubeInVo), typeof(CreateCubeAction))]
        CreateCube,

        [SwSketchAction("绘制扶梯", "绘制扶梯", typeof(CreateLadderInVo), typeof(CreateLadderAction))]
        CreateLadder
    }
}
