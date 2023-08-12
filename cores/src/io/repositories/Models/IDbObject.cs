using Mov.Core.Attributes;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Mov.Core.Repositories.Models
{
    public interface IDbObject<TKey>
    {
        #region property

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        [XmlElement("id")]
        [LanguageKey("id")]
        [DisplayName("id")]
        [DisplayIndex(0)]
        TKey Id { get; set; }

        #endregion property

    }
}
