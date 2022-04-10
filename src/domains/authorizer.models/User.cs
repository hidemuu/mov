using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Authorizer.Models
{
    public class UserCollection : DbObjectCollection<User>
    {
        [JsonProperty("users")]
        public override User[] Items { get; set; }
    }

    [XmlRoot("user")]
    public class User : DbObject
    {
        [JsonProperty("loginid")]
        [XmlElement("loginid")]
        public string LoginId { get; set; }
        [JsonProperty("password")]
        [XmlElement("password")]
        public string Password { get; set; }
    }
}
