using swapiapp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace swapiapp.ui.mainwindow
{
    public class SwMainWindowService
    {
        public static Window getMainWindow()
        {
            if (Application.Current == null)
                return null;

            // 检查主窗口是否仍然有效
            if (Application.Current.MainWindow != null &&
                !Equals(Application.Current.MainWindow, null))
            {
                return Application.Current.MainWindow;
            }

            // 如果没有设置主窗口，尝试查找
            return Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }

        public static MainWindow getMainWindow2()
        {
            if (Application.Current == null)
                return null;

            // 如果没有设置主窗口，尝试查找
            return Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }

        public static string getAppPath()
        {
            string strAppPath = Path.GetDirectoryName(typeof(MainWindow).Assembly.Location);
            return strAppPath;
        }
    }
}
