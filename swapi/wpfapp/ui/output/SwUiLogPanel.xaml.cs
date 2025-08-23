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

namespace wpfapp.ui.output
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    /// <summary>
    /// SwUiLogPanel.xaml 的交互逻辑
    /// </summary>
    public partial class SwUiLogPanel : UserControl
    {
        public SwUiLogPanel()
        {
            InitializeComponent();

            //WordWrapCheckBox.Checked += (s, e) => LogTextBox.TextWrapping = TextWrapping.Wrap;
            //WordWrapCheckBox.Unchecked += (s, e) => LogTextBox.TextWrapping = TextWrapping.NoWrap;
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            Dispatcher.Invoke(() =>
            {
                var paragraph = new Paragraph();

                // 根据日志级别设置颜色
                switch (level)
                {
                    case LogLevel.Debug:
                        paragraph.Foreground = Brushes.Gray;
                        break;
                    case LogLevel.Info:
                        paragraph.Foreground = Brushes.Black;
                        break;
                    case LogLevel.Warning:
                        paragraph.Foreground = Brushes.Orange;
                        break;
                    case LogLevel.Error:
                        paragraph.Foreground = Brushes.Red;
                        break;
                }

                paragraph.Inlines.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
                LogTextBox.Document.Blocks.Add(paragraph);

                // 自动滚动到底部
                if (AutoScrollCheckBox.IsChecked == true)
                {
                    LogTextBox.ScrollToEnd();
                }
            });
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            LogTextBox.Document.Blocks.Clear();
        }
    }
}
