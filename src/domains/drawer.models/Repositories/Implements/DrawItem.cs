using Mov.Accessors;
using Mov.BaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Models
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
        [JsonProperty("width")]
        public int Width { get; set; } = 600;
        [JsonProperty("height")]
        public int Height { get; set; } = 600;
        [JsonProperty("reflesh_rate")]
        public double RefleshRate { get; set; } = 10;

    }
}
