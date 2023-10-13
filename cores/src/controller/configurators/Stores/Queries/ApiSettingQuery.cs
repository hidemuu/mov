using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores.Services.Queries.Readers.Decorators;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Stores.Queries
{
    internal class ApiSettingQuery : IStoreQuery<ApiSetting, string>
    {
        #region property

        public IRead<ApiSetting, string> Reader { get; }

        #endregion property

        #region constructor

        public ApiSettingQuery(IConfiguratorRepository repository)
        {
            this.Reader = new ReadCaching<ApiSetting, string>(new ApiSettingReader(repository));
        }

        #endregion constructor
    }
}
