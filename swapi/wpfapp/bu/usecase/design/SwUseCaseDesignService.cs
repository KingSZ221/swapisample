using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.app;
using wpfapp.bu.usecase.vo;
using wpfapp.ui.menu;
using wpfapp.ui.usecase;

namespace wpfapp.bu.cmd.usecase.design
{
    public class SwUseCaseDesignService
    {
        #region Fields

        private static SwUseCaseDesignService _inst = null;

        #endregion

        #region Construction

        public SwUseCaseDesignService()
        {

        }

        public static SwUseCaseDesignService getInstance()
        {
            if (_inst == null)
            {
                _inst = new SwUseCaseDesignService();
            }
            return _inst;
        }

        #endregion

        #region 增删查改

        public List<SwUseCaseInfo> getAll()
        {
            return SwUseCaseInfoManager.getInstance().getAll();
        }

        public void addUseCase(SwUseCaseItem oSwUseCaseItem)
        {
            SwUseCaseInfoManager.getInstance().add(new SwUseCaseInfo(oSwUseCaseItem));
            SwUseCaseInfoManager.getInstance().saveToFile();
        }

        public void removeUseCase(string id)
        {
            SwUseCaseInfoManager.getInstance().removeById(id);
            SwUseCaseInfoManager.getInstance().saveToFile();
        }

        public void removeAllUseCase()
        {
            SwUseCaseInfoManager.getInstance().removeAll();
            SwUseCaseInfoManager.getInstance().saveToFile();
        }

        public SwUseCaseItem getById(string id)
        {
            SwUseCaseInfo oSwUseCaseInfo = SwUseCaseInfoManager.getInstance().getById(id);
            if(oSwUseCaseInfo != null)
            {
                return new SwUseCaseItem(oSwUseCaseInfo);
            }
            return null;
        }

        public void updateUseCase(SwUseCaseItem oSwUseCaseItem)
        {
            SwUseCaseInfoManager.getInstance().update(new SwUseCaseInfo(oSwUseCaseItem));
            SwUseCaseInfoManager.getInstance().saveToFile();
        }

        public void copyUseCase(string id)
        {
            SwUseCaseInfoManager.getInstance().copy(id);
            SwUseCaseInfoManager.getInstance().saveToFile();
        }

        public void moveUpDownUseCase(string id, bool bMoveDown)
        {
            SwUseCaseInfoManager.getInstance().moveUpDownUseCase(id, bMoveDown);
            SwUseCaseInfoManager.getInstance().saveToFile();
        }

        internal void showUseCaseListDialog()
        {
            SwUseCaseListPanel oDlg = new SwUseCaseListPanel(SwBuAppService.getMainWindow());
            oDlg.ShowDialog();

            SwUiMenuService.getInstance().updateUseCaseSubMenu();
        }

        #endregion
    }
}
