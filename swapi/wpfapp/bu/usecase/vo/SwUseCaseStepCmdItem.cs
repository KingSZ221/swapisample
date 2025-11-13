using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.cmd;

namespace wpfapp.bu.usecase.vo
{
    public class SwUseCaseStepCmdItem
    {
        #region Fields

        /// <summary>
        /// 命令类型ID
        /// </summary>
        public int CmdTypeId { get; set; } = 0;

        /// <summary>
        /// 命令的入参对象
        /// </summary>
        public object CmdInVoObj { get; set; } = new object();

        public string CmdName { get; set; } = "None";

        public string CmdInVoJson { get; set; } = "";

        #endregion

        #region Construction

        public SwUseCaseStepCmdItem()
        {

        }

        public SwUseCaseStepCmdItem(SwUseCaseStepCmdItem oCmdInfo)
        {
            this.copyFrom(oCmdInfo);
        }

        public SwUseCaseStepCmdItem(SwUseCaseStepCmdInfo oCmdInfo)
        {
            this.CmdTypeId = oCmdInfo.CmdTypeId;
            this.CmdInVoJson = oCmdInfo.CmdInVoJson;

            this.resolve();
        }

        internal void copyFrom(SwUseCaseStepCmdItem oCmdInfo)
        {
            this.CmdTypeId = oCmdInfo.CmdTypeId;
            this.CmdInVoJson = oCmdInfo.CmdInVoJson;

            this.resolve();
        }

        public void resolve()
        {
            SwCmdType oSwCmdType = SwCmdTypeManager.getInstance().getByTypeId(this.CmdTypeId);
            if(oSwCmdType == null)
            {
                this.CmdName = "None";
                this.CmdInVoObj = new object();
            }
            else
            {
                this.CmdName = oSwCmdType.CmdTypeName;
                this.CmdInVoObj = JsonConvert.DeserializeObject(this.CmdInVoJson, oSwCmdType.ActionInVoType);
            }
        }

        public void updateCmdInVoJson()
        {
            this.CmdInVoJson = JsonConvert.SerializeObject(this.CmdInVoObj);
        }

        #endregion
    }
}
