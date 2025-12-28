using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace wpfapp.bu.assembly.vo.component
{
    [DisplayName("浮动零部件")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class UnfixComponentInVo
    {
        #region Fields


        #endregion
    }
}
