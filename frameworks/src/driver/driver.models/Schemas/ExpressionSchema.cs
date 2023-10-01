using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Mov.Driver.Models.Schemas
{
    /// <summary>
    /// 条件式
    /// </summary>
    [XmlRoot("expression")]
    public class ExpressionSchema
    {
        /// <summary>
        /// 左辺
        /// </summary>
        [JsonProperty("left_side")]
        [XmlElement("left_side")]
        public string LeftSide = string.Empty;

        /// <summary>
        /// 等号・不等号
        /// </summary>
        [JsonProperty("sign")]
        [XmlElement("sign")]
        public string Sign = string.Empty;

        /// <summary>
        /// 右辺
        /// </summary>
        [JsonProperty("right_side")]
        [XmlElement("right_side")]
        public string RightSide = string.Empty;
    }
}
