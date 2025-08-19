using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using wpfapp.bu;
using wpfapp.bu.vo;

namespace wpfapp.nbi
{
    [RoutePrefix("api/sw")]
    public class SwApiController : ApiController
    {
        [HttpGet]
        [Route("connectSw")]  // 对应 api/sw/connectSw
        public IHttpActionResult connectSw()
        {
            return Ok(SwBuAppService.getInstance().connectSw());
        }

        [HttpPost]
        [Route("newDoc")]  // 对应 对应 api/sw/newDoc
        public IHttpActionResult newDoc([FromBody] NewDocInVo oInVo)
        {
            if(oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuAppService.getInstance().newDoc(oInVo.getSwDefaultTemplateType()));
        }

        [HttpPost]
        [Route("openDoc")]  // 对应 对应 api/sw/openDoc
        public IHttpActionResult openDoc([FromBody] OpenDocInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuAppService.getInstance().openDoc(oInVo.getTestDocName(), oInVo.getSwDocType()));
        }

        [HttpPost]
        [Route("newCirclePipe")]  // 对应 对应 api/sw/newCirclePipe
        public IHttpActionResult newCirclePipe([FromBody] NewCirclePipeInVo oInVo)
        {
            if (oInVo == null)
            {
                return Ok(RespVo.genError("请求参数错误"));
            }
            return Ok(SwBuAppService.getInstance().createCirclePipe(oInVo));
        }
    }
}
