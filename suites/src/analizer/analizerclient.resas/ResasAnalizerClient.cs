using Mov.Analizer.Models;
using Mov.Analizer.Service;

namespace Mov.Suite.AnalizerClient.Resas
{
    public class ResasAnalizerClient : IRegionAnalizerClient
    {
        #region field

        private readonly IAnalizerRepository _repository;

        #endregion field

        #region constructor

        public ResasAnalizerClient(IAnalizerRepository repository) 
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        #endregion method
    }
}