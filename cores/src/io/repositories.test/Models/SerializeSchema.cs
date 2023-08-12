using CsvHelper.Configuration.Attributes;
using Mov.Core.Repositories.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mov.Core.Repositories.Test.Models
{
    public class SerializeSchema : IDbObject<int>
    {
        public int Id { get; set; } = 0;

        public string Content { get; set; } = string.Empty;
    }
}
