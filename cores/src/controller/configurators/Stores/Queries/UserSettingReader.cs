using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

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

        public UserSetting Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSetting> ReadAll()
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
