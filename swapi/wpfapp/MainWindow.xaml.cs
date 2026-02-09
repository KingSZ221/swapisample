using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using Xarial.XCad.SolidWorks;
using SolidWorks.Interop.swconst;
using System.IO;
using SolidWorks.Interop.sldworks;
using Microsoft.Owin.Hosting;
using swapiapp.nbi_web;
using System.Configuration;
using swapiapp.ui.menu;
using swapiapp.ui.output;
using swapilib.bu.app;
using swapilib.bu.file;
using swapilib.bu.modeldoc;
using swapilib.bu.sketch;
using swapilib.bu.feature;
using swapilib.bu.assembly;
using swapilib.bu.log;
using swapiapp.ui.mainwindow;

namespace swapiapp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        #endregion

        #region Construction

        public MainWindow()
        {
            InitializeComponent();

            // 初始化Service
            SwBuAppService.getInstance().init(SwMainWindowService.getAppPath());
            SwBuFileService.getInstance().init();
            SwBuModelDocService.getInstance().init();
            SwBuSketchService.getInstance().init();
            SwBuFeatureService.getInstance().init();
            SwBuAssemblyService.getInstance().init();

            // 初始化UI
            SwUiMenuService.getInstance().init(this.mainMenu, this.mainToobar);
            SwUiOutputService.getInstance().init(this.mainOutput);

            // 初始化Service
            SwBuLogService.createInstance(SwUiOutputService.getInstance());

            // 启动WebServer
            SwApiWebServer.getInstance().init();
        }

        #endregion

        #region events

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            SwBuAppService.getInstance().destroy();
        }

        #endregion
    }
}
