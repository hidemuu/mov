﻿using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators.Stores.Commands
{
    internal class UserSettingDeleter : IDelete<UserSetting>
    {
        #region field

        private readonly IConfiguratorRepository _repository;

        #endregion field

        #region constructor

        public UserSettingDeleter(IConfiguratorRepository repository)
        {
            _repository = repository;
        }

		#endregion constructor

		#region method

		public void Delete(UserSetting entity)
        {
            throw new NotImplementedException();
        }

		public void Clear()
		{
			throw new NotImplementedException();
		}

		#endregion method
	}
}
