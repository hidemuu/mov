﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mov.Accessors
{
    public class DbObjectNode<T> : DbObject where T : DbObject
    {
        #region プロパティ

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