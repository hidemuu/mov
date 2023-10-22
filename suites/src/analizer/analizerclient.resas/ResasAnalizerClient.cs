using Mov.Analizer.Models;
using Mov.Analizer.Models.Entities;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Service;
using Mov.Core.Valuables;
using Mov.Suite.AnalizerClient.Resas.Repository;
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
            if (!tableLines.Any())
			{
				await _analizerRepository.TableLines.PostsAsync(lines.Select(x => x.CreateSchema()));
			}
			return lines;
		}

		public async Task<IEnumerable<TimeTrend>> GetTimeTrendAsync(int prefCode, int cityCode, string category, string label, TimeValue start, TimeValue end)
		{
			var trends = new HashSet<TimeTrend>();
			var populationPerYears = await _resasRepository.PopulationPerYears.GetAsync(null);
			foreach (var populationPerYear in populationPerYears.Result.Datas)
			{
				foreach (var data in populationPerYear.Datas)
				{
					var timeTrend = new TimeTrend(
						"population",
						populationPerYear.IsAll() ?
							"all" : populationPerYear.IsYoung() ?
							"young" : populationPerYear.IsSenior() ?
							"senior" : populationPerYear.IsOld() ?
							"old" : string.Empty,
						TimeValue.Factory.CreateByDate(data.Year, 1, 1),
						new NumericalValue(data.Value)
						);
					
					trends.Add(timeTrend);
				}
			}
			return trends;
		}

		public Task<IEnumerable<TimeLine>> GetTimeLineAsync(int prefCode, int cityCode, string category, string label, TimeValue start, TimeValue end)
		{
			throw new System.NotImplementedException();
		}

		#endregion method
	}
}