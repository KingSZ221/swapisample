using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using wpfapp.bu.log;

namespace wpfapp.ui.output
{
    public class SwUiOutputService : ILogService
    {
        #region Fields

        private static SwUiOutputService _instance = new SwUiOutputService();

        private SwUiLogPanel _swUiLogPanel = null;

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwUiOutputService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwUiOutputService getInstance()
        {
            return _instance;
        }

        #endregion

        #region init

        public void init(TabControl mainOutput)
        {
            TabItem logTabItem = new TabItem();
            logTabItem.Header = "系统日志";
            mainOutput.Items.Add(logTabItem);

            _swUiLogPanel = new SwUiLogPanel();
            logTabItem.Content = _swUiLogPanel;
        }

        public void destroy()
        {

        }

        #endregion

        #region 日志

        void ILogService.Debug(string message)
        {
            _swUiLogPanel.Log(message, LogLevel.Debug);
        }

        void ILogService.Info(string message)
        {
            _swUiLogPanel.Log(message, LogLevel.Info);
        }

        void ILogService.Warning(string message)
        {
            _swUiLogPanel.Log(message, LogLevel.Warning);
        }

        void ILogService.Error(string message)
        {
            _swUiLogPanel.Log(message, LogLevel.Error);
        }

        void ILogService.Exception(Exception ex, string message)
        {
            _swUiLogPanel.Log(message + ",exceptoin " + ex.ToString(), LogLevel.Error);
        }

        #endregion
    }
}
