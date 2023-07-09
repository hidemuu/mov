using Mov.Core.Contexts.DbObjects.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators.Repositories.Schemas
{
    public sealed class TranslateSchema : DbObject
    {
        [JsonProperty("jp")]
        public string JP { get; set; }

        [JsonProperty("en")]
        public string EN { get; set; }
    }
}
