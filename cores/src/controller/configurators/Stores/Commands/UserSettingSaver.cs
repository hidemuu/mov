using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Stores.Commands
{
    internal class UserSettingSaver : ISave<UserSetting>
    {
        #region field

        private readonly IConfiguratorRepository _repository;

        #endregion field

        #region constructor

        public UserSettingSaver(IConfiguratorRepository repository) 
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        public void Save(UserSetting entity)
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
