using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using ModularEndpoint.Modules.Importer.Core.CsvMappings;
using ModularEndpoint.Modules.Importer.Core.Entities;
using ModularEndpoint.Modules.Importer.Core.Models;

namespace ModularEndpoint.Modules.Importer.Core.Services
{
    public class WeatherHistoryImporter : IWeatherHistoryImporter
    {
        private readonly IWeatherHistoryService _weatherHistoryService;
        private readonly ILogger<WeatherHistoryImporter> _logger;
        public WeatherHistoryImporter(IWeatherHistoryService weatherHistoryService, ILogger<WeatherHistoryImporter> logger)
        {
            _weatherHistoryService = weatherHistoryService;
            _logger = logger;
        }
        public async Task ImportMeteorologicalData(string directoryPath)
        {
            _logger.LogInformation("Preparing tasks to read file");
            List<Task<List<BaseClimateFormat>>> tasks = PrepareReadFileForClimateDataTasks(directoryPath);
            _logger.LogInformation($"Files to import: {tasks.Count} ");
            while(tasks.Count > 0)
            {
                Task taskFinished = await Task.WhenAny(tasks);
                if(taskFinished.Status == TaskStatus.RanToCompletion)
                {
                    List<MeteorologicalData> meteorologicalDatas =  GetMeteorologicalDatas(((Task<List<BaseClimateFormat>>) taskFinished).Result);
                    await _weatherHistoryService.AddRangeAsync(meteorologicalDatas);
                    tasks.Remove(((Task<List<BaseClimateFormat>>) taskFinished));
                    _logger.LogInformation($"Left {tasks.Count} tasks.");
                }
            }
            _logger.LogInformation("Import done");
        }
        private MeteorologicalData MapToMeteorologicalData(BaseClimateFormat BaseClimateFormat)
        {
            return new MeteorologicalData()
            {
                StationId = Convert.ToInt32(BaseClimateFormat.Id),
                Date = DateTime.Parse(string.Format("{0}-{1}-{2}", BaseClimateFormat.Year, BaseClimateFormat.Month.ToString().PadLeft(2,'0'), BaseClimateFormat.Day.ToString().PadLeft(2, '0'))),
                DailyTemperature = BaseClimateFormat.DailyTemperature,
                MaximumDailyTemperature = BaseClimateFormat.MaximumDailyTemperature,
                MinimumDailyTemperature = BaseClimateFormat.MinimumDailyTemperature
            };
           
        }
        private List<Task<List<BaseClimateFormat>>> PrepareReadFileForClimateDataTasks(string directoryPath)
        {
            List<Task<List<BaseClimateFormat>>> tasks = new List<Task<List<BaseClimateFormat>>>();
            foreach(string filePath in Directory.EnumerateFiles(directoryPath))
            {
                tasks.Add(ReadFileForClimateData(filePath));
            }
            return tasks;
        }
        private async Task<List<BaseClimateFormat>> ReadFileForClimateData(string filePath)
        {
            using(TextReader reader = new StreamReader(filePath, Encoding.GetEncoding(1250)))
            {
                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };
                using(var csvReader = new CsvReader(reader, csvConfiguration))
                { 
                    csvReader.Context.RegisterClassMap<BaseClimateFormatMap>();

                    List<BaseClimateFormat> BaseClimateFormats = new List<BaseClimateFormat>();
                    while(await csvReader.ReadAsync())
                    {
                      
                        BaseClimateFormats.Add(csvReader.GetRecord<BaseClimateFormat>());
                    }
                    return BaseClimateFormats;
                }
            }
        }
        private List<MeteorologicalData> GetMeteorologicalDatas(List<BaseClimateFormat> baseClimateFormats)
        {
            return baseClimateFormats.Select(data => MapToMeteorologicalData(data)).ToList();
        }
    }
}