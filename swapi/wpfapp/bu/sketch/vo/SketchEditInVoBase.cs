using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo
{
    /// <summary>
    /// 草图绘制操作InVo基类
    /// </summary>
    public class SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 草图名称
        /// </summary>
        [DisplayName("草图名称")]
        [Category("草图")]
        [Description("如果草图名称不为空，则打开该草图进行绘制；\r\n如果草图名称为空，则在当前打开的草图中绘制; \r\n如果当前未打开草图，则以前视基准面创建草图")]
        public string SketchName { get; set; } = "";

        /// <summary>
        /// 绘制完后是否退出编辑模式
        /// </summary>
        [DisplayName("退出编辑")]
        [Category("草图")]
        [Description("true-绘制完成后退出编辑模式，false-反之")]
        public bool ExitEdit { get; set; } =  false;

        #endregion
    }
}
