using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Configurators.Stores.Commands;
using Mov.Core.Configurators.Stores.Queries;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Stores
{
    internal class ApiSettingStore : IStore<ApiSetting, string>
    {

        #region property

        public IStoreCommand<ApiSetting> Command { get; }

        public IStoreQuery<ApiSetting, string> Query { get; }

        #endregion property

        #region constructor

        public ApiSettingStore(IConfiguratorRepository repository)
        {
            this.Query = new ApiSettingQuery(repository);
            this.Command = new ApiSettingCommand(repository);
        }

        #endregion constructor
    }
}
