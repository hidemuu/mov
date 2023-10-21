using Mov.Analizer.Models;
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

        public async Task UpdateTableAsync()
        {
			var schemas = new HashSet<TableLineSchema>();
			var cities = await _resasRepository.Cities.GetAsync(null);
            foreach (var city in cities.Results)
            {
                schemas.Add(new TableLineSchema()
                {
                    Category = "city",
                    Id = city.Code,
                    Name = city.Name,
                    Content = city.Name,
                });
            }
			var prefectures = await _resasRepository.Prefectures.GetAsync(null);
			foreach (var prefecture in prefectures.Results)
			{
				schemas.Add(new TableLineSchema()
				{
					Category = "prefecture",
					Id = prefecture.Code,
					Name = prefecture.Name,
					Content = prefecture.Name,
				});
			}

            var tableLines = await _analizerRepository.TableLines.GetsAsync();
            if (tableLines.Any()) return;
			await _analizerRepository.TableLines.PostsAsync(schemas);
		}

		public async Task GetTimeTrendAsync(int prefCode, int cityCode, TimeValue start, TimeValue end)
		{
			var schemas = new HashSet<TimeTrendSchema>();
			var populationPerYears = await _resasRepository.PopulationPerYears.GetAsync(null);
			foreach (var populationPerYear in populationPerYears.Result.Datas)
			{
				foreach (var data in populationPerYear.Datas)
				{
					schemas.Add(new TimeTrendSchema()
					{
						Category = "population",
						Label = populationPerYear.IsAll() ?
							"all" : populationPerYear.IsYoung() ? 
							"young" : populationPerYear.IsSenior() ? 
							"senior" : populationPerYear.IsOld() ? 
							"old" : string.Empty
					});
				}
			}
		}

		public Task GetTimeLineAsync(int prefCode, int cityCode, TimeValue start, TimeValue end)
		{
			throw new System.NotImplementedException();
		}

		#endregion method
	}
}