using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Models;

namespace Mov.Core.Configurators.Models.Entities
{
    public class UserSetting
    {
        #region property

        public Identifier<string> Code { get; }

        public string Value { get; }

        #endregion property

        #region constructor

        public UserSetting(UserSettingSchema schema)
        {
            this.Code = new Identifier<string>(schema.Code);
            this.Value = schema.Value;
        }

        #endregion constructor
    }
}
