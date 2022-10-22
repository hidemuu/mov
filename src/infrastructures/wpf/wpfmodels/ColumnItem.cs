using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Mov.WpfModels
{
    /// <summary>
    /// 列のアイテム
    /// </summary>
    public class ColumnItem
    {
        #region プロパティ

        /// <summary>
        /// パス
        /// </summary>
        public ReactivePropertySlim<string> Path { get; set; } = new ReactivePropertySlim<string>(string.Empty);
        /// <summary>
        /// 設定値
        /// </summary>
        public ReactivePropertySlim<object> Value { get; set; } = new ReactivePropertySlim<object>();
        /// <summary>
        /// データ型
        /// </summary>
        public Type Type { get; set; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ColumnItem(string path, object value)
        {
            Path.Value = path;
            Value.Value = value;
            Type = value?.GetType();
        }

        #endregion コンストラクター

        #region メソッド

        public object GetValue()
        {
            if (Type == typeof(Guid))
            {
                return Guid.Parse(Value.Value.ToString());
            }
            return Value?.Value != null ? Convert.ChangeType(Value.Value, Type) : null;
        }

        public void SetValue(object value)
        {
            if(Type == typeof(Guid))
            {
                Value.Value = Guid.Parse(value.ToString());
                return;
            }
            if(Type.BaseType == typeof(Enum))
            {
                Value.Value = Enum.Parse(Type, value.ToString());
                return;
            }
            Value.Value = Convert.ChangeType(value, Type);
        }

        public override string ToString()
        {
            return Value?.Value?.ToString();
        }

        #endregion メソッド

    }
}
