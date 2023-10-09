using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.Schemas
{
    public class LandmarkCollectionSchema : DbCollectionSchemaBase<LandmarkSchema, Guid>
    {
        [JsonProperty("landmarks")]
        public override LandmarkSchema[] Items { get; set; }
    }
}
