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
using wpfapp.bu.sketch.vo.arc;
using wpfapp.bu.sketch.vo.circle;
using wpfapp.bu.sketch.vo.rect;
using wpfapp.bu.sketch.vo.sketch;
using wpfapp.bu.sketch.vo.slot;
using wpfapp.bu.vo;

namespace wpfapp.nbi
{
    [RoutePrefix("api/sw")]
    public class SwApiController : ApiController
    {
        #region 应用

        [HttpGet]
        [Route("ConnectSw")]  // 对应 api/sw/ConnectSw
        public IHttpActionResult ConnectSw()
        {
            return Ok(SwBuAppService.getInstance().connectSw());
        }

        #endregion

        #region 文档

        [HttpPost]
        [Route("NewDoc")]  // 对应 对应 api/sw/NewDoc
        public IHttpActionResult NewDoc([FromBody] NewDocInVo oInVo)
        {
            if(oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFileService.getInstance().newDoc(oInVo.getSwDefaultTemplateType()));
        }

        [HttpPost]
        [Route("OpenDoc")]
        public IHttpActionResult OpenDoc([FromBody] OpenDocInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFileService.getInstance().openDoc(oInVo.getTestDocName(), oInVo.getSwDocType()));
        }

        [HttpPost]
        [Route("CloseDoc")]
        public IHttpActionResult CloseDoc([FromBody] CloseDocInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFileService.getInstance().closeDoc(oInVo.DocTitle));
        }

        [HttpPost]
        [Route("SaveDoc")]
        public IHttpActionResult SaveDoc([FromBody] SaveDocInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFileService.getInstance().saveDoc(oInVo));
        }

        [HttpPost]
        [Route("ExportDoc")]
        public IHttpActionResult ExportDoc([FromBody] ExportDocInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuFileService.getInstance().exportDoc(oInVo));
        }

        #endregion

        #region 绘制草图

        [HttpPost]
        [Route("EditSketch")]
        public IHttpActionResult EditSketch([FromBody] EditSketchInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.EditSketch, oInVo));
        }

        [HttpPost]
        [Route("ExitSketch")]
        public IHttpActionResult ExitSketch([FromBody] ExitSketchInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.ExitSketch, oInVo));
        }

        #endregion

        #region 绘制直线

        [HttpPost]
        [Route("CreateLine")]
        public IHttpActionResult CreateCirclePipe([FromBody] CreateLineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateLine, oInVo));
        }

        [HttpPost]
        [Route("CreateCenterLine")]
        public IHttpActionResult CreateCirclePipe([FromBody] CreateCenterLineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateCenterLine, oInVo));
        }

        #endregion

        #region 绘制矩形

        [HttpPost]
        [Route("CreateCornerRectangle")]
        public IHttpActionResult CreateCornerRectangle([FromBody] CreateCornerRectangleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateCornerRectangle, oInVo));
        }

        [HttpPost]
        [Route("CreateCenterRectangle")]
        public IHttpActionResult CreateCenterRectangle([FromBody] CreateCenterRectangleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateCenterRectangle, oInVo));
        }

        [HttpPost]
        [Route("Create3PointCornerRectangle")]
        public IHttpActionResult Create3PointCornerRectangle([FromBody] Create3PointCornerRectangleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.Create3PointCornerRectangle, oInVo));
        }

        [HttpPost]
        [Route("Create3PointCenterRectangle")]
        public IHttpActionResult Create3PointCenterRectangle([FromBody] Create3PointCenterRectangleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.Create3PointCenterRectangle, oInVo));
        }

        [HttpPost]
        [Route("CreateParallelogram")]
        public IHttpActionResult CreateParallelogram([FromBody] CreateParallelogramInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateParallelogram, oInVo));
        }

        #endregion

        #region 绘制槽口

        [HttpPost]
        [Route("CreateSketchSlotLine")]
        public IHttpActionResult CreateSketchSlotLine([FromBody] CreateSketchSlotLineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateSketchSlot_line, oInVo));
        }

        [HttpPost]
        [Route("CreateSketchSlotCenterLine")]
        public IHttpActionResult CreateSketchSlotCenterLine([FromBody] CreateSketchSlotCenterLineInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateSketchSlot_center_line, oInVo));
        }

        [HttpPost]
        [Route("CreateSketchSlot3PointArc")]
        public IHttpActionResult CreateSketchSlot3PointArc([FromBody] CreateSketchSlot3PointArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateSketchSlot_3pointarc, oInVo));
        }

        [HttpPost]
        [Route("CreateSketchSlotArc")]
        public IHttpActionResult CreateSketchSlotArc([FromBody] CreateSketchSlotArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateSketchSlot_arc, oInVo));
        }

        #endregion

        #region 绘制圆

        [HttpPost]
        [Route("CreateCircle")]
        public IHttpActionResult CreateCircle([FromBody] CreateCircleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateCircle, oInVo));
        }

        [HttpPost]
        [Route("PerimeterCircle")]
        public IHttpActionResult PerimeterCircle([FromBody] PerimeterCircleInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.PerimeterCircle, oInVo));
        }

        #endregion

        #region 绘制圆弧

        [HttpPost]
        [Route("CreateArc")]
        public IHttpActionResult CreateArc([FromBody] CreateArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateArc, oInVo));
        }

        [HttpPost]
        [Route("CreateTangentArc")]
        public IHttpActionResult CreateTangentArc([FromBody] CreateTangentArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateTangentArc, oInVo));
        }

        [HttpPost]
        [Route("Create3PointArc")]
        public IHttpActionResult Create3PointArc([FromBody] Create3PointArcInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.Create3PointArc, oInVo));
        }
        #endregion

        #region 绘制圆管

        [HttpPost]
        [Route("CreateCirclePipe")]  // 对应 对应 api/sw/createCirclePipe
        public IHttpActionResult CreateCirclePipe([FromBody] CreateCirclePipeInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuSketchService.getInstance().executeSketchAction(EnumSwSketchActionType.CreateCirclePipe, oInVo));
        }

        #endregion
    }
}
