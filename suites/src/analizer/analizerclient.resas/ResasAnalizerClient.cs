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

        public async Task<IEnumerable<TableLine>> GetTableLineAsync()
        {
			var lines = new HashSet<TableLine>();
			var cities = await _resasRepository.Cities.GetAsync(null);
            foreach (var city in cities.Results)
            {
				lines.Add(new TableLine(city.Code, "city", string.Empty, city.Name, city.Name));
            }
			var prefectures = await _resasRepository.Prefectures.GetAsync(null);
			foreach (var prefecture in prefectures.Results)
			{
				lines.Add(new TableLine(prefecture.Code, "prefecture", string.Empty, prefecture.Name, prefecture.Name));
			}

            var tableLines = await _analizerRepository.TableLines.GetsAsync();
            if (!tableLines?.Any() ?? true)
			{
				await _analizerRepository.TableLines.PostsAsync(lines.Select(x => x.CreateSchema()));
			}
			return lines;
		}

		public async Task<IEnumerable<TimeTrend>> GetTimeTrendAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end)
		{
			var result = new HashSet<TimeTrend>();
			var request = RegionRequest.Factory.Create(requestSchema);
			if (request.Category.Equals("population", StringComparison.Ordinal))
			{
				var populationPerYears = await _resasRepository.PopulationPerYears.GetRequestAsync(new PopulationPerYearRequestSchema(request.PrefCode, request.CityCode));
				foreach (var populationPerYear in populationPerYears.Result.Datas)
				{
					foreach (var data in populationPerYear.Datas)
					{
						var dataLabel = populationPerYear.IsAll() ?
								"all" : populationPerYear.IsYoung() ?
								"young" : populationPerYear.IsSenior() ?
								"senior" : populationPerYear.IsOld() ?
								"old" : string.Empty;

						if(request.IsEmptyLabel() || request.Label.Equals(dataLabel))
						{
							var timeTrend = new TimeTrend(
							request.Category,
							dataLabel,
							TimeValue.Factory.CreateByDate(data.Year, 1, 1),
							new NumericalValue(data.Value)
							);
							result.Add(timeTrend);
						}
					}
				}
			}
			
			return result;
		}

		public Task<IEnumerable<TimeLine>> GetTimeLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end)
		{
			throw new System.NotImplementedException();
		}

		#endregion method
	}
}