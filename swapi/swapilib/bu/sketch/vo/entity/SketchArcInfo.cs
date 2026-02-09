using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.entity
{
    /// <summary>
    /// 草图弧线
    /// </summary>
    [DisplayName("草图弧线")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class SketchArcInfo : SketchSegmentInfo
    {
        #region Fields

        #endregion
    }
}
