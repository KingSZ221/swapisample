using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using swapilib.bu.log;

namespace swapiapp.nbi_web
{
    class SwApiWebServer
    {
        #region Fields

        private static SwApiWebServer _instance = new SwApiWebServer();

        #region WebServer

        private IDisposable _webApp;
        private static string WebApiBaseUrl = System.Configuration.ConfigurationManager.AppSettings["WebApiBaseUrl"];

        #endregion

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwApiWebServer() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwApiWebServer getInstance()
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
