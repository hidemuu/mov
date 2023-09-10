using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Mov.Core.Accessors.Test.Models
{
    [JsonArray]
    [XmlRoot("tests")]
    public class SerializeSchemaList : List<SerializeSchema>
    {

    }
}
