using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace swapilib.bu.assembly.vo.component
{
    [DisplayName("固定零部件")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class FixComponentInVo
    {
        #region Fields


        #endregion
    }
}
