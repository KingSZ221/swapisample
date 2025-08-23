using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.log
{
    public class SwBuLogService : ILogService
    {
        #region Fields

        private readonly IEnumerable<ILogService> _logServices;

        private static SwBuLogService _instance = new SwBuLogService();

        #endregion

        #region Construction

        SwBuLogService(params ILogService[] logServices)
        {
            _logServices = logServices;
        }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static ILogService getInstance()
        {
            return _instance;
        }

        public static ILogService createInstance(params ILogService[] logServices)
        {
            return _instance = new SwBuLogService(logServices);
        }

        #endregion

        #region 打印日志

        public void Debug(string message)
        {
            foreach (var logger in _logServices)
                logger.Debug(message);
        }

        public void Error(string message)
        {
            foreach (var logger in _logServices)
                logger.Error(message);
        }

        public void Exception(Exception ex, string message = null)
        {
            foreach (var logger in _logServices)
                logger.Exception(ex, message);
        }

        public void Info(string message)
        {
            foreach (var logger in _logServices)
                logger.Info(message);
        }

        public void Warning(string message)
        {
            foreach (var logger in _logServices)
                logger.Warning(message);
        }

        #endregion

        #region 打印日志2

        public static void SDebug(string message)
        {
            if(_instance != null)
            {
                _instance.Debug(message);
            }
        }

        public static void SError(string message)
        {
            if (_instance != null)
            {
                _instance.Error(message);
            }
        }

        public static void SException(Exception ex, string message = null)
        {
            if (_instance != null)
            {
                _instance.Exception(ex, message);
            }
        }

        public static void SInfo(string message)
        {
            if (_instance != null)
            {
                _instance.Info(message);
            }
        }

        public static void SWarning(string message)
        {
            if (_instance != null)
            {
                _instance.Warning(message);
            }
        }

        #endregion
    }
}
