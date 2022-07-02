using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Threading.Tasks;

namespace Mov.WpfControls.ViewModels
{
    /// <summary>
    /// ダイアログビューモデル基盤クラス
    /// </summary>
    public abstract class DialogViewModelBase : ViewModelBase, IDialogAware
    {
        #region フィールド
         
        /// <summary>
         /// タイトル
         /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// ダイアログクローズ可否
        /// </summary>
        /// <returns></returns>
        public virtual bool CanCloseDialog() => true;

        /// <summary>
        /// クローズリクエストイベント
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        #endregion フィールド

        #region コマンド
        
        #endregion 

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DialogViewModelBase()
        {

        }

        #region メソッド

        public void RequestCloseInvoke(IDialogResult dialogResult)
        {
            this.RequestClose?.Invoke(dialogResult);
        }

        /// <summary>
        /// ダイアログクローズ時処理 
        /// </summary>
        public virtual void OnDialogClosed() { }

        /// <summary>
        /// ダイアログオープン時処理
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnDialogOpened(IDialogParameters parameters) { }

        #endregion
    }
}