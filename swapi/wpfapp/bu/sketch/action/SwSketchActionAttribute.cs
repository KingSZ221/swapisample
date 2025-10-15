using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.action
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SwSketchActionAttribute : Attribute
    {
        /// <summary>
        /// 操作名称
        /// </summary>
        public string ActionName { get; }

        /// <summary>
        /// 操作描述
        /// </summary>
        public string ActionDesc { get; }

        /// <summary>
        /// 操作入参类型
        /// </summary>
        public Type ActionInVoType { get; }

        /// <summary>
        /// 操作动作类型
        /// </summary>
        public Type ActionType { get; }

        public SwSketchActionAttribute(string actionName, string actionDesc, Type actionInVoType, Type actionType)
        {
            ActionName = actionName;
            ActionDesc = actionDesc;
            ActionInVoType = actionInVoType;
            ActionType = actionType;
        }
    }
}
