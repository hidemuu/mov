using Mov.Core.Models.DbObjects.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators.Repositories.Schemas
{
    public sealed class TranslateSchemaCollection : DbObjectCollection<TranslateSchema>
    {
        [JsonProperty("translates")]
        public override TranslateSchema[] Items { get; set; }
    }
}
