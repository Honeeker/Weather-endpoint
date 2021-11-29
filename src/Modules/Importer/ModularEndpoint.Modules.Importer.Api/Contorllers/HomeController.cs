using Microsoft.AspNetCore.Mvc;

namespace ModularEndpoint.Modules.Importer.Api.Contorllers
{
    [Route(BasePath)]
    internal class HomeController: BaseController
    {
        [HttpGet]
        public ActionResult<string> GetModule() => "Import module"; 
    }
}