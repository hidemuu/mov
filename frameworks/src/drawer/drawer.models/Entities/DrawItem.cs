using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;

namespace Mov.Drawer.Models.Entities
{
    public class DrawItemCollection : DbCollectionSchemaBase<DrawItem, Guid>
    {
        [JsonProperty("draw_items")]
        public override DrawItem[] Items { get; set; }
    }

    public class DrawItem : DbSchemaBase<Guid>
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; } = 600;

        [JsonProperty("height")]
        public int Height { get; set; } = 600;

        [JsonProperty("reflesh_rate")]
        public double RefleshRate { get; set; } = 10;
    }
}