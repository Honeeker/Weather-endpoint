using Microsoft.AspNetCore.Mvc;

namespace ModularEndpoint.Modules.Weather.Api.Controllers
{
    [ApiController]
    [Route(BasePath + "/[controller]")]
    internal abstract class BaseController: ControllerBase
    {
        protected const string BasePath = "weather-module";
    }
}