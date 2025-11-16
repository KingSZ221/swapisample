using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.spline;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.draw.spline
{
    /// <summary>
    /// 绘制B样条曲线
    /// </summary>
    public class CreateSplineAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateSplineAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateSplineInVo oInVo = this.actionInVo<CreateSplineInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 2. 将控制点转换为 API 需要的对象数组
            List<SplinePoint> points = oInVo.Points;
            if(points.Count < 2)
            {
                return RespVoLogExt.genError("至少要定义2个点");
            }

            double[] pointsArray = new double[points.Count * 3];
            for (int i = 0; i < points.Count; i++)
            {
                pointsArray[i * 3] = points[i].X / 1000;
                pointsArray[i * 3 + 1] = points[i].Y / 1000;
                pointsArray[i * 3 + 2] = points[i].Z / 1000;
            }

            // 绘制图形
            var spline = skeMgr.CreateSpline3(pointsArray, null, null, true, out _) as ISketchSegment;
            if(spline == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("绘制B样条曲线成功");
        }
    }
}
