using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.usecase.vo
{
    /// <summary>
    /// 用例步骤的命令信息
    /// </summary>
    public class SwUseCaseStepCmdInfo
    {
        #region Fields

        /// <summary>
        /// 命令模块
        /// </summary>
        public string CmdModule { get; set; } = "";

        /// <summary>
        /// 命令类型ID
        /// </summary>
        //public int CmdTypeId { get; set; } = 0;

        /// <summary>
        /// 命令类型ID
        /// </summary>
        public string CmdTypeIdStr { get; set; } = "None";

        /// <summary>
        /// 命令的入参Json
        /// </summary>
        public string CmdInVoJson { get; set; } = "";

        #endregion

        #region Construction

        public SwUseCaseStepCmdInfo()
        {

        }

        public SwUseCaseStepCmdInfo(SwUseCaseStepCmdInfo oCmd)
        {
            this.CmdModule = oCmd.CmdModule;
            //this.CmdTypeId = oCmd.CmdTypeId;
            this.CmdTypeIdStr = oCmd.CmdTypeIdStr;
            this.CmdInVoJson = oCmd.CmdInVoJson;
        }

        public SwUseCaseStepCmdInfo(SwUseCaseStepCmdItem oCmd)
        {
            this.CmdModule = oCmd.CmdModule;
            //this.CmdTypeId = oCmd.CmdTypeId;
            this.CmdTypeIdStr = oCmd.CmdTypeIdStr;
            this.CmdInVoJson = JsonConvert.SerializeObject(oCmd.CmdInVoObj, Formatting.Indented); 
        }

        #endregion
    }
}
