using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.Extensions.Logging;
using ModularEndpoint.Modules.Importer.Core.Entities;

namespace ModularEndpoint.Modules.Importer.Core.Services
{
    public class WeatherHistoryImporter : IWeatherHistoryImporter
    {
        private readonly IWeatherHistoryService _weatherHistoryService;
        public WeatherHistoryImporter(IWeatherHistoryService weatherHistoryService)
        {
            _weatherHistoryService = weatherHistoryService;
        }
        public async Task ImportMeteorologicalData(string directoryPath)
        {
            List<Task<List<ClimateFormat>>> tasks = PrepareReadFileForClimateDataTasks(directoryPath);
            while(tasks.Count > 0)
            {
                Task taskFinished = await Task.WhenAny(tasks);
                if(taskFinished.Status == TaskStatus.RanToCompletion)
                {
                    List<MeteorologicalData> meteorologicalDatas =  GetMeteorologicalDatas(((Task<List<ClimateFormat>>) taskFinished).Result);
                    await _weatherHistoryService.AddRangeAsync(meteorologicalDatas);
                    tasks.Remove(((Task<List<ClimateFormat>>) taskFinished));
                }
            }
        }
        private MeteorologicalData MapToMeteorologicalData(ClimateFormat climateFormat)
        {
            return new MeteorologicalData()
            {
                StationName = climateFormat.StationName,
                Date = DateTime.Parse(string.Format("{0}-{1}-{2}", climateFormat.Year, climateFormat.Month.ToString().PadLeft(2,'0'), climateFormat.Day.ToString().PadLeft(2, '0'))),
                DailyTemperature = climateFormat.DailyTemperature,
                MaximumDailyTemperature = climateFormat.MaximumDailyTemperature,
                MinimumDailyTemperature = climateFormat.MinimumDailyTemperature
            };
           
        }
        private List<Task<List<ClimateFormat>>> PrepareReadFileForClimateDataTasks(string directoryPath)
        {
            List<Task<List<ClimateFormat>>> tasks = new List<Task<List<ClimateFormat>>>();
            foreach(string filePath in Directory.EnumerateFiles(directoryPath))
            {
                tasks.Add(ReadFileForClimateData(filePath));
            }
            return tasks;
        }
        private async Task<List<ClimateFormat>> ReadFileForClimateData(string filePath)
        {
            using(TextReader reader = new StreamReader(filePath, Encoding.GetEncoding(1250)))
            {
                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };
                using(var csvReader = new CsvReader(reader, csvConfiguration))
                { 
                    List<ClimateFormat> climateFormats = new List<ClimateFormat>();
                    while(await csvReader.ReadAsync())
                    {
                        climateFormats.Add(csvReader.GetRecord<ClimateFormat>());
                    }
                    return climateFormats;
                }
            }
        }
        private List<MeteorologicalData> GetMeteorologicalDatas(List<ClimateFormat> climateFormats)
        {
            return climateFormats.Select(data => MapToMeteorologicalData(data)).ToList();
        }
        private class ClimateFormat
        { 
            [Index(0)]
            public string Id { get; set; }
            [Index(1)]
            public string StationName { get; set; }
            [Index(2)]
            public int Year { get; set; }
            [Index(3)]
            public int Month { get; set; }
            [Index(4)]
            public int Day { get; set; }
            [Index(5)]
            public double MaximumDailyTemperature { get; set; }
            [Index(6)]
            public string StatusMaxT { get; set; }
            [Index(7)]
            public double MinimumDailyTemperature { get; set; }
            [Index(8)]
            public string StatusMinT { get; set; }
            [Index(9)]
            public double DailyTemperature { get; set; }
            [Index(10)]
            public string StatusDT { get; set; }
            [Index(11)]
            public double MinimumNearGroundTemperature { get; set; }
            [Index(12)]
            public string StatusMNGT { get; set; }
            [Index(13)]
            public double DailyPrecipitation { get; set; }
            [Index(14)]
            public string StatusDP { get; set; }
            [Index(15)]
            public string PrecipitationType { get; set; }
            [Index(16)]
            public double SnowHeigth { get; set; }
            [Index(17)]
            public string StatusSH { get; set; }
        }
    }
}