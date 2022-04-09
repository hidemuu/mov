using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    public class DesignerObject
    {
        [XmlElement("id")]
        public int Id { get; set; }
    }
}
