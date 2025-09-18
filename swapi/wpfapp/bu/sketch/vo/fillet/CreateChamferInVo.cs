using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.sketch.vo.fillet
{
    /// <summary>
    /// 绘制倒角
    /// </summary>
    [DisplayName("绘制倒角")]
    public class CreateChamferInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        [Category("倒角")]
        [Description("可选值:见swSketchChamferType_e，\r\n0 = swSketchChamfer_DistanceAngle，\r\n1 = swSketchChamfer_DistanceDistance，\r\n2 = swSketchChamfer_DistanceEqual ")]
        public int Type { get; set; } = 2;

        /// <summary>
        /// 距离
        /// </summary>
        [DisplayName("距离")]
        [Category("倒角")]
        [Description("Distance of the chamfer")]
        public double Distance { get; set; } = 2;

        /// <summary>
        /// 圆心Z
        /// </summary>
        [DisplayName("距离或角度")]
        [Category("倒角")]
        [Description("If Type = swSketchChamfer_DistanceDistance, then the second chamfer distance \r\nIf Type = swSketchChamfer_DistanceAngle, then the second chamfer angle \r\nIf Type = swSketchChamfer_DistanceEqual, then this argument is ignored because Distance is used for both edges")]
        public double AngleORdist { get; set; } = 0;

        #endregion
    }
}
