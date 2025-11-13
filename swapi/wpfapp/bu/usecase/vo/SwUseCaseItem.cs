using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.usecase.vo
{
    public class SwUseCaseItem
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
        /// 用例步骤
        /// </summary>
        public List<SwUseCaseStepItem> Steps { get; set; } = new List<SwUseCaseStepItem>();

        #endregion   

        #region Construction

        public SwUseCaseItem()
        {

        }

        public SwUseCaseItem(SwUseCaseInfo oUseCase)
        {
            this.Id = oUseCase.Id;
            this.Name = oUseCase.Name;
            this.Desc = oUseCase.Desc;
            this.Steps = new List<SwUseCaseStepItem>();
            foreach (SwUseCaseStepInfo oStep in oUseCase.Steps)
            {
                this.Steps.Add(new SwUseCaseStepItem(oStep));
            }
        }

        #endregion

        #region 增删查改

        public void addStep(SwUseCaseStepItem oSwUseCaseStepItem)
        {
            this.Steps.Add(oSwUseCaseStepItem);
        }

        public void removeStep(SwUseCaseStepItem oSwUseCaseStepItem)
        {
            this.Steps.Remove(oSwUseCaseStepItem);
        }

        public void removeAllStep()
        {
            this.Steps.Clear();
        }

        public void updateStep(SwUseCaseStepItem oSwUseCaseStepItemTarget, SwUseCaseStepItem oSwUseCaseStepItemUpdate)
        {
            oSwUseCaseStepItemTarget.copyFrom(oSwUseCaseStepItemUpdate);
        }

        public bool copyStep(SwUseCaseStepItem oSwUseCaseStepItem)
        {
            int iIndex = this.Steps.IndexOf(oSwUseCaseStepItem);
            if(iIndex >= 0)
            {
                SwUseCaseStepItem oNewSwUseCaseStepItem = new SwUseCaseStepItem(oSwUseCaseStepItem);
                this.Steps.Insert(iIndex + 1, oNewSwUseCaseStepItem);
                return true;
            }
            return false;
        }

        public bool moveUpDownStep(SwUseCaseStepItem oSwUseCaseStepItem, bool bMoveDown)
        {
            int iIndex = this.Steps.IndexOf(oSwUseCaseStepItem);
            if (iIndex >= 0)
            {
                if (bMoveDown)
                {
                    // 下移
                    if (iIndex < this.Steps.Count - 1)
                    {
                        this.Steps.RemoveAt(iIndex);
                        this.Steps.Insert(iIndex + 1, oSwUseCaseStepItem);
                        return true;
                    }
                }
                else
                {
                    // 上移
                    if (iIndex > 0)
                    {
                        this.Steps.RemoveAt(iIndex);
                        this.Steps.Insert(iIndex - 1, oSwUseCaseStepItem);
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion
    }
}
