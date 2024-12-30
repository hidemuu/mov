using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Models.Entities
{
    public class ApiSetting
    {
        #region property

        public Identifier<string> Code { get; }

        public string Key { get; }

        public string Value { get; }

        #endregion property

        #region constructor

        public ApiSetting(ApiSettingSchema schema)
        {
            this.Code = new Identifier<string>(schema?.Id);
            this.Key = schema?.Key;
            this.Value = schema?.Value;
        }

        public static ApiSetting Empty { get; } = new ApiSetting(null);

        #endregion constructor

        #region method

        public bool IsEmpty()
        {
            return this.Code.IsEmpty();
        }

        #endregion method
    }
}
