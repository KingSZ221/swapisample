using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using wpfapp.bu.app;
using wpfapp.bu.cmd.usecase.design;
using wpfapp.bu.usecase.vo;

namespace wpfapp.ui.usecase
{
    /// <summary>
    /// SwUseCaseListPanel.xaml 的交互逻辑
    /// </summary>
    public partial class SwUseCaseListPanel : Window
    {
        public SwUseCaseListPanel(Window p_Owner)
        {
            InitializeComponent();

            this.Owner = p_Owner;
            this.priInitUseCaseList();
        }

        private void priInitUseCaseList()
        {
            this.gridUseCase.ItemsSource = SwUseCaseDesignService.getInstance().getAll();
        }

        private void priRefreshDataGrid()
        {
            this.gridUseCase.ItemsSource = SwUseCaseDesignService.getInstance().getAll();
            this.gridUseCase.Items.Refresh();
        }

        private void btnAddUseCase_Click(object sender, RoutedEventArgs e)
        {
            SwUseCaseItem useCaseItemNew = new SwUseCaseItem();
            useCaseItemNew.Name = "用例1";
            var editWindow = new SwUseCaseInfoPanel(this, false, useCaseItemNew);
            editWindow.Owner = this;
            if (editWindow.ShowDialog() == true)
            {
                SwUseCaseDesignService.getInstance().addUseCase(useCaseItemNew);
                this.priRefreshDataGrid();
            }
        }

        private void btnRemoveAllUseCase_Click(object sender, RoutedEventArgs e)
        {
            SwUseCaseDesignService.getInstance().removeAllUseCase();
            this.priRefreshDataGrid();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseInfo useCaseItem)
            {
                SwUseCaseItem useCaseItemUpdate = new SwUseCaseItem(useCaseItem);
                var editWindow = new SwUseCaseInfoPanel(this, true, useCaseItemUpdate);
                if (editWindow.ShowDialog() == true)
                {
                    SwUseCaseDesignService.getInstance().updateUseCase(useCaseItemUpdate);
                    this.priRefreshDataGrid();
                }
            }
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseInfo useCaseItem)
            {
                SwUseCaseDesignService.getInstance().copyUseCase(useCaseItem.Id);
                this.priRefreshDataGrid();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseInfo useCaseItem)
            {
                SwUseCaseDesignService.getInstance().removeUseCase(useCaseItem.Id);
                this.priRefreshDataGrid();
            }
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseInfo useCaseItem)
            {
                SwUseCaseDesignService.getInstance().moveUpDownUseCase(useCaseItem.Id, false);
                this.priRefreshDataGrid();
            }
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseInfo useCaseItem)
            {
                SwUseCaseDesignService.getInstance().moveUpDownUseCase(useCaseItem.Id, true);
                this.priRefreshDataGrid();
            }
        }

        private void btnDebug_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
