using Mov.Analizer.Models;
using Mov.Analizer.Models.Entities;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Service;
using Mov.Analizer.Service.Regions;
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

		private readonly IAnalizerRepository _analizerRepository;
        private readonly IResasRepository _resasRepository;

        #endregion field

        #region constructor

        public ResasAnalizerClient(IAnalizerRepository analizerRepository, IResasRepository resasRepository) 
        {
            _analizerRepository = analizerRepository;
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

            var tableLines = await _analizerRepository.TableLines.GetsAsync();
            if (!tableLines?.Any() ?? true)
			{
				await _analizerRepository.TableLines.PostsAsync(lines.Select(x => x.CreateSchema()));
			}
			return lines.Select(x => x.CreateSchema());
		}

		public async Task<IEnumerable<TrendLineSchema>> GetTrendLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end)
		{
			var result = new HashSet<TrendLine>();
			var request = RegionRequest.Factory.Create(requestSchema);
			if (request.Category.Equals(new RegionCategory(_resasRepository.PopulationPerYears.Name)))
			{
				var populationPerYears = await _resasRepository.PopulationPerYears.GetRequestAsync(new PopulationPerYearRequestSchema(request.PrefCode, request.CityCode));
				foreach (var populationPerYear in populationPerYears.Result.Datas)
				{
					foreach (var data in populationPerYear.Datas)
					{
						var dataLabel = populationPerYear.Name;

						if(request.IsEmptyLabel() || request.Label.Equals(dataLabel))
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

		public Task<IEnumerable<TimeLineSchema>> GetTimeLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<StatisticLineSchema>> GetStatisticLineAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<HistgramLineSchema>> GetHistgramLineAsync()
		{
			throw new NotImplementedException();
		}

		#endregion method
	}
}