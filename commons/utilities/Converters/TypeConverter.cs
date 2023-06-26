using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mov.Utilities.Converter
{
    public static class TypeConverter
    {
        #region メソッド

        /// <summary>
        /// 文字列を数値に変換（例外時は-1)
        /// </summary>
        public static int convertStrToInt(string src)
        {
            return int.TryParse(src, out int result) ? result : -1;
        }

        /// <summary>
        /// リストをデータテーブルに変換
        /// </summary>
        public static DataTable ConvertListToDataTable<T>(T list) where T : IList
        {
            var table = new DataTable(typeof(T).GetGenericArguments()[0].Name);
            typeof(T).GetGenericArguments()[0].GetProperties().
                ToList().ForEach(p => table.Columns.Add(p.Name, p.PropertyType));
            foreach (var item in list)
            {
                var row = table.NewRow();
                item.GetType().GetProperties().
                    ToList().ForEach(p => row[p.Name] = p.GetValue(item, null));
                table.Rows.Add(row);
            }
            return table;
        }
        /// <summary>
        /// データテーブルをリストに変換
        /// </summary>
        public static T ConvertDataTableToList<T>(DataTable table) where T : IList, new()
        {
            var list = new T();
            foreach (DataRow row in table.Rows)
            {
                var item = Activator.CreateInstance(typeof(T).GetGenericArguments()[0]);
                list.GetType().GetGenericArguments()[0].GetProperties().ToList().
                    ForEach(p => p.SetValue(item, row[p.Name], null));
                list.Add(item);
            }

            return list;
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>変換メソッド</summary>
        private static T GetT<T>(DataRow dr, List<string> ColumnNames, PropertyInfo[] properties)
        {
            var ResT = Activator.CreateInstance<T>();
            foreach (var pro in properties)
            {
                if (ColumnNames.Contains(pro.Name))
                    pro.SetValue(ResT, dr[pro.Name], null);
            }
            return ResT;
        }

        #endregion 内部メソッド
    }
}
