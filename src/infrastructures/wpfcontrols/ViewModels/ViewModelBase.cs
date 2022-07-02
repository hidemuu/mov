using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfControls.ViewModels
{
    /// <summary>
    /// ビューモデル基盤クラス
    /// </summary>
    public abstract class ViewModelBase : BindableBase, IDisposable
    {
        #region フィールド

        /// <summary>
        /// ディスポーズ
        /// </summary>
        protected CompositeDisposable Disposables = new CompositeDisposable();

        private bool _disposed;

        #endregion

        #region プロパティ

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

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                Disposables.Dispose();
            }
            _disposed = true;
        }

        /// <summary>
        /// ロード完了時処理
        /// </summary>
        protected virtual void OnLoaded() { }

        #endregion

    }
}
