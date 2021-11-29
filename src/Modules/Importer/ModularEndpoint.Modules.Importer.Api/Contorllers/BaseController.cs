using Microsoft.AspNetCore.Mvc;

namespace ModularEndpoint.Modules.Importer.Api.Contorllers
{
    [ApiController]
    [Route(BasePath + "/[controller]")]
    internal abstract class BaseController: ControllerBase
    {
        protected const string BasePath = "import-module";
    }
}