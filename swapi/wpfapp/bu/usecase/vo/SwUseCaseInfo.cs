using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.usecase.vo
{
    /// <summary>
    /// 测试用例
    /// </summary>
    public class SwUseCaseInfo
    {
        #region Fields

        /// <summary>
        /// 用例ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///用例名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用例描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 用例组
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 用例步骤
        /// </summary>
        public List<SwUseCaseStepInfo> Steps { get; set; } = new List<SwUseCaseStepInfo>();

        #endregion       

        #region Construction

        public SwUseCaseInfo()
        {

        }

        public SwUseCaseInfo(SwUseCaseInfo oUseCase)
        {
            this.Id = oUseCase.Id;
            this.Name = oUseCase.Name;
            this.Desc = oUseCase.Desc;
            this.Group = oUseCase.Group;
            this.Steps = new List<SwUseCaseStepInfo>();
            foreach (SwUseCaseStepInfo oStep in oUseCase.Steps)
            {
                this.Steps.Add(new SwUseCaseStepInfo(oStep));
            }
        }

        public SwUseCaseInfo(SwUseCaseItem oUseCase)
        {
            this.Id = oUseCase.Id;
            this.Name = oUseCase.Name;
            this.Desc = oUseCase.Desc;
            this.Group = oUseCase.Group;
            this.Steps = new List<SwUseCaseStepInfo>();
            foreach (SwUseCaseStepItem oStep in oUseCase.Steps)
            {
                this.Steps.Add(new SwUseCaseStepInfo(oStep));
            }
        }

        #endregion
    }
}
