using swapiapp.ui.menu;
using swapiapp.ui.usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapiapp.ui.mainwindow;

namespace swapiapp.ui.usecase
{
    public class SwUseCaseUiService
    {
        public static void showUseCaseListDialog()
        {
            SwUseCaseListPanel oDlg = new SwUseCaseListPanel(SwMainWindowService.getMainWindow());
            oDlg.ShowDialog();

            SwUiMenuService.getInstance().updateUseCaseSubMenu();
        }
    }
}
