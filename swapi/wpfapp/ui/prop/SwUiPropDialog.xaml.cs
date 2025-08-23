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

namespace wpfapp.ui.prop
{
    /// <summary>
    /// SwUiPropDialog.xaml 的交互逻辑
    /// </summary>
    public partial class SwUiPropDialog : Window
    {
        #region Fields

        private object propObj = null;

        #endregion

        #region Construction

        public SwUiPropDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region PropObj

        public void setPropObj(object oPropObj)
        {
            propObj = oPropObj;
            propertyGrid.SelectedObject = oPropObj;
        }

        public object getPropObj()
        {
            return propObj;
        }

        #endregion

        private void Button_ClickOk(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_ClickCancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
