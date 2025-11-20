using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.action;

namespace wpfapp.bu.cmd.cmdtype
{
    public class SwCmdTypeManager
    {
        #region Fields

        private static SwCmdTypeManager _inst = null;

        private List<string> cmdModuleList = new List<string>();
        private List<SwCmdType> cmdTypeList = new List<SwCmdType>();

        #endregion

        #region Construction

        public SwCmdTypeManager()
        {
        }

        public static SwCmdTypeManager getInstance()
        {
            if (_inst == null)
            {
                _inst = new SwCmdTypeManager();
            }
            return _inst;
        }

        #endregion

        #region init

        public void registCmds(string moduleName, Type enumCmdType)
        {
            if(!cmdModuleList.Contains(moduleName))
            {
                cmdModuleList.Add(moduleName);
            }

            var fields = enumCmdType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                object rawValue = field.GetValue(null);
                int intValue = (int)rawValue;
                string name = field.Name;

                // 获取自定义特性
                SwCmdTypeAttribute attribute = field.GetCustomAttribute<SwCmdTypeAttribute>();
                if (attribute != null)
                {
                    SwCmdType oSwCmdType = new SwCmdType();
                    oSwCmdType.CmdModule = moduleName;
                    oSwCmdType.CmdTypeId = intValue;
                    oSwCmdType.CmdTypeIdStr = rawValue.ToString();
                    oSwCmdType.CmdTypeName = attribute.CmdName;
                    oSwCmdType.CdmDesc = attribute.CmdDesc;
                    oSwCmdType.CmdGroupName = attribute.CmdGroup;
                    oSwCmdType.ActionType = attribute.CmdActionType;
                    oSwCmdType.ActionInVoType = attribute.CmdInVoType;
                    cmdTypeList.Add(oSwCmdType);
                }
            }
        }

        #endregion

        #region 查询

        public List<string> getModules()
        {
            return this.cmdModuleList;
        }

        public List<SwCmdType> getAllCmds()
        {
            return this.cmdTypeList;
        }

        public List<SwCmdType> getCmdsByModule(string module)
        {
            return this.cmdTypeList.Where(p => p.CmdModule.Equals(module)).ToList();
        }

        public SwCmdType getByTypeId(string module, int id)
        {
            for (int i = 0; i < this.cmdTypeList.Count; i++)
            {
                SwCmdType oSwCmdType = this.cmdTypeList[i];
                if (oSwCmdType.CmdModule.Equals(module) && oSwCmdType.CmdTypeId == id)
                {
                    return oSwCmdType;
                }
            }
            return null;
        }

        public SwCmdType getByTypeIdStr(string module, string id)
        {
            for (int i = 0; i < this.cmdTypeList.Count; i++)
            {
                SwCmdType oSwCmdType = this.cmdTypeList[i];
                if (oSwCmdType.CmdModule.Equals(module) && oSwCmdType.CmdTypeIdStr == id)
                {
                    return oSwCmdType;
                }
            }
            return null;
        }

        #endregion
    }
}
