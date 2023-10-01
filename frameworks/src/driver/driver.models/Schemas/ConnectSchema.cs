using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models.Schemas
{
    /// <summary>
    /// 接続情報
    /// </summary>
    [XmlRoot("connect")]
    public class ConnectSchema : DbSchemaBase<Guid>
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
