using Mov.Core.Repositories.Models;
using Mov.Core.Repositories.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators.Repositories.Schemas
{
    public sealed class TranslateSchema : IDbObject<int>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("jp")]
        public string JP { get; set; }

        [JsonProperty("en")]
        public string EN { get; set; }
        
    }
}
