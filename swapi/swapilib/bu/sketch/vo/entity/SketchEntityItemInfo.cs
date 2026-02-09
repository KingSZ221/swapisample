using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.entity
{
    /// <summary>
    /// 草图实体
    /// </summary>
    [DisplayName("草图实体")]
    public class SketchEntityItemInfo
    {
        #region Fields

        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("实体ID")]
        [Category("基础")]
        public string ID { get; set; } = "";

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [Category("基础")]
        public string Name { get; set; } = "";

        /// <summary>
        /// 类型ID
        /// </summary>
        [DisplayName("类型ID")]
        [Category("基础")]
        public int TypeId { get; set; } = 0;

        /// <summary>
        /// 类型名称
        /// </summary>
        [DisplayName("类型名称")]
        [Category("基础")]
        public string TypeName { get; set; } = "";

        /// <summary>
        /// 长度
        /// </summary>
        [DisplayName("长度")]
        [Category("基础")]
        public double Length { get; set; } = 0;

        /// <summary>
        /// 选择ID
        /// </summary>
        [DisplayName("选择ID")]
        [Category("选择")]
        public EntitySelectId SelectId { get; set; }

        #endregion
    }
}
