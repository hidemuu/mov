using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Core.Models.DbObjects
{
    public interface IDbObjectCollection<T>
    {
        [XmlIgnore]
        T[] Items { get; set; }
    }
}
