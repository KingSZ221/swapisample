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
using wpfapp.bu.usecase.vo;

namespace wpfapp.ui.usecase
{
    /// <summary>
    /// SwUseCaseInfoPanel.xaml 的交互逻辑
    /// </summary>
    public partial class SwUseCaseInfoPanel : Window
    {
        private bool bEdit = false;
        private SwUseCaseItem useCaseItem;

        public SwUseCaseInfoPanel(Window p_Owner, bool p_bEdit, SwUseCaseItem p_useCaseItem)
        {
            InitializeComponent();

            this.Owner = p_Owner;
            this.priInitUseCase(p_bEdit, p_useCaseItem);
        }

        private void priInitUseCase(bool p_bEdit, SwUseCaseItem p_useCaseItem)
        {
            this.useCaseItem = p_useCaseItem;
            this.bEdit = p_bEdit;
            this.Title = this.bEdit ? "编辑用例" : "新增用例";
            this.txtId.Text = p_useCaseItem.Id;
            this.txtName.Text = p_useCaseItem.Name;
            this.txtDesc.Text = p_useCaseItem.Desc;
            this.txtGroup.Text = p_useCaseItem.Group;

            this.priInitStepList();
        }

        private void priInitStepList()
        {
            this.gridSteps.ItemsSource = this.useCaseItem.Steps;
        }

        private void priRefreshDataGrid()
        {
            this.gridSteps.ItemsSource = this.useCaseItem.Steps;
            this.gridSteps.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SwUseCaseStepItem useCaseStepItemNew = new SwUseCaseStepItem();
            useCaseStepItemNew.Name = "步骤1";
            var editWindow = new SwUseCaseStepInfoPanel(this, false, useCaseStepItemNew);
            if (editWindow.ShowDialog() == true)
            {
                this.useCaseItem.addStep(useCaseStepItemNew);
                this.priRefreshDataGrid();
            }
        }

        private void btnRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            this.useCaseItem.removeAllStep();
            this.priRefreshDataGrid();
        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseStepItem)
            {
                SwUseCaseStepItem useCaseStepItemUpdate = new SwUseCaseStepItem(useCaseStepItem);
                var editWindow = new SwUseCaseStepInfoPanel(this, true, useCaseStepItemUpdate);
                if (editWindow.ShowDialog() == true)
                {
                    this.useCaseItem.updateStep(useCaseStepItem, useCaseStepItemUpdate);
                    this.priRefreshDataGrid();
                }
            }
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseStepItem)
            {
                this.useCaseItem.copyStep(useCaseStepItem);
                this.priRefreshDataGrid();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes != MessageBox.Show(this, "确认删除吗？", "确认", MessageBoxButton.YesNo))
            {
                return;
            }

            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseStepItem)
            {
                this.useCaseItem.removeStep(useCaseStepItem);
                this.priRefreshDataGrid();
            }
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseStepItem)
            {
                this.useCaseItem.moveUpDownStep(useCaseStepItem, false);
                this.priRefreshDataGrid();
            }
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SwUseCaseStepItem useCaseStepItem)
            {
                this.useCaseItem.moveUpDownStep(useCaseStepItem, true);
                this.priRefreshDataGrid();
            }
        }

        private void btnDebug_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.useCaseItem.Name = this.txtName.Text;
            this.useCaseItem.Desc = this.txtDesc.Text;
            this.useCaseItem.Group = this.txtGroup.Text;
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
