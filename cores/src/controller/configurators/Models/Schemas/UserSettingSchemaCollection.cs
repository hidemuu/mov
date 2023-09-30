using Mov.Core.Repositories.Schemas;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Mov.Core.Configurators.Models.Schemas
{
    /// <summary>
    /// 設定のコレクション
    /// </summary>
    [XmlRoot("configs")]
    public class UserSettingSchemaCollection : DbTableCollectionSchema<UserSettingSchema, Guid>
    {
        /// <inheritdoc />
        [JsonProperty("configs")]
        [XmlElement(Type = typeof(UserSettingSchema), ElementName = "config")]
        public override UserSettingSchema[] Items { get; set; }
    }
}
