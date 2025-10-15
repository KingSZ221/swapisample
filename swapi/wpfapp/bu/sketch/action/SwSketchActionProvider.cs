using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.action.draw.arc;
using wpfapp.bu.sketch.action.draw.circle;
using wpfapp.bu.sketch.action.draw.ellipse;
using wpfapp.bu.sketch.action.entity;
using wpfapp.bu.sketch.action.edit.fillet;
using wpfapp.bu.sketch.action.draw.line;
using wpfapp.bu.sketch.action.draw.pipe;
using wpfapp.bu.sketch.action.draw.point;
using wpfapp.bu.sketch.action.draw.polygon;
using wpfapp.bu.sketch.action.draw.rect;
using wpfapp.bu.sketch.action.sketch;
using wpfapp.bu.sketch.action.draw.slot;
using wpfapp.bu.sketch.action.draw.spline;
using wpfapp.bu.sketch.action.draw.text;
using wpfapp.bu.vo;
using wpfapp.bu.sketch.action.edit.trim;
using wpfapp.bu.sketch.action.draw.define;
using wpfapp.bu.sketch.action.compose.ladder;
using wpfapp.bu.sketch.action.feature.extrusion;
using wpfapp.bu.sketch.action.edit.extend;

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
            Type enumType = typeof(EnumSwSketchActionType);
            var fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                object rawValue = field.GetValue(null);
                int intValue = (int)rawValue;
                string name = field.Name;

                // 获取自定义特性
                SwSketchActionAttribute attribute = field.GetCustomAttribute<SwSketchActionAttribute>();
                if (attribute.ActionType != null)
                {
                    actionTypeMap[(EnumSwSketchActionType)intValue] = attribute.ActionType;
                }
            }
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
