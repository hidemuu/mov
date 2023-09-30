using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Configurators.Stores.Queries
{
    internal class UserSettingReader : IRead<UserSetting, Guid>
    {
        #region field

        private readonly IConfiguratorRepository _repository;

        #endregion field

        #region constructor

        public UserSettingReader(IConfiguratorRepository repository)
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        public IEnumerable<UserSetting> ReadAll()
        {
            var configs = Task.WhenAll(_repository.UserSettings.GetAsync()).Result[0];
            var result = new List<UserSetting>();
            foreach (var config in configs)
            {
                result.Add(new UserSetting(config));
            }
            return result;
        }

        public UserSetting Read(Guid id)
        {
            var config = Task.WhenAll(_repository.UserSettings.GetAsync(id)).Result[0];
            return new UserSetting(config);
        }

        #endregion method
    }
}
