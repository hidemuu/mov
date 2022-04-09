using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Designer.Models
{
    [XmlRoot("layout")]
    public class ShellLayout : DatabaseObject
    {
        #region プロパティ

        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<ShellLayout> Items { get; set; }

        #endregion

        #region メソッド

        public override string ToString() => GetString(new string[] { Id.ToString(), Code });

        public string ToStrings()
        {
            var stringBuilder = new StringBuilder();
            GetStrings(Items, stringBuilder, 0);
            return stringBuilder.ToString();
        }

        #endregion

        #region 内部メソッド

        private void GetStrings(List<ShellLayout> shellLayouts, StringBuilder stringBuilder, int hierarchy)
        {

            foreach (var shellLayout in shellLayouts)
            {
                for (var i = 0; i < hierarchy; i++)
                {
                    stringBuilder.Append("  ");
                }
                stringBuilder.AppendLine(shellLayout.ToString());
                GetStrings(shellLayout.Items, stringBuilder, hierarchy + 1);
            }
        }

        #endregion
    }
}
