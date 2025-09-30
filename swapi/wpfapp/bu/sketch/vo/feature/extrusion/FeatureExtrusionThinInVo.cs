using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.feature.extrusion
{
    [DisplayName("薄壁拉伸")]
    public class FeatureExtrusionThinInVo
    {
        #region Fields

        /// <summary>
        /// 单向拉伸
        /// </summary>
        [DisplayName("单向拉伸")]
        [Description("true:单向拉伸，false:双向拉伸")]
        [Category("Misc")]
        public bool Sd { get; set; } = false;

        /// <summary>
        /// 拉伸方向1拉伸距离(mm)
        /// </summary>
        [DisplayName("拉伸方向1拉伸距离(mm)")]
        [Description("mm")]
        [Category("Misc")]
        public double D1 { get; set; } = 1000;

        /// <summary>
        /// 拉伸方向2拉伸距离(mm)
        /// </summary>
        [DisplayName("拉伸方向2拉伸距离(mm)")]
        [Description("mm")]
        [Category("Misc")]
        public double D2 { get; set; } = 1000;

        /// <summary>
        /// 壁厚(mm)
        /// </summary>
        [DisplayName("壁厚(mm)")]
        [Description("mm")]
        [Category("Misc")]
        public double Thk1 { get; set; } = 2;

        /// <summary>
        /// 拉伸草图轮廓
        /// </summary>
        [DisplayName("拉伸草图轮廓名称")]
        [Description("Arc1@草图2")]
        [Category("Misc")]
        public string ContourName { get; set; } = "";

        /// <summary>
        /// 拉伸草图轮廓
        /// </summary>
        [DisplayName("拉伸特征名称")]
        [Description("Arc1@草图2")]
        [Category("Misc")]
        public string FeatrueName { get; set; } = "";

        #endregion
    }
}
