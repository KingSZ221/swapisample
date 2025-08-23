using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.log
{
    /// <summary>
    /// 日志服务
    /// </summary>
    public interface ILogService
    {
        void Debug(string message);
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Exception(Exception ex, string message = null);
    }
}
