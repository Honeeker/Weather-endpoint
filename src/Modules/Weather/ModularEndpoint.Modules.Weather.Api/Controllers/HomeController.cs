using Microsoft.AspNetCore.Mvc;

namespace ModularEndpoint.Modules.Weather.Api.Controllers
{
    [Route(BasePath)]
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Weather module";
    }
   
}