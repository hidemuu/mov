using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Threading.Tasks;

namespace Mov.WpfMvvms
{
    /// <summary>
    /// ダイアログビューモデル基盤クラス
    /// </summary>
    public abstract class DialogViewModelBase : ViewModelBase, IDialogAware
    {
        #region プロパティ
         
        /// <summary>
         /// タイトル
         /// </summary>
        public abstract string Title { get; }

        public ReactivePropertySlim<string> Message { get; } = new ReactivePropertySlim<string>();

        /// <summary>
        /// ダイアログクローズ可否
        /// </summary>
        /// <returns></returns>
        public virtual bool CanCloseDialog() => true;

        #endregion プロパティ

        #region コマンド

        /// <summary>
        /// クローズリクエストイベント
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        public ReactiveCommand<string> RequestCloseCommand { get; } = new ReactiveCommand<string>();

        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DialogViewModelBase()
        {
            RequestCloseCommand.Subscribe(OnRequestClose);
        }

        #endregion コンストラクター

        #region イベント

        public virtual void OnRequestClose(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
                result = ButtonResult.Yes;
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.No;
            else
                result = ButtonResult.None;
        }

        /// <summary>
        /// ダイアログクローズ時処理 
        /// </summary>
        public virtual void OnDialogClosed() { }

        /// <summary>
        /// ダイアログオープン時処理
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            Message.Value = parameters.GetValue<string>("message");
        }

        #endregion イベント
    }
}