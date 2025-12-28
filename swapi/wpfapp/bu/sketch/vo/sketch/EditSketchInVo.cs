using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.modeldoc.vo.select;

namespace wpfapp.bu.sketch.vo.sketch
{
    [DisplayName("草图绘制")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
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
        /// 选择基准面类型
        /// </summary>
        [DisplayName("选择基准面类型")]
        [Category("草图")]
        [Description("0：参考基准面名称，1：选择一个实体的面作为基准面")]
        public int SelectRefPlaneType { get; set; } = 0;

        /// <summary>
        /// 基准面名称
        /// </summary>
        [DisplayName("基准面名称")]
        [Category("草图")]
        [Description("如果草图名称为空，则选中参考基准面绘制草图; \r\n如果参考基准面为空，则以前视基准面绘制草图")]
        public string RefPlaneName { get; set; } = "";

        /// <summary>
        /// 射线选择基准面
        /// </summary>
        [DisplayName("射线选择基准面")]
        [Category("草图")]
        [Description("选择基准面类型=1时生效")]
        public SelectByRayInVo SelectRefPlaneByRay { get; set; } = new SelectByRayInVo();

        #endregion
    }
}
