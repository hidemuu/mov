using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models
{
    /// <summary>
    /// 接続情報のコレクション
    /// </summary>
    [XmlRoot("connects")]
    public class ConnectCollection : DbObjectCollection<Connect>
    {
        /// <summary>
        /// コレクション
        /// </summary>
        [JsonProperty("connects")]
        [XmlElement(Type = typeof(Connect), ElementName = "connect")]
        public override Connect[] Items { get; set; }
    }

    public class Connect : DbObject
    {
    }
}
