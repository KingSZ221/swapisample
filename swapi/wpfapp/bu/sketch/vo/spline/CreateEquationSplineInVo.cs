using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.spline
{
    [DisplayName("绘制方程式驱动曲线")]
    public class CreateEquationSplineInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// XExpression
        /// </summary>
        [DisplayName("XExpression")]
        [Category("Misc")]
        [Description("For a parametric curve, equation for x in terms of t; for an explicit curve, an empty string ")]
        public string XExpression { get; set; } = "";

        /// <summary>
        /// YExpression
        /// </summary>
        [DisplayName("YExpression")]
        [Category("Misc")]
        [Description("For a parametric curve, equation for y in terms of t; for an explicit curve, equation for y in terms of x ")]
        public string YExpression { get; set; } = "x^2";

        /// <summary>
        /// ZExpression
        /// </summary>
        [DisplayName("ZExpression")]
        [Category("Misc")]
        [Description("Equation for z in terms of t ")]
        public string ZExpression { get; set; } = "";

        /// <summary>
        /// RangeStart 
        /// </summary>
        [DisplayName("RangeStart")]
        [Category("Misc")]
        [Description("Start value for x, if explicit; start value for t, if parametric ")]
        public string RangeStart { get; set; } = "-5";

        /// <summary>
        /// RangeEnd  
        /// </summary>
        [DisplayName("RangeEnd")]
        [Category("Misc")]
        [Description("End value for x, if explicit; start value for t, if parametric ")]
        public string RangeEnd { get; set; } = "5";

        /// <summary>
        /// IsAngleRange 
        /// </summary>
        [DisplayName("IsAngleRange")]
        [Category("Misc")]
        [Description("Start value for x, if explicit; start value for t, if parametric ")]
        public bool IsAngleRange { get; set; } = false;

        /// <summary>
        /// RotationAngle 
        /// </summary>
        [DisplayName("RotationAngle")]
        [Category("Misc")]
        [Description("Start value for x, if explicit; start value for t, if parametric ")]
        public double RotationAngle { get; set; } = 0;

        /// <summary>
        /// XOffset
        /// </summary>
        [DisplayName("XOffset")]
        [Category("Misc")]
        [Description("Translation in the x direction of the curve ")]
        public double XOffset { get; set; } = 0;

        /// <summary>
        /// YOffset 
        /// </summary>
        [DisplayName("YOffset")]
        [Category("Misc")]
        [Description("Translation in the y direction of the curve ")]
        public double YOffset { get; set; } = 0;

        /// <summary>
        /// LockStart 
        /// </summary>
        [DisplayName("LockStart")]
        [Category("Misc")]
        [Description("True to lock the start point (RangeStart) of the curve, false to not")]
        public bool LockStart { get; set; } = false;

        /// <summary>
        /// LockEnd 
        /// </summary>
        [DisplayName("LockEnd")]
        [Category("Misc")]
        [Description("True to lock the end point (RangeEnd) of the curve, false to not")]
        public bool LockEnd { get; set; } = false;

        #endregion
    }
}
