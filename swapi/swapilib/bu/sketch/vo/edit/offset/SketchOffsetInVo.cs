using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.edit.offset
{
    /// <summary>
    /// 偏移实体
    /// </summary>
    [DisplayName("偏移实体")]
    public class SketchOffsetInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 偏移值
        /// </summary>
        [DisplayName("偏移值")]
        [Description("偏移值；负值会使草图实体向相反方向偏移")]
        public double Offset { get; set; } = 20;

        /// <summary>
        /// 偏移方向
        /// </summary>
        [DisplayName("偏移方向")]
        [Description("真值用于在两个方向上对草图实体进行偏移，假值则用于在单个方向上对草图实体进行偏移。")]
        public bool BothDirections { get; set; } = false;

        /// <summary>
        /// 选择链
        /// </summary>
        [DisplayName("选择链")]
        [Description("对于链状的草图实体，选择“真”选项可对其进行整体偏移；而对于单独的草图实体，则选择“假”选项即可对其进行单独偏移。")]
        public bool Chain { get; set; } = false;

        /// <summary>
        /// 两端封头方式
        /// </summary>
        [DisplayName("两端进行封头")]
        [Description("按照 swSkOffsetCapEndType_e 中所定义的方式对两端进行封头处理。" +
            "0：两端不封头，1：两端用弧线封头，2：两端用直线封头")]
        public int CapEnds { get; set; } = 0;

        /// <summary>
        /// 转换成构造线
        /// </summary>
        [DisplayName("转换成构造线")]
        [Description("将原始和偏移的草图实体转换为按照 swSkOffsetMakeConstructionType_e 定义的构造草图实体。" +
            "0:不要将原始或偏移的草图实体转换为构造草图实体;" +
            "1:仅将原始的草图实体转换为构造草图实体;" +
            "2:仅将偏移草图实体转换为构造草图实体;" +
            "3:将原始草图实体和偏移草图实体转换为构造草图实体")]
        public int MakeConstruction { get; set; } = 0;

        /// <summary>
        /// 标注偏移距离
        /// </summary>
        [DisplayName("标注偏移距离")]
        [Description("“在草图中标注偏移距离”为“是”，“不在草图中标注偏移距离”为“否”")]
        public bool AddDimensions { get; set; } = true;

        #endregion
    }
}
