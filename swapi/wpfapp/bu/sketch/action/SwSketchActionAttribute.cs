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
        public string ActionName { get; }

        public Type ActionType { get; }

        public SwSketchActionAttribute(string actionName, Type actionType)
        {
            ActionName = actionName;
            ActionType = actionType;
        }
    }
}
