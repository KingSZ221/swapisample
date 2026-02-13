using swapilib.bu.usecase.vo;
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

namespace swapiapp.ui.usecase
{
    /// <summary>
    /// SwUseCaseStepInfoPanel.xaml 的交互逻辑
    /// </summary>
    public partial class SwUseCaseStepInfoPanel : Window
    {
        private bool bEdit = false;
        private SwUseCaseStepItem useCaseStepItem;

        public SwUseCaseStepInfoPanel(Window p_Owner, bool p_bEdit, SwUseCaseStepItem p_useCaseStepItem)
        {
            InitializeComponent();

            this.Owner = p_Owner;
            this.priInitUseCaseStep(p_bEdit, p_useCaseStepItem);
        }

        private void priInitUseCaseStep(bool p_bEdit, SwUseCaseStepItem p_useCaseStepItem)
        {
            this.useCaseStepItem = p_useCaseStepItem;
            this.bEdit = p_bEdit;
            this.Title = this.bEdit ? "编辑步骤" : "新增步骤";
            this.txtName.Text = p_useCaseStepItem.Name;

            this.priInitCmdList();
            this.priInitStepList();
        }

        private void priInitCmdList()
        {
            this.gridCmds.ItemsSource = this.useCaseStepItem.CmdInfos;
        }

        private void priInitStepList()
        {
            this.gridSteps.ItemsSource = this.useCaseStepItem.SubSteps;
        }

        private void priRefreshCmdDataGrid()
        {
            this.gridCmds.ItemsSource = this.useCaseStepItem.CmdInfos;
            this.gridCmds.Items.Refresh();
        }

        private void priRefreshStepDataGrid()
        {
            this.gridSteps.ItemsSource = this.useCaseStepItem.SubSteps;
            this.gridSteps.Items.Refresh();
        }

        private void btnAddCmd_Click(object sender, RoutedEventArgs e)
        {
            SwUseCaseStepCmdItem useCaseStepCmdItemNew = new SwUseCaseStepCmdItem();
            var editWindow = new SwUseCaseCmdInfoPanel(this, false, useCaseStepCmdItemNew);
            if (editWindow.ShowDialog() == true)
            {
                this.useCaseStepItem.addCmd(useCaseStepCmdItemNew);
                this.priRefreshCmdDataGrid();
            }
        }

        private void btnRemoveAllCmd_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes != MessageBox.Show(this, "确认删除吗？", "确认", MessageBoxButton.YesNo))
            {
                return;
            }

            this.useCaseStepItem.removeAllCmd();
            this.priRefreshCmdDataGrid();
        }

        private void btnEditCmd_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepCmdItem useCaseStepCmdItem)
            {
                SwUseCaseStepCmdItem useCaseStepCmdItemUpdate = new SwUseCaseStepCmdItem(useCaseStepCmdItem);
                var editWindow = new SwUseCaseCmdInfoPanel(this, true, useCaseStepCmdItemUpdate);
                if (editWindow.ShowDialog() == true)
                {
                    this.useCaseStepItem.updateCmd(useCaseStepCmdItem, useCaseStepCmdItemUpdate);
                    this.priRefreshCmdDataGrid();
                }
            }
        }

        private void btnCopyCmd_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepCmdItem useCaseStepCmdItem)
            {
                this.useCaseStepItem.copyCmd(useCaseStepCmdItem);
                this.priRefreshCmdDataGrid();
            }
        }

        private void btnRemoveCmd_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepCmdItem useCaseStepCmdItem)
            {
                this.useCaseStepItem.removeCmd(useCaseStepCmdItem);
                this.priRefreshCmdDataGrid();
            }
        }

        private void btnMoveUpCmd_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepCmdItem useCaseStepCmdItem)
            {
                this.useCaseStepItem.moveUpDownCmd(useCaseStepCmdItem, false);
                this.priRefreshCmdDataGrid();
            }
        }

        private void btnMoveDownCmd_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepCmdItem useCaseStepCmdItem)
            {
                this.useCaseStepItem.moveUpDownCmd(useCaseStepCmdItem, true);
                this.priRefreshCmdDataGrid();
            }
        }

        private void btnDebugCmd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            SwUseCaseStepItem useCaseStepSubItemNew = new SwUseCaseStepItem();
            useCaseStepSubItemNew.Name = "子步骤1";
            var editWindow = new SwUseCaseStepInfoPanel(this, false, useCaseStepSubItemNew);
            if (editWindow.ShowDialog() == true)
            {
                this.useCaseStepItem.addSubStep(useCaseStepSubItemNew);
                this.priRefreshStepDataGrid();
            }
        }

        private void btnRemoveAllStep_Click(object sender, RoutedEventArgs e)
        {
            this.useCaseStepItem.removeAllSubStep();
            this.priRefreshStepDataGrid();
        }

        private void btnEditStep_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseSubStepItem)
            {
                SwUseCaseStepItem useCaseStepSubItemUpdate = new SwUseCaseStepItem(useCaseSubStepItem);
                var editWindow = new SwUseCaseStepInfoPanel(this, true, useCaseStepSubItemUpdate);
                if (editWindow.ShowDialog() == true)
                {
                    this.useCaseStepItem.updateSubStep(useCaseSubStepItem, useCaseStepSubItemUpdate);
                    this.priRefreshStepDataGrid();
                }
            }
        }

        private void btnCopyStep_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseSubStepItem)
            {
                this.useCaseStepItem.copySubStep(useCaseSubStepItem);
                this.priRefreshStepDataGrid();
            }
        }

        private void btnRemoveStep_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseSubStepItem)
            {
                this.useCaseStepItem.removeSubStep(useCaseSubStepItem);
                this.priRefreshStepDataGrid();
            }
        }

        private void btnMoveUpStep_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseSubStepItem)
            {
                this.useCaseStepItem.moveUpDownSubStep(useCaseSubStepItem, false);
                this.priRefreshStepDataGrid();
            }
        }

        private void btnMoveDownStep_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseSubStepItem)
            {
                this.useCaseStepItem.moveUpDownSubStep(useCaseSubStepItem, true);
                this.priRefreshStepDataGrid();
            }
        }

        private void btnDebugStep_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.useCaseStepItem.Name = this.txtName.Text;
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
