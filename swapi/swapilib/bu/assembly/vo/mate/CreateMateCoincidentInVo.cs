using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace swapilib.bu.assembly.vo.mate
{
    [DisplayName("创建重合配合")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class CreateMateCoincidentInVo
    {
        #region Fields

        /// <summary>
        /// 要添加为零部件的预加载零件或装配体的路径名
        /// </summary>
        [DisplayName("配合对齐方式")]
        [Description("配合对齐方式。")]
        [PropertyOrder(1)]
        public swMateAlign_ext MateAlignment { get; set; } = 0;

        #endregion
    }
}
