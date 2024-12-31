using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Configurators.Stores.Queries
{
    internal class ApiSettingReader : IRead<ApiSetting, string>
    {
        #region field

        private readonly IConfiguratorRepository _repository;

        #endregion field

        #region constructor

        public ApiSettingReader(IConfiguratorRepository repository)
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        public IEnumerable<ApiSetting> ReadAll()
        {
            var configs = Task.WhenAll(_repository.ApiSettings.GetsAsync()).Result[0];
            var result = new List<ApiSetting>();
            foreach (var config in configs)
            {
                result.Add(new ApiSetting(config));
            }
            return result;
        }

        public ApiSetting Read(string id)
        {
            var config = Task.WhenAll(_repository.ApiSettings.GetAsync(id)).Result[0];
            return new ApiSetting(config);
        }

        #endregion method
    }
}
