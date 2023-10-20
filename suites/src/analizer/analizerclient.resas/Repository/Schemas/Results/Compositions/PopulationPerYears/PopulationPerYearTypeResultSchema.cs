using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results.Compositions.PopulationPerYears
{
    public sealed class PopulationPerYearTypeResultSchema
    {
        [JsonProperty("data")]
        [DisplayName("データ")]
        public List<PopulationPerYearTypeDataResultSchema> Datas { get; set; } = new List<PopulationPerYearTypeDataResultSchema>();
    }
}
