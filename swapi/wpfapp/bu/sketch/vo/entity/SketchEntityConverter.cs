using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.sketch.vo.entity
{
    public class SketchEntityConverter
    {
        #region 遍历草图实体

        public static SketchEntityInfo GetSketchEntiyInfo(ISketch sketch)
        {
            SketchEntityInfo oSketchEntiyInfo = new SketchEntityInfo();
            oSketchEntiyInfo.Segments = new List<SketchSegmentInfo>();
            oSketchEntiyInfo.Points = new List<SketchPointInfo>();
            // 遍历草图段
            object[] sketchSegments = (object[])sketch.GetSketchSegments();
            if (sketchSegments != null && sketchSegments.Length > 0)
            {
                foreach (object segObj in sketchSegments)
                {
                    SketchSegmentInfo oSketchSegmentInfo = ToSegment(segObj as ISketchSegment);
                    if (oSketchSegmentInfo != null)
                    {
                        oSketchEntiyInfo.Segments.Add(oSketchSegmentInfo);
                    }
                }
            }

            // 遍历草图点
            object[] sketchPoints = (object[])sketch.GetSketchPoints();
            if (sketchPoints != null && sketchPoints.Length > 0)
            {
                foreach (object pointObj in sketchPoints)
                {
                    SketchPointInfo oSketchPointInfo = ToPoint(pointObj as ISketchPoint);
                    if (oSketchPointInfo != null)
                    {
                        oSketchEntiyInfo.Points.Add(oSketchPointInfo);
                    }
                }
            }

            return oSketchEntiyInfo;
        }

        #endregion

        #region 获取段信息

        /// <summary>
        /// 获取段信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static SketchSegmentInfo ToSegment(ISketchSegment skSegment)
        {
            if (skSegment == null)
            {
                return null;
            }

            SketchSegmentInfo skEntity = null;
            swSketchSegments_e type = (swSketchSegments_e)skSegment.GetType();
            switch (type)
            {
                case swSketchSegments_e.swSketchLINE:
                    skEntity = ToLine(skSegment);
                    break;
                case swSketchSegments_e.swSketchARC:
                    skEntity = ToArc(skSegment);
                    break;
                case swSketchSegments_e.swSketchELLIPSE:
                    skEntity = ToEllipse(skSegment);
                    break;
                case swSketchSegments_e.swSketchSPLINE:
                    skEntity = ToSpline(skSegment);
                    break;
                case swSketchSegments_e.swSketchTEXT:
                    skEntity = ToText(skSegment);
                    break;
                case swSketchSegments_e.swSketchPARABOLA:
                    skEntity = ToParabola(skSegment);
                    break;
                default:
                    Console.WriteLine($"找到其他图元: {type}");
                    skEntity = new SketchSegmentInfo();
                    GetEntityInfoOfSegment(skSegment, skEntity);
                    break;
            }

            return skEntity;
        }

        /// <summary>
        /// 获取草图直线信息
        /// </summary>
        /// <param name="skSegment"></param>
        /// <returns></returns>
        public static SketchLineInfo ToLine(ISketchSegment skSegment)
        {
            if (skSegment == null)
            {
                return null;
            }

            SketchLineInfo skEntity = new SketchLineInfo();
            GetEntityInfoOfSegment(skSegment, skEntity);

            ISketchLine skLine = skSegment as ISketchLine;
            ISketchPoint skStartPt = skLine.GetStartPoint2() as ISketchPoint;
            ISketchPoint skEndPt = skLine.GetEndPoint2() as ISketchPoint;
            skEntity.StartPoint = ToMathPoint(skStartPt);
            skEntity.EndPoint = ToMathPoint(skEndPt);

            return skEntity;
        }

        public static SketchMathPointInfo ToMathPoint(ISketchPoint skPt)
        {
            if (skPt == null)
            {
                return null;
            }

            SketchMathPointInfo swMathPoint = new SketchMathPointInfo() { X = skPt.X * 1000, Y = skPt.Y * 1000, Z = skPt.Z * 1000 };
            return swMathPoint;
        }

        /// <summary>
        /// 获取草图弧线信息
        /// </summary>
        /// <param name="skSegment"></param>
        /// <returns></returns>
        public static SketchArcInfo ToArc(ISketchSegment skSegment)
        {
            if (skSegment == null)
            {
                return null;
            }

            SketchArcInfo skEntity = new SketchArcInfo();
            GetEntityInfoOfSegment(skSegment, skEntity);

            return skEntity;
        }

        /// <summary>
        /// 获取草图椭圆信息
        /// </summary>
        /// <param name="skSegment"></param>
        /// <returns></returns>
        public static SketchEllipseInfo ToEllipse(ISketchSegment skSegment)
        {
            if (skSegment == null)
            {
                return null;
            }

            SketchEllipseInfo skEntity = new SketchEllipseInfo();
            GetEntityInfoOfSegment(skSegment, skEntity);

            return skEntity;
        }

        /// <summary>
        /// 草图样条曲线
        /// </summary>
        /// <param name="skSegment"></param>
        /// <returns></returns>
        public static SketchSplineInfo ToSpline(ISketchSegment skSegment)
        {
            if (skSegment == null)
            {
                return null;
            }

            SketchSplineInfo skEntity = new SketchSplineInfo();
            GetEntityInfoOfSegment(skSegment, skEntity);

            return skEntity;
        }

        /// <summary>
        /// 草图文本
        /// </summary>
        /// <param name="skSegment"></param>
        /// <returns></returns>
        public static SketchTextInfo ToText(ISketchSegment skSegment)
        {
            if (skSegment == null)
            {
                return null;
            }

            SketchTextInfo skEntity = new SketchTextInfo();
            GetEntityInfoOfSegment(skSegment, skEntity);

            return skEntity;
        }

        /// <summary>
        /// 草图抛物线
        /// </summary>
        /// <param name="skSegment"></param>
        /// <returns></returns>
        public static SketchParabolaInfo ToParabola(ISketchSegment skSegment)
        {
            if (skSegment == null)
            {
                return null;
            }

            SketchParabolaInfo skEntity = new SketchParabolaInfo();
            GetEntityInfoOfSegment(skSegment, skEntity);

            return skEntity;
        }

        /// <summary>
        /// 获取草图段实体信息
        /// </summary>
        /// <param name="skSegment"></param>
        /// <param name="oEntity"></param>
        public static void GetEntityInfoOfSegment(ISketchSegment skSegment, SketchEntityItemInfo oEntity)
        {
            int[] ids = skSegment.GetID() as int[];
            oEntity.ID = $"[{ids[0]},{ids[1]}]";
            //oEntity.ID = skSegment.GetID().ToString();
            oEntity.Name = skSegment.GetName();
            oEntity.TypeId = skSegment.GetType();
            oEntity.TypeName = GetEntityTypeName(skSegment.GetType());
            oEntity.Length = skSegment.GetLength();

            EntitySelectId selectId = new EntitySelectId();
            selectId.Name = skSegment.GetName();
            selectId.Type = "SKETCHSEGMENT";
            selectId.X = 0;
            selectId.Y = 0;
            selectId.Z = 0;
            oEntity.SelectId = selectId;
        }

        public static string GetEntityTypeName(int typeId)
        {
            string strTypeName = "未知";
            swSketchSegments_e type = (swSketchSegments_e)typeId;
            switch (type)
            {
                case swSketchSegments_e.swSketchLINE:
                    strTypeName = "LINE";
                    break;
                case swSketchSegments_e.swSketchARC:
                    strTypeName = "ARC";
                    break;
                case swSketchSegments_e.swSketchELLIPSE:
                    strTypeName = "ELLIPSE";
                    break;
                case swSketchSegments_e.swSketchSPLINE:
                    strTypeName = "SPLINE";
                    break;
                case swSketchSegments_e.swSketchTEXT:
                    strTypeName = "TEXT";
                    break;
                case swSketchSegments_e.swSketchPARABOLA:
                    strTypeName = "PARABOLA";
                    break;
                default:
                    strTypeName = "未知";
                    break;
            }

            return strTypeName;
        }

        #endregion

        #region 获取点信息

        /// <summary>
        /// 获取点信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static SketchPointInfo ToPoint(ISketchPoint skPoint)
        {
            if (skPoint == null)
            {
                return null;
            }

            SketchPointInfo skEntity = new SketchPointInfo();
            GetEntityInfoOfPoint(skPoint, skEntity);

            skEntity.Position = ToMathPoint(skPoint);

            EntitySelectId selectId = new EntitySelectId();
            selectId.Name = "";
            selectId.Type = "SKETCHPOINT";
            selectId.X = skEntity.Position.X;
            selectId.Y = skEntity.Position.Y;
            selectId.Z = skEntity.Position.Z;
            skEntity.SelectId = selectId;

            return skEntity;
        }

        /// <summary>
        /// 获取草图点视图信息
        /// </summary>
        /// <param name="skSegment"></param>
        /// <param name="oEntity"></param>
        public static void GetEntityInfoOfPoint(ISketchPoint skPoint, SketchPointInfo oPoint)
        {
            int[] ids = skPoint.GetID() as int[];
            oPoint.ID = $"[{ids[0]},{ids[1]}]";
            //oPoint.ID = ids;
            //oPoint.Name = skPoint.GetName();
            //oPoint.TypeId = skPoint.GetType();
        }

        #endregion
    }
}
