using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models.Persistences
{
    public class UserSettingCommand : IPersistenceCommand<UserSetting>
    {
        #region フィールド

        private readonly IConfiguratorRepository repository;

        #endregion フィールド

        #region コンストラクター

        public UserSettingCommand(IConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Delete(UserSetting item)
        {
            this.repository.UserSettings.Delete(item);
        }

        public void Post(UserSetting item)
        {
            this.repository.UserSettings.Post(item);
        }

        #endregion メソッド
    }
}
