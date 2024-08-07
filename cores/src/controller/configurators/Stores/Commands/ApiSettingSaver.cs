﻿using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Stores.Commands
{
    internal class ApiSettingSaver : ISave<ApiSetting>
    {
        #region field

        private readonly IConfiguratorRepository _repository;

        #endregion field

        #region constructor

        public ApiSettingSaver(IConfiguratorRepository repository)
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        public void Save(ApiSetting entity)
        {
            throw new NotImplementedException();
        }

		public void Save(IEnumerable<ApiSetting> entities)
		{
			throw new NotImplementedException();
		}

		#endregion method
	}
}
