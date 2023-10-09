using Mov.Suite.AnalizerClient.Resas.Schemas.Results.Compositions.PopulationPerYears;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Results
{
    public sealed class PopulationPerYearResultSchema : IResasResultSchema
    {
        #region constants

        public const string URI = @"population/composition/perYear?";

        #endregion constants

        #region property

        [JsonProperty("data")]
        [DisplayName("データ")]
        public List<PopulationPerYearTypeResultSchema> Datas { get; set; } = new List<PopulationPerYearTypeResultSchema>();

        #endregion property
    }
}
