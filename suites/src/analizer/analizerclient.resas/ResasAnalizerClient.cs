using Mov.Analizer.Models;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Service;
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

        public async Task UpdateAsync()
        {
			var schemas = new HashSet<TableLineSchema>();
			var cities = await _resasRepository.Cities.GetAsync(null);
            foreach (var city in cities.Results)
            {
                schemas.Add(new TableLineSchema()
                {
                    Category = "city",
                    Code = city.Code.ToString(),
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
					Code = prefecture.Code.ToString(),
					Name = prefecture.Name,
					Content = prefecture.Name,
				});
			}

            var tableLines = await _analizerRepository.TableLines.GetsAsync();
            if (tableLines.Any()) return;
            foreach (var schema in schemas)
            {
				await _analizerRepository.TableLines.PostAsync(schema);
			}
		}

		#endregion method
	}
}