using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.sketch.vo.feature.sweep
{
    [DisplayName("创建扫描基体/凸台特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class FeatureSweepInVo
    {
        #region Fields

        /// <summary>
        /// 轮廓类型
        /// </summary>
        [DisplayName("轮廓类型")]
        [Description("可选值:0-草图轮廓,1-圆形轮廓。")]
        [Category("轮廓和路径")]
        public int ContourType { get; set; } = 0;

        /// <summary>
        /// 扫描轮廓
        /// </summary>
        [DisplayName("扫描轮廓")]
        [Description("扫描轮廓。" +
            "如果是草图轮廓，使用Mark=1选取面、边或曲线。对于扫描凸台特征，必须为闭合的草图轮廓。对于扫描曲面特征，草图轮廓是开放的或闭合的。" +
            "如果是圆形轮廓，使用Mark=4选择草图线、边或曲线。圆形轮廓是打开的或封闭的。" +
            "如果是实体轮廓，使用Mark=1选择要用于进行扫描切除工具实体，并使用Mark=2048选择要被切除的实体。实体轮廓仅用于扫描切除特征。")]
        [Category("轮廓和路径")]
        public EntitySelectId Contour { get; set; } = new EntitySelectId();

        /// <summary>
        /// 扫描路径
        /// </summary>
        [DisplayName("扫描路径")]
        [Description("扫描路径，使用Mark=4。" +
            "选取包含在一个草图、一条曲线或一组模型边中的一组草图曲线。" +
            "扫描路径是打开的或封闭的。" +
            "扫描路径的起点必须位于轮廓的平面上，以进行1个方向扫描。如果扫描路径延伸到轮廓的两侧，则可以创建双向扫描。" +
            "扫描路径不用于圆形轮")]
        [Category("轮廓和路径")]
        public EntitySelectId Path { get; set; } = new EntitySelectId();

        /// <summary>
        /// 引导线
        /// </summary>
        [DisplayName("引导线")]
        [Description("引导线，使用Mark=2。")]
        [Category("轮廓和路径")]
        public List<EntitySelectId> GuideCurves { get; set; } = new List<EntitySelectId>();

        /// <summary>
        /// 扫描特征名称
        /// </summary>
        [DisplayName("扫描特征名称")]
        [Description("设置扫描特征名称")]
        [Category("扫描特征名称")]
        public string FeatrueName { get; set; } = "";

        #endregion
    }
}
