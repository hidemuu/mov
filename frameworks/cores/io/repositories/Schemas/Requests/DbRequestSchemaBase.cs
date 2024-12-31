using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Repositories.Schemas.Requests
{
    public abstract class DbRequestSchemaBase : IDbRequestSchema
    {
        #region property

        public string Uri { get; } = string.Empty;

        #endregion property

        #region constructor

        public DbRequestSchemaBase(IReadOnlyDictionary<string, string> parameters)
        {
            var uri = string.Empty;
            foreach (var parameter in parameters)
            {
                uri += $"{parameter.Key}={parameter.Value}&";
            }
            Uri = uri.TrimEnd('&');
        }

        #endregion constructor

        #region method

        public bool IsEmpty() => Uri == string.Empty;

        #endregion method
    }
}
