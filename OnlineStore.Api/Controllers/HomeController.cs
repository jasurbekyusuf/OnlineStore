using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace OnlineStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Online Store is running");
    }
}
