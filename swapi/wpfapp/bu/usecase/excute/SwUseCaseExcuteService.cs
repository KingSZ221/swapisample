using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.action;
using wpfapp.bu.usecase.vo;

namespace wpfapp.bu.cmd.usecase.excute
{
    public class SwUseCaseExcuteService
    {
        #region Fields

        private static SwUseCaseExcuteService _inst = null;

        #endregion

        #region Construction

        public SwUseCaseExcuteService()
        {

        }

        public static SwUseCaseExcuteService getInstance()
        {
            if (_inst == null)
            {
                _inst = new SwUseCaseExcuteService();
            }
            return _inst;
        }

        #endregion

        #region 执行

        public void excuteUseCase(string id)
        {
            SwUseCaseInfo oSwUseCaseInfo = SwUseCaseInfoManager.getInstance().getById(id);
            if(oSwUseCaseInfo == null)
            {
                return;
            }

            SwUseCaseItem oSwUseCaseItem = new SwUseCaseItem(oSwUseCaseInfo);

            SwBuLogService.getInstance().Info($"用例开始 {oSwUseCaseItem.Name}");

            foreach(SwUseCaseStepItem oSwUseCaseStepItem in oSwUseCaseItem.Steps)
            {
                excuteUseCaseStep(oSwUseCaseStepItem);
            }

            SwBuLogService.getInstance().Info($"用例结束 {oSwUseCaseItem.Name}");
        }

        private void excuteUseCaseStep(SwUseCaseStepItem oSwUseCaseStepItem)
        {
            SwBuLogService.getInstance().Info($"步骤开始 {oSwUseCaseStepItem.Name}");

            foreach (SwUseCaseStepCmdItem oSwUseCaseStepCmdItem in oSwUseCaseStepItem.CmdInfos)
            {
                if(oSwUseCaseStepCmdItem.CmdTypeId > 0)
                {
                    excuteUseCaseStepCmd(oSwUseCaseStepCmdItem);
                }
            }

            SwBuLogService.getInstance().Info($"步骤结束 {oSwUseCaseStepItem.Name}");
        }

        private void excuteUseCaseStepCmd(SwUseCaseStepCmdItem oSwUseCaseStepCmdItem)
        {
            SwBuLogService.getInstance().Info($"命令开始 {oSwUseCaseStepCmdItem.CmdName}");

            SwBuCmdService.getInstance().executeCmdWithInVo(oSwUseCaseStepCmdItem.CmdModule, oSwUseCaseStepCmdItem.CmdTypeId, oSwUseCaseStepCmdItem.CmdInVoObj);

            SwBuLogService.getInstance().Info($"命令结束 {oSwUseCaseStepCmdItem.CmdName}");
        }

        #endregion
    }
}
