using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Mov.Accessors
{
    public abstract class DbObjectCollection<T> where T : DbObject
    {
        [XmlIgnore]
        public abstract T[] Items { get; set; }

        #region メソッド

        public string ToStrings()
        {
            var stringBuilder = new StringBuilder();
            GetStrings(Items, stringBuilder, 0);
            return stringBuilder.ToString();
        }

        #endregion

        #region 内部メソッド

        private void GetStrings(IEnumerable<T> items, StringBuilder stringBuilder, int hierarchy)
        {

            foreach (var item in items)
            {
                for (var i = 0; i < hierarchy; i++)
                {
                    stringBuilder.Append("  ");
                }
                stringBuilder.AppendLine(item.ToString());
            }
        }

        #endregion
    }
}
