using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo;
using wpfapp.bu.sketch.vo.arc;
using wpfapp.bu.sketch.vo.circle;
using wpfapp.bu.sketch.vo.rect;
using wpfapp.bu.sketch.vo.sketch;
using wpfapp.bu.sketch.vo.slot;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action
{
    /// <summary>
    /// 草图操作类型
    /// </summary>
    public enum EnumSwSketchActionType
    {
        [SwSketchAction("草图绘制", typeof(EditSketchInVo))]
        EditSketch = 1,

        [SwSketchAction("退出草图", typeof(ExitSketchInVo))]
        ExitSketch,

        [SwSketchAction("绘制直线", typeof(CreateLineInVo))]
        CreateLine,

        [SwSketchAction("绘制中心直线", typeof(CreateCenterLineInVo))]
        CreateCenterLine,

        [SwSketchAction("绘制边角矩形", typeof(CreateCornerRectangleInVo))]
        CreateCornerRectangle,

        [SwSketchAction("绘制中心矩形", typeof(CreateCenterRectangleInVo))]
        CreateCenterRectangle,

        [SwSketchAction("绘制3点边角矩形", typeof(Create3PointCornerRectangleInVo))]
        Create3PointCornerRectangle,

        [SwSketchAction("绘制3点中心矩形", typeof(Create3PointCenterRectangleInVo))]
        Create3PointCenterRectangle,

        [SwSketchAction("绘制平行四边形", typeof(CreateParallelogramInVo))]
        CreateParallelogram,

        [SwSketchAction("绘制直槽口", typeof(CreateSketchSlotLineInVo))]
        CreateSketchSlot_line,

        [SwSketchAction("绘制中心点直槽口", typeof(CreateSketchSlotCenterLineInVo))]
        CreateSketchSlot_center_line,

        [SwSketchAction("绘制三点圆弧槽口", typeof(CreateSketchSlot3PointArcInVo))]
        CreateSketchSlot_3pointarc,

        [SwSketchAction("绘制中心点圆弧槽口", typeof(CreateSketchSlotArcInVo))]
        CreateSketchSlot_arc,

        [SwSketchAction("绘制圆", typeof(CreateCircleInVo))]
        CreateCircle,

        [SwSketchAction("绘制周边圆", typeof(PerimeterCircleInVo))]
        PerimeterCircle,

        [SwSketchAction("绘制圆心/起/终点画弧", typeof(CreateArcInVo))]
        CreateArc,

        [SwSketchAction("绘制切线弧", typeof(CreateTangentArcInVo))]
        CreateTangentArc,

        [SwSketchAction("绘制3点圆弧", typeof(Create3PointArcInVo))]
        Create3PointArc,

        [SwSketchAction("绘制圆管", typeof(CreateCirclePipeInVo))]
        CreateCirclePipe
    }
}
