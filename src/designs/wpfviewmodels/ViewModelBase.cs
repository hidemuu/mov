using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfViewModels
{
    /// <summary>
    /// ビューモデル基盤クラス
    /// </summary>
    public abstract class ViewModelBase : BindableBase
    {
        #region フィールド

        /// <summary>
        /// ディスポーズ
        /// </summary>
        protected CompositeDisposable Disposables = new CompositeDisposable();

        #endregion

        #region コマンド

        /// <summary>
        /// ロード完了時コマンド
        /// </summary>
        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ViewModelBase()
        {
            LoadedCommand.Subscribe(() => OnLoaded()).AddTo(Disposables);
        }

        #region メソッド

        /// <summary>
        /// ロード完了時処理
        /// </summary>
        protected virtual void OnLoaded() { }

        #endregion

    }
}
