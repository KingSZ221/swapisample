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
using wpfapp.bu.cmd;
using wpfapp.bu.cmd.cmdtype;
using wpfapp.bu.sketch.vo.draw.arc;
using wpfapp.bu.usecase.vo;

namespace wpfapp.ui.usecase
{
    /// <summary>
    /// SwUseCaseCmdInfoPanel.xaml 的交互逻辑
    /// </summary>
    public partial class SwUseCaseCmdInfoPanel : Window
    {
        private bool bInit = false;
        private bool bEdit = false;
        private SwUseCaseStepCmdItem useCaseStepCmdItem;

        public SwUseCaseCmdInfoPanel(Window p_Owner, bool p_bEdit, SwUseCaseStepCmdItem p_useCaseStepCmdItem)
        {
            InitializeComponent();

            this.Owner = p_Owner;
            this.priInitCmd(p_bEdit, p_useCaseStepCmdItem);
        }

        private void priInitCmd(bool p_bEdit, SwUseCaseStepCmdItem p_useCaseStepCmdItem)
        {
            this.useCaseStepCmdItem = p_useCaseStepCmdItem;
            this.bEdit = p_bEdit;
            this.Title = this.bEdit ? "编辑命令" : "新增命令";

            this.priInitCmdType();
            this.priRefresPropertyGrid();
        }

        private void priInitCmdType()
        {
            this.bInit = true;
            this.comboBoxModule.ItemsSource = SwCmdTypeManager.getInstance().getModules();
            this.comboBoxModule.SelectedItem = useCaseStepCmdItem.CmdModule;
            this.comboBoxCmd.ItemsSource = SwCmdTypeManager.getInstance().getCmdsByModule(useCaseStepCmdItem.CmdModule);
            this.comboBoxCmd.SelectedItem = SwCmdTypeManager.getInstance().getByTypeId(useCaseStepCmdItem.CmdModule, useCaseStepCmdItem.CmdTypeId);
            this.propertyGridCmd.SelectedObject = useCaseStepCmdItem.CmdInVoObj;
            this.bInit = false;
        }

        private void priRefresPropertyGrid()
        {
            this.propertyGridCmd.SelectedObject = useCaseStepCmdItem.CmdInVoObj;
        }

        private void comboBoxModule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bInit)
            {
                return;
            }

            if (comboBoxModule.SelectedItem is string selectedModule)
            {
                useCaseStepCmdItem.CmdModule = selectedModule;

                // 刷新命令列表
                List<SwCmdType> cmds = SwCmdTypeManager.getInstance().getCmdsByModule(selectedModule);
                this.comboBoxCmd.ItemsSource = cmds;
                this.comboBoxCmd.SelectedItem = cmds[0];

                // 刷新当前命令
                useCaseStepCmdItem.CmdTypeId = cmds[0].CmdTypeId;
                useCaseStepCmdItem.CmdName = cmds[0].CmdTypeName;
                useCaseStepCmdItem.CmdInVoObj = Activator.CreateInstance(cmds[0].ActionInVoType);

                priRefresPropertyGrid();
            }
        }

        private void comboBoxCmd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(bInit)
            {
                return;
            }

            if (comboBoxCmd.SelectedItem is SwCmdType selectedCmd)
            {
                useCaseStepCmdItem.CmdTypeId = selectedCmd.CmdTypeId;
                useCaseStepCmdItem.CmdName = selectedCmd.CmdTypeName;
                useCaseStepCmdItem.CmdInVoObj = Activator.CreateInstance(selectedCmd.ActionInVoType);

                priRefresPropertyGrid();
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            useCaseStepCmdItem.updateCmdInVoJson();
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
