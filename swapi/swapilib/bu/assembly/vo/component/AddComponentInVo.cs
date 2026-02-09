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
    [DisplayName("装配体插入单个零部件")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class AddComponentInVo
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
        /// 打开文档模式
        /// </summary>
        [DisplayName("打开文档模式")]
        [Description("打开文档模式。")]
        [PropertyOrder(2)]
        public swAddComponentConfigOptions_ext ConfigOption { get; set; } = 0;

        /// <summary>
        /// 新装配体配置名称
        /// </summary>
        [DisplayName("新装配体配置名称")]
        [Description("新装配体配置名称。仅当打开文档模式取值为NewConfigWithAllReferenceModels或NewConfigWithAsmStructure时有效")]
        [PropertyOrder(3)]
        public string NewConfigName { get; set; } = "";

        /// <summary>
        /// 是否使用已加载零部件配置名称
        /// </summary>
        [DisplayName("是否使用已加载零部件配置名称")]
        [Description("true：使用，false-反之。")]
        [PropertyOrder(4)]
        public bool UseConfigForPartReferences { get; set; } = false;

        /// <summary>
        /// 已加载零部件配置名称
        /// </summary>
        [DisplayName("已加载零部件配置名称")]
        [Description("是否使用已加载零部件配置名称为true时有效。")]
        [PropertyOrder(5)]
        public string ExistingConfigName { get; set; } = "";

        /// <summary>
        /// 零部件中心坐标-X
        /// </summary>
        [DisplayName("零部件中心坐标-X")]
        [Description("零部件中心坐标-X。")]
        [PropertyOrder(6)]
        public double X { get; set; } = 1;

        /// <summary>
        /// 零部件中心坐标-Y
        /// </summary>
        [DisplayName("零部件中心坐标-Y")]
        [Description("零部件中心坐标-Y。")]
        [PropertyOrder(7)]
        public double Y { get; set; } = 1;

        /// <summary>
        /// 零部件中心坐标-Z
        /// </summary>
        [DisplayName("零部件中心坐标-Z")]
        [Description("零部件中心坐标-Z。")]
        [PropertyOrder(8)]
        public double Z { get; set; } = 1;

        /// <summary>
        /// 零部件名称
        /// </summary>
        [DisplayName("零部件名称")]
        [Description("设置新添加的零部件名称，为空则不设置")]
        [PropertyOrder(9)]
        public string ComponentName { get; set; } = "零部件1";

        #endregion
    }
}
