using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Results.Compositions.PopulationPyramids
{
    public sealed class PopulationPyramidYearResultSchema
    {
        [JsonProperty("data")]
        [DisplayName("データ")]
        public List<PopulationPyramidYearDataResultSchema> Datas { get; set; } = new List<PopulationPyramidYearDataResultSchema>();
    }
}
