using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Requests
{
    public sealed class PopulationPerYearRequestSchema : IResasRequestSchema
    {
        #region field

        private readonly int _cityCode;

        private readonly int _prefCode;

        #endregion field

        #region constructor

        public PopulationPerYearRequestSchema(int cityCode, int prefCode) 
        {
            _cityCode = cityCode;
            _prefCode = prefCode;
        }

        #endregion constructor

        #region method

        public string Create()
        {
            return $"cityCode={_cityCode}&prefCode={_prefCode}";
        }

        #endregion method
    }
}
