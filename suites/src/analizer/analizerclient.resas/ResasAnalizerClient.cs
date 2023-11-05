using Mov.Analizer.Models;
using Mov.Analizer.Models.Entities;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Service;
using Mov.Analizer.Service.Regions;
using Mov.Analizer.Service.Regions.Entities;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Analizer.Service.Regions.ValueObjects;
using Mov.Analizer.Service.Stores;
using Mov.Core.Valuables;
using Mov.Suite.AnalizerClient.Resas.Repository;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<TableLineSchema>> GetTableLineAsync()
        {
			var lines = new HashSet<TableLine>();
			var cities = await _resasRepository.Cities.GetAsync(null);
            foreach (var city in cities.Results)
            {
				lines.Add(new TableLine(city.Code, _resasRepository.Cities.Name, string.Empty, city.Name, city.Name));
            }
			var prefectures = await _resasRepository.Prefectures.GetAsync(null);
			foreach (var prefecture in prefectures.Results)
			{
				lines.Add(new TableLine(prefecture.Code, _resasRepository.Prefectures.Name, string.Empty, prefecture.Name, prefecture.Name));
			}

            var tableLines = _analizerQuery.TableLines.Reader.ReadAll();
            if (!tableLines?.Any() ?? true)
			{
				_analizerCommand.TableLines.Deleter.Clear();
				_analizerCommand.TableLines.Saver.Save(lines.Select(x => x.CreateSchema()));
			}
			return lines.Select(x => x.CreateSchema());
		}

		public async Task<IEnumerable<TrendLineSchema>> GetTrendLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end)
		{
			var result = new HashSet<TrendLine>();
			var request = RegionRequest.Factory.Create(requestSchema);
			if (request.Category.Equals(new RegionCategory(_resasRepository.PopulationPerYears.Name)))
			{
				var populationPerYears = await _resasRepository.PopulationPerYears.GetRequestAsync(new PopulationPerYearRequestSchema(request));
				foreach (var populationPerYear in populationPerYears.Result.Datas)
				{
					foreach (var data in populationPerYear.Datas)
					{
						var dataLabel = populationPerYear.Name;

						if(request.Label.IsEmpty() || request.Label.Equals(dataLabel))
						{
							var timeTrend = new TrendLine(
							request.Category.Value,
							dataLabel,
							new NumericalValue(TimeValue.Factory.CreateByDate(data.Year, 1, 1).ToIntDateTime()),
							new NumericalValue(data.Value)
							);
							result.Add(timeTrend);
						}
					}
				}
			}
			
			return result.Select(x => x.CreateSchema());
		}

		public async Task<IEnumerable<TimeLineSchema>> GetTimeLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end)
		{
			var result = new HashSet<TimeLine>();
			return await Task.Run(() => result.Select(x => x.CreateSchema()));
		}

		public async Task<IEnumerable<StatisticLineSchema>> GetStatisticLineAsync()
		{
			var result = new HashSet<StatisticLine>();
			return await Task.Run(() => result.Select(x => x.CreateSchema()));
		}

		public async Task<IEnumerable<HistgramLineSchema>> GetHistgramLineAsync()
		{
			var result = new HashSet<HistgramLine>();
			return await Task.Run(() => result.Select(x => x.CreateSchema()));
		}

		#endregion method

		#region logic

		#endregion logic
	}
}