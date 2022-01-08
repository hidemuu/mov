using Mov.Accessors;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Authorizer.Models
{
    [XmlRoot("root")]
    public class UserTable : ITable<User>
    {
        [XmlArray("users")]
        [XmlArrayItem("user")]
        public List<User> Items { get; set; }
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
