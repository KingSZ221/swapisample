using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.usecase.vo
{
    public class SwUseCaseStepItem
    {
        #region Fields

        /// <summary>
        /// 步骤名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 先执行本步骤要执行的命令，可以为空
        /// </summary>
        public List<SwUseCaseStepCmdItem> CmdInfos { get; set; } = new List<SwUseCaseStepCmdItem>();

        /// <summary>
        /// 后执行本步骤的子步骤，可以为空
        /// </summary>
        public List<SwUseCaseStepItem> SubSteps = new List<SwUseCaseStepItem>();

        #endregion

        #region Construction

        public SwUseCaseStepItem()
        {

        }

        public SwUseCaseStepItem(SwUseCaseStepItem oStep)
        {
            this.copyFrom(oStep);
        }

        public SwUseCaseStepItem(SwUseCaseStepInfo oStep)
        {
            this.Name = oStep.Name;
            this.CmdInfos = new List<SwUseCaseStepCmdItem>();
            foreach(SwUseCaseStepCmdInfo oCmd in oStep.CmdInfos)
            {
                this.CmdInfos.Add(new SwUseCaseStepCmdItem(oCmd));
            }
            this.SubSteps = new List<SwUseCaseStepItem>();
            foreach (SwUseCaseStepInfo oSubStep in oStep.SubSteps)
            {
                this.SubSteps.Add(new SwUseCaseStepItem(oSubStep));
            }
        }

        public void copyFrom(SwUseCaseStepItem oStep)
        {
            this.Name = oStep.Name;
            this.CmdInfos = new List<SwUseCaseStepCmdItem>();
            foreach (SwUseCaseStepCmdItem oCmd in oStep.CmdInfos)
            {
                this.CmdInfos.Add(new SwUseCaseStepCmdItem(oCmd));
            }
            this.SubSteps = new List<SwUseCaseStepItem>();
            foreach (SwUseCaseStepItem oSubStep in oStep.SubSteps)
            {
                this.SubSteps.Add(new SwUseCaseStepItem(oSubStep));
            }
        }

        public void addCmd(SwUseCaseStepCmdItem useCaseStepCmdItemNew)
        {
            this.CmdInfos.Add(useCaseStepCmdItemNew);
        }

        public void removeAllCmd()
        {
            this.CmdInfos.Clear();
        }

        public void updateCmd(SwUseCaseStepCmdItem useCaseStepCmdItem, SwUseCaseStepCmdItem useCaseStepCmdItemUpdate)
        {
            useCaseStepCmdItem.copyFrom(useCaseStepCmdItemUpdate);
        }

        public bool copyCmd(SwUseCaseStepCmdItem useCaseStepCmdItem)
        {
            int iIndex = this.CmdInfos.IndexOf(useCaseStepCmdItem);
            if (iIndex >= 0)
            {
                SwUseCaseStepCmdItem oNewSwUseCaseStepCmdItem = new SwUseCaseStepCmdItem(useCaseStepCmdItem);
                this.CmdInfos.Insert(iIndex + 1, oNewSwUseCaseStepCmdItem);
                return true;
            }
            return false;
        }

        public void removeCmd(SwUseCaseStepCmdItem useCaseStepCmdItem)
        {
            this.CmdInfos.Remove(useCaseStepCmdItem);
        }

        public bool moveUpDownCmd(SwUseCaseStepCmdItem useCaseStepCmdItem, bool bMoveDown)
        {
            int iIndex = this.CmdInfos.IndexOf(useCaseStepCmdItem);
            if (iIndex >= 0)
            {
                if (bMoveDown)
                {
                    // 下移
                    if (iIndex < this.CmdInfos.Count - 1)
                    {
                        this.CmdInfos.RemoveAt(iIndex);
                        this.CmdInfos.Insert(iIndex + 1, useCaseStepCmdItem);
                        return true;
                    }
                }
                else
                {
                    // 上移
                    if (iIndex > 0)
                    {
                        this.CmdInfos.RemoveAt(iIndex);
                        this.CmdInfos.Insert(iIndex - 1, useCaseStepCmdItem);
                        return true;
                    }
                }
            }
            return false;
        }

        public void addSubStep(SwUseCaseStepItem useCaseStepSubItemNew)
        {
            this.SubSteps.Add(useCaseStepSubItemNew);
        }

        public void removeAllSubStep()
        {
            this.SubSteps.Clear();
        }

        public void updateSubStep(SwUseCaseStepItem useCaseSubStepItem, SwUseCaseStepItem useCaseStepSubItemUpdate)
        {
            useCaseSubStepItem.copyFrom(useCaseStepSubItemUpdate);
        }

        public bool copySubStep(SwUseCaseStepItem useCaseSubStepItem)
        {
            int iIndex = this.SubSteps.IndexOf(useCaseSubStepItem);
            if (iIndex >= 0)
            {
                SwUseCaseStepItem oNewSwUseCaseStepItem = new SwUseCaseStepItem(useCaseSubStepItem);
                this.SubSteps.Insert(iIndex + 1, oNewSwUseCaseStepItem);
                return true;
            }
            return false;
        }

        public void removeSubStep(SwUseCaseStepItem useCaseSubStepItem)
        {
            this.SubSteps.Remove(useCaseSubStepItem);
        }

        public bool moveUpDownSubStep(SwUseCaseStepItem useCaseSubStepItem, bool bMoveDown)
        {
            int iIndex = this.SubSteps.IndexOf(useCaseSubStepItem);
            if (iIndex >= 0)
            {
                if (bMoveDown)
                {
                    // 下移
                    if (iIndex < this.CmdInfos.Count - 1)
                    {
                        this.SubSteps.RemoveAt(iIndex);
                        this.SubSteps.Insert(iIndex + 1, useCaseSubStepItem);
                        return true;
                    }
                }
                else
                {
                    // 上移
                    if (iIndex > 0)
                    {
                        this.SubSteps.RemoveAt(iIndex);
                        this.SubSteps.Insert(iIndex - 1, useCaseSubStepItem);
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion
    }
}
