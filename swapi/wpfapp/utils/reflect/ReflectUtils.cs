using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.utils.reflect
{
    public class ReflectUtils
    {
        public static string GetTypeDisplayName(Type type)
        {
            var attribute = type.GetCustomAttribute<DisplayNameAttribute>();
            if(attribute == null)
            {
                return "";
            }
            return attribute.DisplayName;
        }

        public static string GetEnumValueDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DisplayNameAttribute>();
            return attribute?.DisplayName ?? value.ToString();
        }

        public static string GetEnumValueDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }

        //public static T GetCustomAttribute<T>(Enum value, Type customAttr)
        //{
        //    FieldInfo field = value.GetType().GetField(value.ToString());
        //    return field.GetCustomAttribute<T>();
        //}
    }
}
