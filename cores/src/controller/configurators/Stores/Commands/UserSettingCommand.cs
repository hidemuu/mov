using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Stores.Commands
{
    internal class UserSettingCommand : IStoreCommand<UserSetting, Guid>
    {
        #region property

        public ISave<UserSetting> Saver { get; }

        public IDelete<UserSetting, Guid> Deleter { get; }

        #endregion property

        #region constructor

        public UserSettingCommand(IConfiguratorRepository repository)
        {
            this.Saver = new UserSettingSaver(repository);
            this.Deleter = new UserSettingDeleter(repository);
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
