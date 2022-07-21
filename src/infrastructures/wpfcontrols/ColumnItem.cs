using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.WpfControls
{
    /// <summary>
    /// 列のアイテム
    /// </summary>
    public class ColumnItem
    {
        /// <summary>
        /// パス
        /// </summary>
        public ReactivePropertySlim<string> Path { get; set; } = new ReactivePropertySlim<string>(string.Empty);
        /// <summary>
        /// 設定値
        /// </summary>
        public ReactivePropertySlim<string> Value { get; set; } = new ReactivePropertySlim<string>(string.Empty);
        /// <summary>
        /// データ型
        /// </summary>
        public ReactivePropertySlim<string> Type { get; set; } = new ReactivePropertySlim<string>(string.Empty);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ColumnItem(string path, object value)
        {
            Path.Value = path;
            Value.Value = value.ToString();
            Type.Value = value.GetType().Name;
        }

    }
}
