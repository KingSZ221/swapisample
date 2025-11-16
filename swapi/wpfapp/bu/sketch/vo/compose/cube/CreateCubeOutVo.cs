using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.draw.rect;
using wpfapp.bu.sketch.vo.entity;
using wpfapp.bu.feature.vo.feature.extrusion;
using wpfapp.bu.sketch.vo.sketch;

namespace wpfapp.bu.sketch.vo.compose.cube
{
    [DisplayName("创建立方体")]
    public class CreateCubeOutVo
    {
        #region Fields

        #region Step1.俯视草图

        /// <summary>
        /// 俯视草图
        /// </summary>
        [DisplayName("1.1.进入草图编辑命令-输入")]
        [Description("俯视草图")]
        [Category("Step1.俯视草图")]
        public EditSketchInVo SketchEditInVo { get; set; }

        /// <summary>
        /// 俯视轮廓
        /// </summary>
        [DisplayName("1.2.绘制矩形命令-输入")]
        [Description("俯视轮廓绘制参数")]
        [Category("Step1.俯视草图")]
        public CreateCenterRectangleInVo ContourInVo { get; set; }

        /// <summary>
        /// 俯视轮廓
        /// </summary>
        [DisplayName("1.2.绘制矩形命令-输出")]
        [Description("俯视轮廓绘制结果")]
        [Category("Step1.俯视草图")]
        public SketchArcInfo ContourOutVo { get; set; }

        /// <summary>
        /// 俯视轮廓
        /// </summary>
        [DisplayName("1.3.退出草图编辑命令")]
        [Description("俯视草图")]
        [Category("Step1.俯视草图")]
        public ExitSketchInVo SketchExitInVo { get; set; }

        #endregion

        #region Step2.立方体

        /// <summary>
        /// 立方体
        /// </summary>
        [DisplayName("2.1.拉伸薄壁-输入")]
        [Description("立方体绘制参数")]
        [Category("Step2.立方体")]
        public FeatureExtrusionThinInVo FeatureCube { get; set; }

        #endregion

        #endregion
    }
}
