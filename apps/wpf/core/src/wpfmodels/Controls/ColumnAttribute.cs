using Reactive.Bindings;

namespace Mov.WpfModels.Controls
{
    /// <summary>
    /// 列のアトリビュート
    /// </summary>
    public class ColumnAttribute
    {
        #region プロパティ

        /// <summary>
        /// ヘッダー
        /// </summary>
        public ReactivePropertySlim<string> Header { get; set; } = new ReactivePropertySlim<string>(string.Empty);
        /// <summary>
        /// 幅
        /// </summary>
        public ReactivePropertySlim<int> Width { get; set; } = new ReactivePropertySlim<int>(100);
        /// <summary>
        /// 表示・非表示
        /// </summary>
        public ReactivePropertySlim<bool> IsVisible { get; } = new ReactivePropertySlim<bool>(true);

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="header"></param>
        /// <param name="width"></param>
        public ColumnAttribute(string header, int width = 100)
        {
            Header.Value = header;
            Width.Value = width;
        }

        #endregion コンストラクター
    }
}
