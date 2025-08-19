using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace wpfapp.nbi_web
{
    [RoutePrefix("api/values")]
    public class SampleController : ApiController
    {
        [HttpGet]
        [Route("")]  // 对应 /api/values
        public IHttpActionResult Get()
        {
            return Ok(new
            {
                Message = "来自 .NET Framework 4.7.2 的问候",
                Framework = ".NET Framework 4.7.2",
                Time = DateTime.Now
            });
        }

        [HttpGet]
        [Route("{id}")]  // 对应 /api/values/5
        public IHttpActionResult Get(int id)
        {
            return Ok(new
            {
                Id = id,
                Value = $"Value {id}"
            });
        }
    }
}
