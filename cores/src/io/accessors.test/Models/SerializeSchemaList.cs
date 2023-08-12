using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mov.Core.Accessors.Test.Models
{
    [JsonArray]
    [XmlRoot("tests")]
    public class SerializeSchemaList : List<SerializeSchema>
    {

    }
}
