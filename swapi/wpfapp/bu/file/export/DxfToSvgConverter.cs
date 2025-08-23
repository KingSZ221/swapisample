using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using netDxf.Entities;
using Svg;
using Svg.Pathing;
using System.Drawing;
using System.IO;
using wpfapp.bu.vo;

namespace wpfapp.bu.utils
{

    public class DxfToSvgConverter
    {
        /// <summary>
        /// 将 DXF 文件转换为 SVG 文件
        /// </summary>
        /// <param name="dxfPath">输入的 DXF 文件路径</param>
        /// <param name="svgPath">输出的 SVG 文件路径</param>
        public static RespVo Convert(string dxfPath, string svgPath)
        {
            RespVo oRespVo = RespVo.genOk();
            try
            {
                // 1. 加载 DXF 文件
                DxfDocument dxf = DxfDocument.Load(dxfPath);
                if (dxf == null)
                {
                    oRespVo = RespVo.genError($"无法加载 DXF 文件 {dxfPath}");
                    return oRespVo;
                }

                // 2. 计算画布大小（自动适应内容）
                var bounds = GetDxfBounds(dxf);
                float padding = 10f; // 边距
                float svgWidth = (float)(bounds.MaxX - bounds.MinX) + 2 * padding;
                float svgHeight = (float)(bounds.MaxY - bounds.MinY) + 2 * padding;

                // 3. 创建 SVG 画布
                SvgDocument svgDoc = new SvgDocument
                {
                    Width = svgWidth,
                    Height = svgHeight,
                    ViewBox = new SvgViewBox(0, 0, svgWidth, svgHeight)
                };

                // 4. 转换 DXF 实体到 SVG
                foreach (EntityObject entity in dxf.Entities.All)
                {
                    ConvertEntityToSvg(entity, svgDoc, bounds.MinX, bounds.MinY, padding);
                }

                // 5. 保存 SVG 文件
                svgDoc.Write(svgPath);

                oRespVo = RespVo.genOk($"Dxf转换Svg成功: {svgPath}");
                return oRespVo;
            }
            catch (Exception ex)
            {
                oRespVo = RespVo.genError($"Dxf转换Svg失败: {ex.Message}, {svgPath}");
                return oRespVo;
            }
        }

        /// <summary>
        /// 计算 DXF 内容的边界（用于确定画布大小）
        /// </summary>
        private static (double MinX, double MinY, double MaxX, double MaxY) GetDxfBounds(DxfDocument dxf)
        {
            double minX = double.MaxValue, minY = double.MaxValue;
            double maxX = double.MinValue, maxY = double.MinValue;

            foreach (EntityObject entity in dxf.Entities.All)
            {
                switch (entity)
                {
                    case Line line:
                        UpdateBounds(line.StartPoint.X, line.StartPoint.Y, ref minX, ref minY, ref maxX, ref maxY);
                        UpdateBounds(line.EndPoint.X, line.EndPoint.Y, ref minX, ref minY, ref maxX, ref maxY);
                        break;
                    case Circle circle:
                        UpdateBounds(circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius, ref minX, ref minY, ref maxX, ref maxY);
                        UpdateBounds(circle.Center.X + circle.Radius, circle.Center.Y + circle.Radius, ref minX, ref minY, ref maxX, ref maxY);
                        break;
                    case Polyline2D polyline: // 使用 Polyline2D 替代 LwPolyline
                        foreach (Polyline2DVertex vertex in polyline.Vertexes)
                        {
                            UpdateBounds(vertex.Position.X, vertex.Position.Y, ref minX, ref minY, ref maxX, ref maxY);
                        }
                        break;
                }
            }

            // 如果无实体，默认返回一个最小画布
            if (minX == double.MaxValue) return (0, 0, 100, 100);
            return (minX, minY, maxX, maxY);
        }

        /// <summary>
        /// 更新边界坐标
        /// </summary>
        private static void UpdateBounds(double x, double y, ref double minX, ref double minY, ref double maxX, ref double maxY)
        {
            minX = Math.Min(minX, x);
            minY = Math.Min(minY, y);
            maxX = Math.Max(maxX, x);
            maxY = Math.Max(maxY, y);
        }

        /// <summary>
        /// 将 DXF 实体转换为 SVG 元素
        /// </summary>
        private static void ConvertEntityToSvg(EntityObject entity, SvgDocument svgDoc, double offsetX, double offsetY, float padding)
        {
            Func<double, double, PointF> toSvgCoords = (x, y) =>
            {
                return new PointF((float)(x - offsetX + padding), (float)(y - offsetY + padding));
            };

            switch (entity)
            {
                case Line line:
                    var start = toSvgCoords(line.StartPoint.X, line.StartPoint.Y);
                    var end = toSvgCoords(line.EndPoint.X, line.EndPoint.Y);
                    svgDoc.Children.Add(new SvgLine
                    {
                        StartX = start.X,
                        StartY = start.Y,
                        EndX = end.X,
                        EndY = end.Y,
                        Stroke = new SvgColourServer(Color.Black),
                        StrokeWidth = 1
                    });
                    break;

                case Circle circle:
                    var center = toSvgCoords(circle.Center.X, circle.Center.Y);
                    svgDoc.Children.Add(new SvgCircle
                    {
                        CenterX = center.X,
                        CenterY = center.Y,
                        Radius = (float)circle.Radius,
                        Stroke = new SvgColourServer(Color.Black),
                        Fill = SvgPaintServer.None,
                        StrokeWidth = 1
                    });
                    break;

                case Polyline2D polyline:
                    var path = new SvgPath
                    {
                        Stroke = new SvgColourServer(Color.Black),
                        Fill = SvgPaintServer.None,
                        StrokeWidth = 1
                    };
                    var segments = new SvgPathSegmentList();
                    for (int i = 0; i < polyline.Vertexes.Count; i++)
                    {
                        var point = toSvgCoords(polyline.Vertexes[i].Position.X, polyline.Vertexes[i].Position.Y);
                        if (i == 0)
                            segments.Add(new SvgMoveToSegment(isRelative: false, point)); // 绝对坐标移动
                        else
                            segments.Add(new SvgLineSegment(isRelative: false, point)); // 绝对坐标画线
                    }
                    if (polyline.IsClosed)
                        segments.Add(new SvgClosePathSegment(isRelative: false)); // 绝对坐标闭合
                    path.PathData = segments;
                    svgDoc.Children.Add(path);
                    break;
            }
        }
    }
}
