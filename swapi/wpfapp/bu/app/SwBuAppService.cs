using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpfapp.bu.log;
using wpfapp.bu.vo;
using wpfapp.nbi_web;
using Xarial.XCad.SolidWorks;

namespace wpfapp.bu.app
{
    /// <summary>
    /// APP服务
    /// </summary>
    public class SwBuAppService
    {
        #region Fields

        private static SwBuAppService _instance = new SwBuAppService();
        private ISwApplication _swApp = null;

        #region WebServer

        private IDisposable _webApp;
        private static string WebApiBaseUrl = System.Configuration.ConfigurationManager.AppSettings["WebApiBaseUrl"];

        #endregion

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwBuAppService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwBuAppService getInstance()
        {
            return _instance;
        }

        #endregion

        #region init

        public void init()
        {
            priStartWebHost();
        }

        public void destroy()
        {
            priStopWebHost();
        }

        #endregion

        #region 连接SolidWorks

        /// <summary>
        /// 连接Sw
        /// </summary>
        /// <returns>RespVo</returns>
        public RespVo connectSw()
        {
            var swProcess = Process.GetProcessesByName("SLDWORKS");
            if (!swProcess.Any())
            {
                // 没有打开SolidWorks
                return RespVoLogExt.genError("SolidWorks 没有打开，请打开SolidWorks后再试");
            }

            _swApp = SwApplicationFactory.FromProcess(swProcess.First());

            // 如果连接成功，则返回SolidWorks版本
            return RespVoLogExt.genOk("连接SolidWorks成功，版本:" + _swApp.Version.ToString());
        }

        #endregion

        #region get

        public ISwApplication getSwApp()
        {
            return _swApp;
        }

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

        public static string getAppPath()
        {
            string strAppPath = Path.GetDirectoryName(typeof(MainWindow).Assembly.Location);
            return strAppPath;
        }

        public static string getAppResDirPath()
        {
            string strResDirPath = Path.Combine(getAppPath(), "res");
            return strResDirPath;
        }

        public static string getAppResFilePath(string strFileName)
        {
            string strDocPath = Path.Combine(getAppResDirPath(), strFileName);
            return strDocPath;
        }

        #endregion

        #region WebServer

        private void priStartWebHost()
        {
            try
            {
                _webApp = WebApp.Start<Startup>(url: WebApiBaseUrl);
                SwBuLogService.SInfo($"WebServer 启动成功: {WebApiBaseUrl}");
            }
            catch (Exception ex)
            {
                SwBuLogService.SError($"WebServer 启动异常: {ex.ToString()}");
            }
        }
        private void priStopWebHost()
        {
            _webApp?.Dispose();
            _webApp = null;
        }

        #endregion
    }
}
