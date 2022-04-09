using Mov.Accessors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("layout")]
    public class PartsLayout : DatabaseObject
    {
        #region プロパティ

        [XmlElement("nodetype")]
        public string NodeType { get; set; }

        [XmlArray("children")]
        [XmlArrayItem("layout")]
        public List<PartsLayout> Children { get; set; }

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        public PartsLayout()
        {

        }

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code, NodeType });
            
        public string ToStrings()
        {
            var stringBuilder = new StringBuilder(ToString());
            stringBuilder.AppendLine();
            GetStrings(Children, stringBuilder, 0);
            return stringBuilder.ToString();
        }

        #endregion


        #region 内部メソッド

        private void GetStrings(List<PartsLayout> partsLayouts, StringBuilder stringBuilder, int hierarchy)
        {
            
            foreach (var partsLayout in partsLayouts)
            {
                for (var i = 0; i <= hierarchy; i++)
                {
                    stringBuilder.Append("  ");
                }
                stringBuilder.AppendLine(partsLayout.ToString());
                GetStrings(partsLayout.Children, stringBuilder, hierarchy + 1);
            }
        }

        #endregion

    }
}
