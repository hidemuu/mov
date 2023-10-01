using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Driver.Models.Schemas
{
    /// <summary>
    /// マクロ
    /// </summary>
    [XmlRoot("macro")]
    public class MacroSchema : DbSchemaBase<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 条件式のリスト
        /// </summary>
        [JsonProperty("expressions")]
        [XmlElement("expressions")]
        public List<Expression> Expressions = new List<Expression>();

        /// <summary>
        /// 内容説明
        /// </summary>
        //[StringLength(100)]
        [JsonProperty("description")]
        [XmlElement("description")]
        public string Description { get; set; } = string.Empty;
    }
}
