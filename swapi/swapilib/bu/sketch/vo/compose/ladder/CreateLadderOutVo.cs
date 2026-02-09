using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.sketch.vo.draw.circle;
using swapilib.bu.sketch.vo.entity;
using swapilib.bu.feature.vo.feature.extrusion;
using swapilib.bu.sketch.vo.sketch;

namespace swapilib.bu.sketch.vo.compose.ladder
{

    [DisplayName("创建扶梯")]
    public class CreateLadderOutVo
    {
        #region Fields

        #region Step1.横杆草图

        /// <summary>
        /// 横杆草图
        /// </summary>
        [DisplayName("1.1.进入草图编辑命令-输入")]
        [Description("横杆草图")]
        [Category("Step1.横杆草图")]
        public EditSketchInVo SketchHengGanEditInVo { get; set; }

        /// <summary>
        /// 面管1轮廓
        /// </summary>
        [DisplayName("1.2.绘制圆形命令-输入")]
        [Description("面管1轮廓绘制参数")]
        [Category("Step1.横杆草图")]
        public CreateCircleInVo ContourMianGuan1InVo { get; set; }

        /// <summary>
        /// 面管1轮廓
        /// </summary>
        [DisplayName("1.2.绘制圆形命令-输出")]
        [Description("面管1轮廓绘制结果")]
        [Category("Step1.横杆草图")]
        public SketchArcInfo ContourMianGuan1OutVo { get; set; }

        /// <summary>
        /// 面管2轮廓
        /// </summary>
        [DisplayName("1.3.绘制圆形命令-输入")]
        [Description("面管2轮廓绘制参数")]
        [Category("Step1.横杆草图")]
        public CreateCircleInVo ContourMianGuan2InVo { get; set; }

        /// <summary>
        /// 面管2轮廓
        /// </summary>
        [DisplayName("1.3.绘制圆形命令-输出")]
        [Description("面管2轮廓绘制结果")]
        [Category("Step1.横杆草图")]
        public SketchArcInfo ContourMianGuan2OutVo { get; set; }

        /// <summary>
        /// 横杆1轮廓
        /// </summary>
        [DisplayName("1.4.绘制圆形命令-输入")]
        [Description("横杆1轮廓绘制参数")]
        [Category("Step1.横杆草图")]
        public CreateCircleInVo ContourHengGan1InVo { get; set; }

        /// <summary>
        /// 横杆1轮廓
        /// </summary>
        [DisplayName("1.4.绘制圆形命令-输出")]
        [Description("横杆1轮廓绘制结果")]
        [Category("Step1.横杆草图")]
        public SketchArcInfo ContourHengGan1OutVo { get; set; }

        /// <summary>
        /// 横杆2轮廓
        /// </summary>
        [DisplayName("1.5.绘制圆形命令-输入")]
        [Description("横杆2轮廓绘制参数")]
        [Category("Step1.横杆草图")]
        public CreateCircleInVo ContourHengGan2InVo { get; set; }

        /// <summary>
        /// 横杆2轮廓
        /// </summary>
        [DisplayName("1.5.绘制圆形命令-输出")]
        [Description("横杆2轮廓绘制结果")]
        [Category("Step1.横杆草图")]
        public SketchArcInfo ContourHengGan2OutVo { get; set; }

        /// <summary>
        /// 横杆草图
        /// </summary>
        [DisplayName("1.6.退出草图编辑命令")]
        [Description("横杆草图")]
        [Category("Step1.横杆草图")]
        public ExitSketchInVo SketchHengGanExitInVo { get; set; }

        #endregion

        #region Step2.竖杆草图

        /// <summary>
        /// 竖杆草图
        /// </summary>
        [DisplayName("2.1.进入草图编辑命令-输入")]
        [Description("竖杆草图")]
        [Category("Step2.竖杆草图")]
        public EditSketchInVo SketchShuGanEditInVo { get; set; }

        /// <summary>
        /// 立柱1轮廓
        /// </summary>
        [DisplayName("2.2.绘制圆形命令-输入")]
        [Description("立柱1轮廓绘制参数")]
        [Category("Step2.竖杆草图")]
        public CreateCircleInVo ContourLiZhu1InVo { get; set; }

        /// <summary>
        /// 立柱1轮廓
        /// </summary>
        [DisplayName("2.2.绘制圆形命令-输出")]
        [Description("立柱1轮廓绘制结果")]
        [Category("Step2.竖杆草图")]
        public SketchArcInfo ContourLiZhu1OutVo { get; set; }

        /// <summary>
        /// 立柱2轮廓
        /// </summary>
        [DisplayName("2.3.绘制圆形命令-输入")]
        [Description("立柱2轮廓绘制参数")]
        [Category("Step2.竖杆草图")]
        public CreateCircleInVo ContourLiZhu2InVo { get; set; }

        /// <summary>
        /// 立柱2轮廓
        /// </summary>
        [DisplayName("2.3.绘制圆形命令-输出")]
        [Description("立柱2轮廓绘制结果")]
        [Category("Step2.竖杆草图")]
        public SketchArcInfo ContourLiZhu2OutVo { get; set; }

        /// <summary>
        /// 竖杆轮廓
        /// </summary>
        [DisplayName("2.4.绘制圆形命令-输入")]
        [Description("竖杆轮廓绘制参数")]
        [Category("Step2.竖杆草图")]
        public List<CreateCircleInVo> ContourShuGanListInVo { get; set; }

        /// <summary>
        /// 竖杆轮廓
        /// </summary>
        [DisplayName("2.4.绘制圆形命令-输出")]
        [Description("竖杆轮廓绘制结果")]
        [Category("Step2.竖杆草图")]
        public List<SketchArcInfo> ContourShuGanListOutVo { get; set; }

        /// <summary>
        /// 竖杆草图
        /// </summary>
        [DisplayName("2.5.退出草图编辑命令")]
        [Description("竖杆草图")]
        [Category("Step2.竖杆草图")]
        public ExitSketchInVo SketchShuGanExitInVo { get; set; }

        #endregion

        #region Step3.面管

        /// <summary>
        /// 面管1
        /// </summary>
        [DisplayName("3.1.拉伸薄壁-输入")]
        [Description("面管1绘制参数")]
        [Category("Step3.面管")]
        public FeatureExtrusionThinInVo FeatureMianGuan1 { get; set; }

        /// <summary>
        /// 面管2
        /// </summary>
        [DisplayName("3.2.拉伸薄壁-输入")]
        [Description("面管2绘制参数")]
        [Category("Step3.面管")]
        public FeatureExtrusionThinInVo FeatureMianGuan2 { get; set; }

        #endregion

        #region Step4.立柱

        /// <summary>
        /// 立柱1
        /// </summary>
        [DisplayName("4.1.拉伸薄壁-输入")]
        [Description("立柱1绘制参数")]
        [Category("Step4.立柱")]
        public FeatureExtrusionThinInVo FeatureLiZhu1 { get; set; }

        /// <summary>
        /// 立柱2
        /// </summary>
        [DisplayName("4.2.拉伸薄壁-输入")]
        [Description("立柱2绘制参数")]
        [Category("Step4.立柱")]
        public FeatureExtrusionThinInVo FeatureLiZhu2 { get; set; }

        #endregion

        #region Step5.横杆

        /// <summary>
        /// 横杆1
        /// </summary>
        [DisplayName("5.1.拉伸薄壁-输入")]
        [Description("横杆1绘制参数")]
        [Category("Step5.横杆")]
        public FeatureExtrusionThinInVo FeatureHengGan1 { get; set; }

        /// <summary>
        /// 横杆2
        /// </summary>
        [DisplayName("5.2.拉伸薄壁-输入")]
        [Description("横杆2绘制参数")]
        [Category("Step5.横杆")]
        public FeatureExtrusionThinInVo FeatureHengGan2 { get; set; }

        #endregion

        #region Step6.竖杆

        /// <summary>
        /// 竖杆
        /// </summary>
        [DisplayName("6.1.拉伸薄壁-输入")]
        [Description("竖杆绘制参数")]
        [Category("Step6.竖杆")]
        public List<FeatureExtrusionThinInVo> FeatureShuGanList { get; set; }

        #endregion

        #endregion
    }
}
