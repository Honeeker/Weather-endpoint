using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModularEndpoint.Modules.Importer.Core.Services;

namespace ModularEndpoint.Modules.Importer.Api.Contorllers
{
    internal class ImportController: BaseController
    {
        private readonly IWeatherHistoryImporter _weatherHistoryImporter;
        public ImportController(IWeatherHistoryImporter weatherHistoryImporter)
        {
            _weatherHistoryImporter = weatherHistoryImporter;
        }
        [HttpPost]
        public async Task<ActionResult> ImportMeteorologicalData([FromBody] string directoryPath)
        {
            try
            {  
                await _weatherHistoryImporter.ImportMeteorologicalData(directoryPath);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }
    }
}