using Mov.Utilities.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Shields.Models.Entities.Robot
{
    public class Robot : QueueObject
    {
        /// <summary>
        /// Available等
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// Unlocated等
        /// </summary>
        [JsonProperty("subStatus")]
        public string SubStatus { get; set; }
    }
}
