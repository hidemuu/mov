using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Stores.Commands
{
    internal class ApiSettingCommand : IStoreCommand<ApiSetting>
    {
        #region property

        public ISave<ApiSetting> Saver { get; }

        public IDelete<ApiSetting> Deleter { get; }

        #endregion property

        #region constructor

        public ApiSettingCommand(IConfiguratorRepository repository)
        {
            this.Saver = new ApiSettingSaver(repository);
            this.Deleter = new ApiSettingDeleter(repository);
        }

        #endregion constructor

        #region method

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
