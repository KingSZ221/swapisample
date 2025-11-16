using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using wpfapp.bu;
using wpfapp.bu.app;
using wpfapp.bu.file;
using wpfapp.bu.sketch;
using wpfapp.bu.sketch.action;
using wpfapp.bu.sketch.vo;
using wpfapp.bu.sketch.vo.draw.arc;
using wpfapp.bu.sketch.vo.draw.circle;
using wpfapp.bu.sketch.vo.draw.ellipse;
using wpfapp.bu.sketch.vo.entity;
using wpfapp.bu.sketch.vo.edit.fillet;
using wpfapp.bu.sketch.vo.draw.point;
using wpfapp.bu.sketch.vo.draw.polygon;
using wpfapp.bu.sketch.vo.draw.rect;
using wpfapp.bu.sketch.vo.sketch;
using wpfapp.bu.sketch.vo.draw.slot;
using wpfapp.bu.sketch.vo.draw.spline;
using wpfapp.bu.sketch.vo.draw.text;
using wpfapp.bu.file.vo;
using wpfapp.bu.sketch.vo.draw.line;
using wpfapp.bu.vo.compose.pipe;
using wpfapp.bu.sketch.vo.compose.ladder;
using Newtonsoft.Json;
using wpfapp.bu.feature.vo.feature.extrusion;
using wpfapp.bu.feature;
using wpfapp.bu.feature.cmd;
using wpfapp.bu.file.cmd;
using wpfapp.basic.io;

namespace wpfapp.nbi
{
    [RoutePrefix("swapi")]
    public class SwApiController : ApiController
    {
        #region 应用

        [HttpPost]
        [Route("app/ConnectSw")]
        public IHttpActionResult ConnectSw()
        {
            return Ok(SwBuAppService.getInstance().connectSw());
        }

        #endregion

        #region 文档

        [HttpPost]
        [Route("file/NewDoc")]  // 对应 对应 api/sw/NewDoc
        public IHttpActionResult NewDoc([FromBody] NewDocInVo oInVo)
        {
            if(oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFileService.getInstance().executeCmdWithInVo(EnumSwDocCmdType.NewDoc, oInVo));
        }

        [HttpPost]
        [Route("file/OpenDoc")]
        public IHttpActionResult OpenDoc([FromBody] OpenDocInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            if(string.IsNullOrEmpty(oInVo.DocFileName))
            {
                oInVo.DocFileName = OpenDocInVo.getTestDocName(oInVo.DocType);
            }
            return Ok(SwBuFileService.getInstance().executeCmdWithInVo(EnumSwDocCmdType.OpenDoc, oInVo));
        }

        [HttpPost]
        [Route("file/CloseDoc")]
        public IHttpActionResult CloseDoc([FromBody] CloseDocInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFileService.getInstance().executeCmdWithInVo(EnumSwDocCmdType.CloseDoc, oInVo));
        }

        [HttpPost]
        [Route("file/SaveDoc")]
        public IHttpActionResult SaveDoc([FromBody] SaveDocInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFileService.getInstance().executeCmdWithInVo(EnumSwDocCmdType.SaveDoc, oInVo));
        }

        [HttpPost]
        [Route("file/ExportDoc")]
        public IHttpActionResult ExportDoc([FromBody] ExportDocInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFileService.getInstance().executeCmdWithInVo(EnumSwDocCmdType.ExportDoc, oInVo));
        }

        #endregion

        #region 绘制草图

        /// <summary>
        /// 进入草图绘制
        /// </summary>
        [HttpPost]
        [Route("sketch/EditSketch")]
        public IHttpActionResult EditSketch([FromBody] EditSketchInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.EditSketch, oInVo));
        }

        /// <summary>
        /// 退出草图绘制
        /// </summary>
        [HttpPost]
        [Route("sketch/ExitSketch")]
        public IHttpActionResult ExitSketch([FromBody] ExitSketchInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.ExitSketch, oInVo));
        }

        /// <summary>
        /// 获取草图实体信息
        /// </summary>
        [HttpPost]
        [Route("sketch/GetSketchEntityInfo")]
        public IHttpActionResult GetSketchEntityInfo([FromBody] GetSketchEntityInfoInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.GetSketchEntityInfo, oInVo));
        }

        #endregion

        #region 绘制直线

        [HttpPost]
        [Route("sketch/CreateLine")]
        public IHttpActionResult CreateCirclePipe([FromBody] CreateLineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateLine, oInVo));
        }

        [HttpPost]
        [Route("sketch/CreateCenterLine")]
        public IHttpActionResult CreateCirclePipe([FromBody] CreateCenterLineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCenterLine, oInVo));
        }

        #endregion

        #region 绘制矩形

        [HttpPost]
        [Route("sketch/CreateCornerRectangle")]
        public IHttpActionResult CreateCornerRectangle([FromBody] CreateCornerRectangleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCornerRectangle, oInVo));
        }

        [HttpPost]
        [Route("sketch/CreateCenterRectangle")]
        public IHttpActionResult CreateCenterRectangle([FromBody] CreateCenterRectangleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCenterRectangle, oInVo));
        }

        [HttpPost]
        [Route("sketch/Create3PointCornerRectangle")]
        public IHttpActionResult Create3PointCornerRectangle([FromBody] Create3PointCornerRectangleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.Create3PointCornerRectangle, oInVo));
        }

        [HttpPost]
        [Route("sketch/Create3PointCenterRectangle")]
        public IHttpActionResult Create3PointCenterRectangle([FromBody] Create3PointCenterRectangleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.Create3PointCenterRectangle, oInVo));
        }

        [HttpPost]
        [Route("sketch/CreateParallelogram")]
        public IHttpActionResult CreateParallelogram([FromBody] CreateParallelogramInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateParallelogram, oInVo));
        }

        #endregion

        #region 绘制槽口

        [HttpPost]
        [Route("sketch/CreateSketchSlotLine")]
        public IHttpActionResult CreateSketchSlotLine([FromBody] CreateSketchSlotLineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateSketchSlot_line, oInVo));
        }

        [HttpPost]
        [Route("sketch/CreateSketchSlotCenterLine")]
        public IHttpActionResult CreateSketchSlotCenterLine([FromBody] CreateSketchSlotCenterLineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateSketchSlot_center_line, oInVo));
        }

        [HttpPost]
        [Route("sketch/CreateSketchSlot3PointArc")]
        public IHttpActionResult CreateSketchSlot3PointArc([FromBody] CreateSketchSlot3PointArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateSketchSlot_3pointarc, oInVo));
        }

        [HttpPost]
        [Route("sketch/CreateSketchSlotArc")]
        public IHttpActionResult CreateSketchSlotArc([FromBody] CreateSketchSlotArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateSketchSlot_arc, oInVo));
        }

        #endregion

        #region 绘制圆

        [HttpPost]
        [Route("sketch/CreateCircle")]
        public IHttpActionResult CreateCircle([FromBody] CreateCircleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCircle, oInVo));
        }

        [HttpPost]
        [Route("sketch/PerimeterCircle")]
        public IHttpActionResult PerimeterCircle([FromBody] PerimeterCircleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.PerimeterCircle, oInVo));
        }

        #endregion

        #region 绘制圆弧

        [HttpPost]
        [Route("sketch/CreateArc")]
        public IHttpActionResult CreateArc([FromBody] CreateArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateArc, oInVo));
        }

        [HttpPost]
        [Route("sketch/CreateTangentArc")]
        public IHttpActionResult CreateTangentArc([FromBody] CreateTangentArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateTangentArc, oInVo));
        }

        [HttpPost]
        [Route("sketch/Create3PointArc")]
        public IHttpActionResult Create3PointArc([FromBody] Create3PointArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.Create3PointArc, oInVo));
        }
        #endregion

        #region 绘制多边形

        [HttpPost]
        [Route("sketch/CreatePolygon")]
        public IHttpActionResult CreatePolygon([FromBody] CreatePolygonInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreatePolygon, oInVo));
        }

        #endregion

        #region 绘制样条曲线

        /// <summary>
        /// 绘制B样条曲线
        /// </summary>
        [HttpPost]
        [Route("sketch/CreateSpline")]
        public IHttpActionResult CreateSpline([FromBody] CreateSplineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateSpline, oInVo));
        }

        /// <summary>
        /// 绘制方程式驱动曲线
        /// </summary>
        [HttpPost]
        [Route("sketch/CreateEquationSpline")]
        public IHttpActionResult CreateEquationSpline([FromBody] CreateEquationSplineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateEquationSpline, oInVo));
        }

        #endregion

        #region 绘制椭圆

        /// <summary>
        /// 绘制椭圆
        /// </summary>
        [HttpPost]
        [Route("sketch/CreateEllipse")]
        public IHttpActionResult CreateEllipse([FromBody] CreateEllipseInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateEllipse, oInVo));
        }

        /// <summary>
        /// 绘制部分椭圆
        /// </summary>
        [HttpPost]
        [Route("sketch/CreateEllipticalArc")]
        public IHttpActionResult CreateEllipticalArc([FromBody] CreateEllipticalArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateEllipticalArc, oInVo));
        }

        /// <summary>
        /// 绘制抛物线
        /// </summary>
        [HttpPost]
        [Route("sketch/CreateParabola")]
        public IHttpActionResult CreateParabola([FromBody] CreateParabolaInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateParabola, oInVo));
        }

        /// <summary>
        /// 绘制圆锥
        /// </summary>
        [HttpPost]
        [Route("sketch/CreateConic")]
        public IHttpActionResult CreateConic([FromBody] CreateConicInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateConic, oInVo));
        }
        #endregion

        #region 绘制文本

        [HttpPost]
        [Route("sketch/InsertSketchText")]
        public IHttpActionResult InsertSketchText([FromBody] InsertSketchTextInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.InsertSketchText, oInVo));
        }

        #endregion

        #region 绘制点

        [HttpPost]
        [Route("sketch/CreatePoint")]
        public IHttpActionResult CreatePoint([FromBody] CreatePointInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreatePoint, oInVo));
        }

        #endregion

        #region 绘制圆角

        /// <summary>
        /// 绘制圆角
        /// </summary>
        [HttpPost]
        [Route("sketch/CreateFillet")]
        public IHttpActionResult CreateFillet([FromBody] CreateFilletInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateFillet, oInVo));
        }

        /// <summary>
        /// 绘制倒角
        /// </summary>
        [HttpPost]
        [Route("sketch/CreateChamfer")]
        public IHttpActionResult CreateChamfer([FromBody] CreateChamferInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateChamfer, oInVo));
        }

        #endregion

        #region 拉伸基体

        /// <summary>
        /// 拉伸基体
        /// </summary>
        [HttpPost]
        [Route("feature/FeatureExtrusion")]
        public IHttpActionResult FeatureExtrusion([FromBody] FeatureExtrusionThinInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusion, oInVo));
        }

        /// <summary>
        /// 拉伸薄壁
        /// </summary>
        [HttpPost]
        [Route("feature/FeatureExtrusionThin")]
        public IHttpActionResult FeatureExtrusionThin([FromBody] CreateChamferInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusionThin, oInVo));
        }

        #endregion

        #region 绘制圆管

        [HttpPost]
        [Route("part/CreateCirclePipe")]  // 对应 对应 api/sw/createCirclePipe
        public IHttpActionResult CreateCirclePipe([FromBody] CreateCirclePipeInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCirclePipe, oInVo));
        }

        #endregion

        #region 绘制扶梯

        [HttpPost]
        [Route("part/CreateLadder")]  // 对应 对应 api/sw/CreateLadder
        public IHttpActionResult CreateLadder([FromBody] CreateLadderInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            CreateLadderOutVo oOutVo = SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateLadder, oInVo).resultObj as CreateLadderOutVo;
            string strJson = JsonConvert.SerializeObject(oOutVo);
            return Ok(strJson);
            //return Ok(SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchActionType.CreateLadder, oInVo));
        }

        #endregion
    }
}
