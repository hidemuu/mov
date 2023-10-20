using Mov.Core.Attributes;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Mov.Core.Repositories
{
    public interface IDbSchema<TIdentifier>
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
        TIdentifier Id { get; set; }

        #endregion property

        #region method

        bool IsEmpty();

		#endregion method
	}
}
