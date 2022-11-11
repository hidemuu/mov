using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Configurator.Models.Persistences
{
    public class UserSettingQuery : IPersistenceQuery<UserSetting>
    {
        #region フィールド

        private readonly IConfiguratorRepository repository;

        #endregion フィールド

        #region コンストラクター

        public UserSettingQuery(IConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<UserSetting> Get()
        {
            return this.repository.UserSettings.Get();
        }

        public IEnumerable<UserSetting> Get(string param)
        {
            return Get().Where(x => x.Name == param);
        }

        public UserSetting Get(Guid id)
        {
            return this.repository.UserSettings.Get(id);
        }

        public override string ToString() => this.repository.UserSettings.ToString();

        #endregion メソッド
    }
}
