﻿using Accessors;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Designer.Models
{
    [XmlRoot("tree")]
    public class LayoutTree : Layout
    {
        [XmlArray("children")]
        [XmlArrayItem("tree")]
        public List<LayoutTree> Children { get; set; }
    }
    [XmlRoot("layout")]
    public class Layout : DbObject
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("nodetype")]
        public string NodeType { get; set; }
    }
}
