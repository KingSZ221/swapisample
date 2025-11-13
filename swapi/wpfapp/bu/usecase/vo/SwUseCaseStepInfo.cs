using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.usecase.vo
{
    /// <summary>
    /// 测试用例步骤
    /// </summary>
    public class SwUseCaseStepInfo
    {
        #region Fields

        /// <summary>
        /// 步骤名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 先执行本步骤要执行的命令，可以为空
        /// </summary>
        public List<SwUseCaseStepCmdInfo> CmdInfos { get; set; } = new List<SwUseCaseStepCmdInfo>();

        /// <summary>
        /// 后执行本步骤的子步骤，可以为空
        /// </summary>
        public List<SwUseCaseStepInfo> SubSteps = new List<SwUseCaseStepInfo>();

        #endregion   

        #region Construction

        public SwUseCaseStepInfo()
        {

        }

        public SwUseCaseStepInfo(SwUseCaseStepInfo oStep)
        {
            this.Name = oStep.Name;
            this.CmdInfos = new List<SwUseCaseStepCmdInfo>();
            foreach (SwUseCaseStepCmdInfo oCmd in oStep.CmdInfos)
            {
                this.CmdInfos.Add(new SwUseCaseStepCmdInfo(oCmd));
            }
            this.SubSteps = new List<SwUseCaseStepInfo>();
            foreach (SwUseCaseStepInfo oSubStep in oStep.SubSteps)
            {
                this.SubSteps.Add(new SwUseCaseStepInfo(oSubStep));
            }
        }

        public SwUseCaseStepInfo(SwUseCaseStepItem oStep)
        {
            this.Name = oStep.Name;
            this.CmdInfos = new List<SwUseCaseStepCmdInfo>();
            foreach (SwUseCaseStepCmdItem oCmd in oStep.CmdInfos)
            {
                this.CmdInfos.Add(new SwUseCaseStepCmdInfo(oCmd));
            }
            this.SubSteps = new List<SwUseCaseStepInfo>();
            foreach (SwUseCaseStepItem oSubStep in oStep.SubSteps)
            {
                this.SubSteps.Add(new SwUseCaseStepInfo(oSubStep));
            }
        }

        #endregion
    }
}
