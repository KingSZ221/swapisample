using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.basic.io
{
    public class PathUtilsEx
    {
        /// <summary>
        /// 获取当前执行程序集的文件路径
        /// </summary>
        public static string GetAssemblyFilePath()
        {
            return Assembly.GetExecutingAssembly().Location;
        }

        /// <summary>
        /// 获取当前执行程序集的目录路径
        /// </summary>
        public static string GetAssemblyDirectory()
        {
            return Path.GetDirectoryName(GetAssemblyFilePath());
        }

        /// <summary>
        /// 获取相对于程序集目录的完整路径
        /// </summary>
        public static string GetRelativeToAssemblyPath(string relativePath)
        {
            string assemblyDir = GetAssemblyDirectory();
            return Path.Combine(assemblyDir, relativePath);
        }
    }
}
