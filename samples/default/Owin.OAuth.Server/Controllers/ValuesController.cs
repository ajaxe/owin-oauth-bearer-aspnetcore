using System.Collections.Generic;
using System.Web.Http;

namespace Owin.OAuth.Server.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            return Json(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            return Content(System.Net.HttpStatusCode.OK, "value");
        }

        [Authorize]
        [Route("authenticated")]
        public IHttpActionResult GetAuthenticated()
        {
            
            return Json(new
            {
                @for = this.User.Identity.Name,
                data = new string[] { "auth-value1", "auth-value2" }
            });
        }
    }
}
