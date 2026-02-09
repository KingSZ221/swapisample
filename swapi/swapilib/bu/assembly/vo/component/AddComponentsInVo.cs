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
    [DisplayName("单个零部件")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class AddComponentInfoVo
    {
        #region Fields

        /// <summary>
        /// 要添加为零部件的预加载零件或装配体的路径名
        /// </summary>
        [DisplayName("零部件文件路径名")]
        [Description("要添加为零部件的预加载零件或装配体的路径名。")]
        [PropertyOrder(1)]
        public string CompName { get; set; } = "";

        /// <summary>
        /// 自定义坐标系名称
        /// </summary>
        [DisplayName("自定义坐标系名称")]
        [Description("如果自定义坐标系名称为空字符串，则该零部件将以相对于零部件的缺省坐标系放置在装配体中。")]
        [PropertyOrder(2)]
        public string CoordinateSystemName { get; set; } = "";

        /// <summary>
        /// 零部件变换矩阵
        /// </summary>
        [DisplayName("零部件变换矩阵")]
        [Description("零部件变换矩阵。")]
        [PropertyOrder(3)]
        public TransformMatrixVo TransformMatrix { get; set; } = new TransformMatrixVo();
        
        /// <summary>
        /// 零部件名称
        /// </summary>
        [DisplayName("零部件名称")]
        [Description("设置新添加的零部件名称，为空则不设置")]
        [PropertyOrder(4)]
        public string ComponentName { get; set; } = "";

        #endregion
    }

    [DisplayName("添加多个零部件")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class AddComponentsInVo
    {
        #region Fields

        /// <summary>
        /// 要添加为零部件的预加载零件或装配体的路径名
        /// </summary>
        [DisplayName("零部件列表")]
        [Description("按顺序添加零部件。")]
        [PropertyOrder(1)]
        public List<AddComponentInfoVo> ComponentInfoVos { get; set; } = new List<AddComponentInfoVo>();

        #endregion
    }
}
