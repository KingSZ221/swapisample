using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.sketch.vo.draw.spline
{
    [DisplayName("绘制B样条曲线")]
    public class CreateSplineInVo : SketchDrawInVoBase
    {
        #region Fields

        /// <summary>
        /// 点集合
        /// </summary>
        [DisplayName("点集合")]
        [Category("点集合")]
        [Description("通过若干点绘制B样条曲线")]
        public List<SplinePoint> Points { get; set; } = new List<SplinePoint>();

        #endregion

        #region Default

        public static CreateSplineInVo Default()
        {
            CreateSplineInVo oCreateSplineInVo = new CreateSplineInVo();

            oCreateSplineInVo.Points.Add(new SplinePoint { X = -45, Y = 12 });
            oCreateSplineInVo.Points.Add(new SplinePoint { X = -15, Y = 22 });
            oCreateSplineInVo.Points.Add(new SplinePoint { X = -9, Y = -12 });
            oCreateSplineInVo.Points.Add(new SplinePoint { X = -38, Y = -10 });
            return oCreateSplineInVo;
        }

        #endregion
    }
}
