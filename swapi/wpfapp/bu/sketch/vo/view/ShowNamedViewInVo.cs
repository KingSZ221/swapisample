using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.view
{
    [DisplayName("显示视图")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class ShowNamedViewInVo
    {
        #region Fields

        /// <summary>
        /// 视图名称
        /// </summary>
        [DisplayName("视图名称")]
        [Description("如果视图名称为空，则使用视图ID")]
        public string VName { get; set; } = "";

        /// <summary>
        /// 视图ID
        /// </summary>
        [DisplayName("视图ID")]
        [Description("-1：使用视图名称，见swStandardViews_e")]
        public int ViewId { get; set; } = 7;

        #endregion
    }
}
