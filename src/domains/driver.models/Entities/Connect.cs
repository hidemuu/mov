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
        /// <inheritdoc />
        [JsonProperty("connects")]
        [XmlElement(Type = typeof(Connect), ElementName = "connect")]
        public override Connect[] Items { get; set; }
    }

    /// <summary>
    /// 接続情報
    /// </summary>
    [XmlRoot("connect")]
    public class Connect : DbObject
    {
        /// <summary>
        /// IPアドレス
        /// </summary>
        [JsonProperty("ip_address")]
        [XmlElement("ip_address")]
        public string IpAddress { get; set; } = string.Empty;
        /// <summary>
        /// ポート番号
        /// </summary>
        [JsonProperty("port")]
        [XmlElement("port")]
        public int Port { get; set; } = 0;
        /// <summary>
        /// パスワード
        /// </summary>
        [JsonProperty("password")]
        [XmlElement("password")]
        public string Password { get; set; } = string.Empty;
    }
}
