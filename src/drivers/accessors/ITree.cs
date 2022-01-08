using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Accessors
{
    [XmlRoot("tree")]
    public interface ITree<T>
    {
        [XmlElement("parent")]
        T Parent { get; set; }
        [XmlArray("children")]
        [XmlArrayItem("tree")]
        List<ITree<T>> Children { get; set; }
    }
}
