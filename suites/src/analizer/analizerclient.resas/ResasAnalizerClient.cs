﻿using Mov.Analizer.Models;
using Mov.Analizer.Models.Entities;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Service;
using Mov.Analizer.Service.Regions;
using Mov.Analizer.Service.Regions.Entities;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Analizer.Service.Regions.ValueObjects;
using Mov.Analizer.Service.Stores;
using Mov.Core.Repositories.Schemas.Responses;
using Mov.Core.Valuables;
using Mov.Core.Valuables.Dimensions.Coordinates.TwoDimensions;
using Mov.Suite.AnalizerClient.Resas.Repository;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Requests;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Mov.Suite.AnalizerClient.Resas
{
    public class ResasAnalizerClient : IRegionAnalizerClient
    {
		#region constant

		#endregion constant

		#region field

        private readonly IResasRepository _resasRepository;
		private readonly IAnalizerQuery _analizerQuery;
		private readonly IAnalizerCommand _analizerCommand;

        #endregion field

        #region constructor

        public ResasAnalizerClient(IAnalizerRepository analizerRepository, IResasRepository resasRepository) 
        {
			_analizerQuery = new AnalizerQuery(analizerRepository);
			_analizerCommand = new AnalizerCommand(analizerRepository);
			_resasRepository = resasRepository;
		}

        #endregion constructor

        #region method

        public async Task<DbResponseSchema<string, TableLineSchema>> GetTableLineAsync()
        {
			var lines = new List<TableLineSchema>();
			lines.AddRange((await GetPrefectureTableLineAsync()).Results);
			lines.AddRange((await GetCityTableLineAsync()).Results);
			
            var tableLines = _analizerQuery.TableLines.Reader.ReadAll();
            if (!tableLines?.Any() ?? true)
			{
				_analizerCommand.TableLines.Deleter.Clear();
				_analizerCommand.TableLines.Saver.Save(lines);
			}
			return new DbResponseSchema<string, TableLineSchema> 
			{
				Results = lines
			};
		}

		public async Task<DbResponseSchema<string, TableLineSchema>> GetPrefectureTableLineAsync()
		{
			var lines = new HashSet<TableLine>();
			var prefectures = await _resasRepository.Prefectures.GetAsync(null);
			foreach (var prefecture in prefectures.Results)
			{
				lines.Add(new TableLine(prefecture.Code, _resasRepository.Prefectures.Name, "JP", prefecture.Name, prefecture.Name));
			}
			return new DbResponseSchema<string, TableLineSchema> { Results = lines.Select(x => x.CreateSchema()).ToList() };
		}

		public async Task<DbResponseSchema<string, TableLineSchema>> GetCityTableLineAsync()
		{
			var lines = new HashSet<TableLine>();
			var cities = await _resasRepository.Cities.GetAsync(null);
			foreach (var city in cities.Results)
			{
				lines.Add(new TableLine(city.Code, _resasRepository.Cities.Name, city.PrefCode.ToString(), city.Name, city.Name));
			}
			return new DbResponseSchema<string, TableLineSchema> { Results = lines.Select(x => x.CreateSchema()).ToList() };
		}

		public async Task<DbResponseSchema<string, TableLineSchema>> GetCityTableLineAsync(int prefCode)
		{
			var cities = await GetCityTableLineAsync();
			return new DbResponseSchema<string, TableLineSchema> { Results = cities.Results.Where(x => x.Label.Equals(prefCode.ToString())).ToList() };
		}

		public async Task<DbResponseSchema<string, RegionResponseSchema<TrendLineSchema>>> GetTrendLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end)
		{
			var request = RegionRequest.Factory.Create(requestSchema);
			if (request.Category.Equals(new RegionCategory(_resasRepository.PopulationPerYears.Name)))
			{
				var result = await GetPopulationPerYearsTrendLineAsync(request);
				return result;
			}
			return null;
		}

		public async Task<DbResponseSchema<string, TimeLineSchema>> GetTimeLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end)
		{
			var result = new HashSet<TimeLine>();
			return new DbResponseSchema<string, TimeLineSchema> { Results = (await Task.Run(() => result.Select(x => x.CreateSchema()))).ToList() };
		}

		public async Task<DbResponseSchema<string, StatisticLineSchema>> GetStatisticLineAsync()
		{
			var result = new HashSet<StatisticLine>();
			return new DbResponseSchema<string, StatisticLineSchema> { Results = (await Task.Run(() => result.Select(x => x.CreateSchema()))).ToList() };
		}

		public async Task<DbResponseSchema<string, HistgramLineSchema>> GetHistgramLineAsync()
		{
			var result = new HashSet<HistgramLine>();
			return new DbResponseSchema<string, HistgramLineSchema> { Results = (await Task.Run(() => result.Select(x => x.CreateSchema()))).ToList() };
		}

		#endregion method

		#region logic

		private async Task<DbResponseSchema<string, RegionResponseSchema<TrendLineSchema>>> GetPopulationPerYearsTrendLineAsync(RegionRequest request)
		{
			var result = new HashSet<RegionResponseSchema<TrendLineSchema>>();
			foreach(var region in request.Regions)
			{
				var prefCode = region.Code;
				foreach(var city in region.Cities)
				{
					var trendLineSchemas = new HashSet<TrendLineSchema>();
					try
					{
						var populationPerYears = await _resasRepository.PopulationPerYears.GetRequestAsync(new PopulationPerYearRequestSchema(city.Code, prefCode));
						foreach (var trendLine in GetPopulationPerYearTrendLine(request, prefCode, city.Code, populationPerYears.Result))
						{
							trendLineSchemas.Add(trendLine.CreateSchema());
						}
					}
					catch(Exception ex)
					{
						Console.WriteLine(ex.ToString());
					}
					result.Add(new RegionResponseSchema<TrendLineSchema>()
					{
						Region = new RegionValueSchema
						{
							PrefCode = prefCode,
							PrefName = region.Name,
							CityCode = city.Code,
							CityName = city.Name,
						},
						Data = trendLineSchemas.ToList(),
					});
				}
			}
			return new DbResponseSchema<string, RegionResponseSchema<TrendLineSchema>>
			{
				Id = "",
				Results = result.ToList(),
			};
		}

		private IEnumerable<TrendLine> GetPopulationPerYearTrendLine(RegionRequest request, int pref, int city, PopulationPerYearResultSchema schema)
		{
			var result = new HashSet<TrendLine>();
			if (schema == null) return result;
			foreach (var populationPerYear in schema.Datas)
			{
				foreach (var data in populationPerYear.Datas)
				{
					var dataLabel = populationPerYear.Name;

					if (request.Label.IsEmpty() || request.Label.Equals(new RegionLabel(dataLabel)))
					{
						var timeTrend = new TrendLine(
						pref.ToString(),
						city.ToString(),
						new NumericalValue(data.Year),
						new NumericalValue(data.Value)
						);
						result.Add(timeTrend);
					}
				}
			}
			return result;
		}

		#endregion logic
	}
}