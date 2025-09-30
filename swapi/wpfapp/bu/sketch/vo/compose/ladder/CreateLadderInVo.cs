using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.compose.ladder
{
    [DisplayName("创建扶梯")]
    public class CreateLadderInVo
    {
        #region Fields

        #region 面管

        /// <summary>
        /// 面管宽度(mm)
        /// </summary>
        [DisplayName("面管宽度(mm)")]
        [Description("mm")]
        [Category("面管")]
        public double MianGuanWidth { get; set; } = 2000;

        /// <summary>
        /// 面管半径(mm)
        /// </summary>
        [DisplayName("面管半径(mm)")]
        [Description("mm")]
        [Category("面管")]
        public double MianGuanRadius { get; set; } = 50;

        /// <summary>
        /// 面管壁厚(mm)
        /// </summary>
        [DisplayName("面管壁厚(mm)")]
        [Description("mm")]
        [Category("面管")]
        public double MianGuanThickness { get; set; } = 2;

        #endregion

        #region 立柱

        /// <summary>
        /// 立柱高度(mm)
        /// </summary>
        [DisplayName("立柱高度(mm)")]
        [Category("立柱")]
        public double LiZhuHeight { get; set; } = 1500;

        /// <summary>
        /// 立柱半径(mm)
        /// </summary>
        [DisplayName("立柱半径(mm)")]
        [Description("mm")]
        [Category("立柱")]
        public double LiZhuRadius { get; set; } = 40;

        /// <summary>
        /// 立柱壁厚(mm)
        /// </summary>
        [DisplayName("立柱壁厚(mm)")]
        [Description("mm")]
        [Category("立柱")]
        public double LiZhuThickness { get; set; } = 2;

        #endregion

        #region 横杆

        /// <summary>
        /// 横杆宽度(mm)
        /// </summary>
        [DisplayName("横杆宽度(mm)")]
        [Description("mm")]
        [Category("横杆")]
        public double HengGanWidth { get; set; } = 1000;


        /// <summary>
        /// 横杆半径(mm)
        /// </summary>
        [DisplayName("横杆半径(mm)")]
        [Description("mm")]
        [Category("横杆")]
        public double HengGanRadius { get; set; } = 25;

        /// <summary>
        /// 横杆壁厚(mm)
        /// </summary>
        [DisplayName("横杆壁厚(mm)")]
        [Description("mm")]
        [Category("横杆")]
        public double HengGanThickness { get; set; } = 2;

        #endregion

        #region 竖杆

        /// <summary>
        /// 竖杆高度(mm)
        /// </summary>
        [DisplayName("竖杆高度(mm)")]
        [Description("mm")]
        [Category("竖杆")]
        public double ShuGanHeight { get; set; } = 1000;

        /// <summary>
        /// 竖杆半径(mm)
        /// </summary>
        [DisplayName("竖杆半径(mm)")]
        [Description("mm")]
        [Category("竖杆")]
        public double ShuGanRadius { get; set; } = 20;

        /// <summary>
        /// 竖杆壁厚(mm)
        /// </summary>
        [DisplayName("竖杆壁厚(mm)")]
        [Description("mm")]
        [Category("竖杆")]
        public double ShuGanThickness { get; set; } = 2;

        /// <summary>
        /// 竖杆见光宽度(mm)
        /// </summary>
        [DisplayName("竖杆见光宽度(mm)")]
        [Description("mm")]
        [Category("竖杆")]
        public double ShuGanJianGuangWidth { get; set; } = 100;

        /// <summary>
        /// 竖杆数量(mm)
        /// </summary>
        [DisplayName("竖杆数量(mm)")]
        [Description("mm")]
        [Category("竖杆")]
        public double ShuGanCount { get; set; } = 5;

        #endregion

        #endregion
    }
}
