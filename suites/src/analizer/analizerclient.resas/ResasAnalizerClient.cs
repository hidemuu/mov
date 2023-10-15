using Mov.Analizer.Models;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Service;
using Mov.Suite.AnalizerClient.Resas.Repository;
using System.Threading.Tasks;

namespace Mov.Suite.AnalizerClient.Resas
{
    public class ResasAnalizerClient : IRegionAnalizerClient
    {
        #region field

        private readonly IAnalizerRepository _repository;
        private readonly IResasRepository _resasRepository;

        #endregion field

        #region constructor

        public ResasAnalizerClient(IAnalizerRepository repository, string apiKey) 
        {
            _repository = repository;
            _resasRepository = new RestResasRepository(apiKey);
        }

        #endregion constructor

        #region method

        public async Task UpdateAsync()
        {
            var cities = await _resasRepository.Cities.GetAsync(null);
			var prefectures = await _resasRepository.Prefectures.GetAsync(null);
            await _repository.TableLines.PostAsync(new TableLineSchema());
		}

		#endregion method
	}
}