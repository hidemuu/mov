using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Core.Repositories.Schemas
{
    /// <summary>
    /// データベースオブジェクトのノード
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbTableNodeSchema<T> : DbTableSchema, IDbNodeSchema<T, Guid> where T : DbTableSchema
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
        public DbTableNodeSchema()
        {

        }

        /// <summary>
        /// コンストラクター（ディープコピー）
        /// </summary>
        /// <param name="src">コピー元データ</param>
        public DbTableNodeSchema(DbTableNodeSchema<T> src) : base(src)
        {
            foreach (var child in Children)
            {
                var srcChild = src.Children.FirstOrDefault(x => x.Id == child.Id);
                if (!(child is DbTableNodeSchema<T> childNode)) continue;
                if (!(srcChild is DbTableNodeSchema<T> srcChildNode)) continue;
                childNode = new DbTableNodeSchema<T>(srcChildNode);
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
                if (item is DbTableNodeSchema<T> node)
                {
                    GetStringTables(node.Children, stringBuilder, hierarchy + 1);
                }
            }
        }

        #endregion 内部メソッド
    }
}