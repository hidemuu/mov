using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Requests
{
    public sealed class PopulationPerYearRequestSchema : IResasRequestSchema
    {
        #region field

        #endregion field

        #region property

        public IReadOnlyDictionary<string, string> Parameters { get; }

        #endregion property

        #region constructor

        public PopulationPerYearRequestSchema(int cityCode, int prefCode) 
        {
            Parameters = new Dictionary<string, string>()
            {
                { "cityCode", cityCode.ToString() },
                { "prefCode", prefCode.ToString() },
            };
        }

        #endregion constructor

    }
}
