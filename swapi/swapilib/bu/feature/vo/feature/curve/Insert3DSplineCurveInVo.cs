using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace swapilib.bu.feature.vo.feature.curve
{
    [DisplayName("创建3D样条曲线")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class Insert3DSplineCurveInVo
    {
        #region Fields

        /// <summary>
        /// 是否封闭
        /// </summary>
        [DisplayName("是否封闭")]
        [Description("true：封闭，false：不封闭。")]
        [PropertyOrder(1)]
        public bool CurveClosed { get; set; } = false;

        #endregion
    }
}
