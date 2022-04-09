using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Authorizer.Models
{
    [XmlRoot("user")]
    public class User : AuthorizerObject
    {
        [JsonProperty("loginid")]
        [XmlElement("loginid")]
        public string LoginId { get; set; }
        [JsonProperty("password")]
        [XmlElement("password")]
        public string Password { get; set; }
    }
}
