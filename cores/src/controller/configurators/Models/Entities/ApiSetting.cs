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

        public string Value { get; }

        #endregion property

        #region constructor

        public ApiSetting(ApiSettingSchema schema)
        {
            this.Code = new Identifier<string>(schema.Id);
            this.Value = schema.Value;
        }

        #endregion constructor
    }
}
