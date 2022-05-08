using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public class DrawItemCollection : DbObjectCollection<DrawItem>
    {
        [JsonProperty("draw_items")]
        public override DrawItem[] Items { get; set; }
    }

    public class DrawItem : DbObject
    {
        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
