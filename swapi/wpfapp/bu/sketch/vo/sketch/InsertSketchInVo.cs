using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace wpfapp.bu.sketch.vo.sketch
{
    [DisplayName("插入草图")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class InsertSketchInVo
    {
        #region Fields

        /// <summary>
        /// 草图名称
        /// </summary>
        [DisplayName("重建")]
        [Description("如果为true，则根据草图中的任何更改重建部分并退出草图模式；反之，则不进行此操作。")]
        [PropertyOrder(1)]
        public bool UpdateEditRebuild { get; set; } = true;

        /// <summary>
        /// 草图名称
        /// </summary>
        [DisplayName("草图名称")]
        [Description("如果草图名称不为空，则设置当前草图名称")]
        [PropertyOrder(2)]
        public string SketchName { get; set; } = "";

        #endregion
    }
}
