using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Accessors
{
    public abstract class DbObjectNode<T> : DbObject where T : DbObject
    {
        #region プロパティ

        [XmlIgnore]
        public abstract List<T> Children { get; set; }

        #endregion プロパティ

        #region コンストラクター

        public DbObjectNode()
        {
        }

        #endregion コンストラクター

        #region メソッド

        public string ToStringTables()
        {
            var stringBuilder = new StringBuilder(ToStringTable());
            stringBuilder.AppendLine();
            GetStringTables(Children, stringBuilder, 0);
            return stringBuilder.ToString();
        }

        #endregion メソッド

        #region 内部メソッド

        private void GetStringTables(List<T> items, StringBuilder stringBuilder, int hierarchy)
        {
            foreach (var item in items)
            {
                for (var i = 0; i <= hierarchy; i++)
                {
                    stringBuilder.Append("  ");
                }
                stringBuilder.AppendLine(item.ToStringTable());
                if (item is DbObjectNode<T> node)
                {
                    GetStringTables(node.Children, stringBuilder, hierarchy + 1);
                }
            }
        }

        #endregion 内部メソッド
    }
}