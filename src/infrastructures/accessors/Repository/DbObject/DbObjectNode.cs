using Mov.Accessors.Repository.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Accessors
{
    /// <summary>
    /// データベースオブジェクトのノード
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbObjectNode<T> : DbObject, IEntityNode<T> where T : DbObject
    {
        #region プロパティ

        /// <summary>
        /// 子階層
        /// </summary>
        [XmlIgnore]
        public virtual List<T> Children { get; set; } = new List<T>();

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DbObjectNode()
        {

        }

        /// <summary>
        /// コンストラクター（ディープコピー）
        /// </summary>
        /// <param name="src">コピー元データ</param>
        public DbObjectNode(DbObjectNode<T> src) : base(src)
        {
            foreach(var child in Children)
            {
                var srcChild = src.Children.FirstOrDefault(x => x.Id == child.Id);
                if (!(child is DbObjectNode<T> childNode)) continue;
                if (!(srcChild is DbObjectNode<T> srcChildNode)) continue;
                childNode = new DbObjectNode<T>(srcChildNode);
            }
        }

        #endregion コンストラクター 

        #region メソッド

        public string ToNodeString()
        {
            var stringBuilder = new StringBuilder(ToContentString());
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
                stringBuilder.AppendLine(item.ToContentString());
                if (item is DbObjectNode<T> node)
                {
                    GetStringTables(node.Children, stringBuilder, hierarchy + 1);
                }
            }
        }

        #endregion 内部メソッド
    }
}