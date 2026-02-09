using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.modeldoc.vo.select
{
    /// <summary>
    /// 清空选择对象
    /// </summary>
    [DisplayName("清空选择对象列表")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class ClearSelectionInVo
    {
        #region Fields

        /// <summary>
        /// 清空选择对象
        /// </summary>
        [DisplayName("清空选择对象")]
        [Description("ture:清空已选中对象列表, false:仅清空激活的选中对象列表")]
        public bool All { get; set; } = true;

        #endregion
    }
}
