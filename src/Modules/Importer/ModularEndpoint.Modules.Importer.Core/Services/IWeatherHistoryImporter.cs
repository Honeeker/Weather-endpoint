using System.Threading.Tasks;

namespace ModularEndpoint.Modules.Importer.Core.Services
{
    public interface IWeatherHistoryImporter
    {
        Task ImportMeteorologicalData(string directoryPath);
    }
}