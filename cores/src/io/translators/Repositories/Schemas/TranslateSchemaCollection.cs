using Mov.Core.Repositories.Models;
using Mov.Core.Repositories.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators.Repositories.Schemas
{
    public sealed class TranslateSchemaCollection : IDbObjectCollection<TranslateSchema, int>
    {
        [JsonProperty("translates")]
        public TranslateSchema[] Items { get; set; }
    }
}
