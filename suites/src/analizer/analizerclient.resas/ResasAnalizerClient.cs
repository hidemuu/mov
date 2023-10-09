using Mov.Analizer.Models;
using Mov.Analizer.Service;
using Mov.Suite.AnalizerClient.Resas.Repository;

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

        public void Update()
        {

        }

        #endregion method
    }
}