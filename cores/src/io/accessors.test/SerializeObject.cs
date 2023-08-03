using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Accessors.Test
{
    [JsonObject]
    public class SerializeObject
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;
    }
}
