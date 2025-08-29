using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.sketch
{
    [DisplayName("草图绘制")]
    public class EditSketchInVo
    {
        #region Fields

        /// <summary>
        /// 草图名称
        /// </summary>
        [DisplayName("草图名称")]
        [Category("草图")]
        [Description("如果草图名称不为空，则打开该草图进行绘制")]
        public string SketchName { get; set; } = "";

        /// <summary>
        /// 绘制完后是否退出编辑模式
        /// </summary>
        [DisplayName("基准面名称")]
        [Category("草图")]
        [Description("如果草图名称为空，则选中参考基准面绘制草图; \r\n如果参考基准面为空，则以前视基准面绘制草图")]
        public string RefPlaneName { get; set; } = "";

        #endregion
    }
}
