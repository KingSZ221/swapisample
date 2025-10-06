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
using wpfapp.ui.prop;

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
        /// <summary>
        /// 日志对象连接
        /// </summary>
        private List<object> logObjectLinks = new List<object>();

        public SwUiLogPanel()
        {
            InitializeComponent();

            LogTextBox.IsDocumentEnabled = true;
            LogTextBox.IsReadOnly = true;

            //WordWrapCheckBox.Checked += (s, e) => LogTextBox.TextWrapping = TextWrapping.Wrap;
            //WordWrapCheckBox.Unchecked += (s, e) => LogTextBox.TextWrapping = TextWrapping.NoWrap;
        }

        public void Log(string message, LogLevel level = LogLevel.Info, object obj = null)
        {
            //Dispatcher.Invoke(() =>
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

                // 添加文本
                paragraph.Inlines.Add($"[{DateTime.Now:HH:mm:ss}] {message}");

                // 添加对象
                if (obj != null)
                {
                    // 添加操作对象链接
                    logObjectLinks.Add(obj);

                    // 创建新的 Hyperlink 对象
                    Hyperlink customLink = new Hyperlink();

                    // 设置链接的显示文本
                    customLink.Inlines.Add($"查看操作结果:{logObjectLinks.Count()}");

                    // 设置链接的样式（可选）
                    customLink.Foreground = Brushes.Blue;
                    //customLink.TextDecorations = null; // 移除默认的下划线（可选）

                    // 订阅点击事件
                    customLink.Click += DynamicLink_Click;

                    // 6. 还可以设置ToolTip等其他属性
                    customLink.ToolTip = "查看操作结果";

                    paragraph.Inlines.Add(new Run(" "));
                    paragraph.Inlines.Add(customLink);
                }

                // 插入段落
                LogTextBox.Document.Blocks.Add(paragraph);

                // 自动滚动到底部
                //if (AutoScrollCheckBox.IsChecked == true)
                {
                    LogTextBox.ScrollToEnd();
                }
            }//);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            LogTextBox.Document.Blocks.Clear();
        }

        private void DynamicLink_Click(object sender, RoutedEventArgs e)
        {
            // sender 获取是哪个链接被点击了
            Hyperlink clickedLink = sender as Hyperlink;
            if (clickedLink != null)
            {
                string[] linkText = new TextRange(clickedLink.ContentStart, clickedLink.ContentEnd).Text.Split(':');
                int linkId = int.Parse(linkText[1]);
                SwUiPropService.getInstance().showPropObjDlg("查看操作结果", "操作结果如下:", logObjectLinks[linkId - 1]);
            }
        }
    }

}
