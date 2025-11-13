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

            SwBuLogService.getInstance().Info($"开始执行用例 {oSwUseCaseItem.Name}");

            foreach(SwUseCaseStepItem oSwUseCaseStepItem in oSwUseCaseItem.Steps)
            {
                excuteUseCaseStep(oSwUseCaseStepItem);
            }

            SwBuLogService.getInstance().Info($"结束执行用例 {oSwUseCaseItem.Name}");
        }

        private void excuteUseCaseStep(SwUseCaseStepItem oSwUseCaseStepItem)
        {
            SwBuLogService.getInstance().Info($"开始执行步骤 {oSwUseCaseStepItem.Name}");

            foreach (SwUseCaseStepCmdItem oSwUseCaseStepCmdItem in oSwUseCaseStepItem.CmdInfos)
            {
                if(oSwUseCaseStepCmdItem.CmdTypeId > 0)
                {
                    excuteUseCaseStepCmd(oSwUseCaseStepCmdItem);
                }
            }

            SwBuLogService.getInstance().Info($"结束执行步骤 {oSwUseCaseStepItem.Name}");
        }

        private void excuteUseCaseStepCmd(SwUseCaseStepCmdItem oSwUseCaseStepCmdItem)
        {
            SwBuLogService.getInstance().Info($"开始执行命令 {oSwUseCaseStepCmdItem.CmdName}");

            SwSketchActionProvider.getInstance().execute((EnumSwSketchActionType)oSwUseCaseStepCmdItem.CmdTypeId, oSwUseCaseStepCmdItem.CmdInVoObj);

            SwBuLogService.getInstance().Info($"结束执行命令 {oSwUseCaseStepCmdItem.CmdName}");
        }

        #endregion
    }
}
