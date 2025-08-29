using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.action.arc;
using wpfapp.bu.sketch.action.circle;
using wpfapp.bu.sketch.action.line;
using wpfapp.bu.sketch.action.pipe;
using wpfapp.bu.sketch.action.rect;
using wpfapp.bu.sketch.action.sketch;
using wpfapp.bu.sketch.action.slot;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action
{
    public class SwSketchActionProvider
    {
        #region Fields
        private static SwSketchActionProvider _instance = new SwSketchActionProvider();

        private Dictionary<EnumSwSketchActionType, Type> actionTypeMap = new Dictionary<EnumSwSketchActionType, Type>();

        #endregion

        #region Constuction

        public SwSketchActionProvider()
        {
            priInitActions();
        }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwSketchActionProvider getInstance()
        {
            return _instance;
        }

        #endregion

        #region actions

        private void priInitActions()
        {
            actionTypeMap[EnumSwSketchActionType.EditSketch] = typeof(EditSketchAction);
            actionTypeMap[EnumSwSketchActionType.ExitSketch] = typeof(ExitSketchAction);
            actionTypeMap[EnumSwSketchActionType.CreateLine] = typeof(CreateLineAction);
            actionTypeMap[EnumSwSketchActionType.CreateCenterLine] = typeof(CreateCenterLineAction);
            actionTypeMap[EnumSwSketchActionType.CreateCornerRectangle] = typeof(CreateCornerRectangleAction);
            actionTypeMap[EnumSwSketchActionType.CreateCenterRectangle] = typeof(CreateCenterRectangleAction);
            actionTypeMap[EnumSwSketchActionType.Create3PointCornerRectangle] = typeof(Create3PointCornerRectangleAction);
            actionTypeMap[EnumSwSketchActionType.Create3PointCenterRectangle] = typeof(Create3PointCenterRectangleAction);
            actionTypeMap[EnumSwSketchActionType.CreateParallelogram] = typeof(CreateParallelogramAction);
            actionTypeMap[EnumSwSketchActionType.CreateSketchSlot_line] = typeof(CreateSketchSlotLineAction);
            actionTypeMap[EnumSwSketchActionType.CreateSketchSlot_center_line] = typeof(CreateSketchSlotCenterLineAction);
            actionTypeMap[EnumSwSketchActionType.CreateSketchSlot_3pointarc] = typeof(CreateSketchSlot3PointArcAction);
            actionTypeMap[EnumSwSketchActionType.CreateSketchSlot_arc] = typeof(CreateSketchSlotArcAction);
            actionTypeMap[EnumSwSketchActionType.CreateCircle] = typeof(CreateCircleAction);
            actionTypeMap[EnumSwSketchActionType.PerimeterCircle] = typeof(PerimeterCircleAction);
            actionTypeMap[EnumSwSketchActionType.CreateArc] = typeof(CreateArcAction);
            actionTypeMap[EnumSwSketchActionType.CreateTangentArc] = typeof(CreateTangentArcAction);
            actionTypeMap[EnumSwSketchActionType.Create3PointArc] = typeof(Create3PointArcAction);
            actionTypeMap[EnumSwSketchActionType.CreateCirclePipe] = typeof(CreateCirclePipeAction);
        }

        private Type getActionType(EnumSwSketchActionType actionType)
        {
            return actionTypeMap[actionType];
        }

        #endregion

        #region execute

        #endregion

        public RespVo execute(EnumSwSketchActionType actionType, object actionInVo)
        {
            Type actionObjType = getActionType(actionType);
            if(actionObjType == null)
            {
                return RespVoLogExt.genError($"不支持的绘制操作, {actionType}");
            }

            // 获取特定构造函数（参数为object）
            ConstructorInfo ctor = actionObjType.GetConstructor(new[] { typeof(object) });
            if(ctor == null)
            {
                return RespVoLogExt.genError($"不支持的绘制操作, {actionType}");
            }

            // 准备参数
            object[] parameters = new object[] { actionInVo };

            // 调用构造函数创建实例
            object actionObj = ctor.Invoke(parameters);
            if (actionObj == null)
            {
                return RespVoLogExt.genError($"不支持的绘制操作, {actionType}");
            }

            SwSketchActionBase swAction = (SwSketchActionBase)actionObj;
            if(swAction == null)
            {
                return RespVoLogExt.genError($"不支持的绘制操作, {actionType}");
            }

            RespVo oRespVo = null;
            try
            {
                oRespVo = swAction.execute();
            }
            catch (Exception ex)
            {
                oRespVo = RespVoLogExt.genException(ex, $"绘制操作发生异常, {actionType}");
            }
            return oRespVo;
        }
    }
}
