using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Results.Compositions.PopulationPerYears
{
    public sealed class PopulationPerYearTypeDataResultSchema
    {
        [JsonProperty("year")]
        [DisplayName("年")]
        public int Year { get; set; }

        [JsonProperty("value")]
        [DisplayName("値")]
        public int Value { get; set; }
    }
}
