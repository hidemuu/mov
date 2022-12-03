using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Models.Queue
{
    public class QueueObject
    {
        /// <summary>
        /// ネームキー
        /// </summary>
        [JsonProperty("namekey")]
        public string Namekey { get; set; }
    }
}
