using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.ViewModels.Dialogs
{
    public class GameOverDialogViewModel : BindableBase, IDialogAware
    {
        #region プロパティ

        private string _title = "Notification";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        #endregion プロパティ

        #region コマンド

        public event Action<IDialogResult> RequestClose;

        public ReactiveCommand LoadedDialogCommand { get; } = new ReactiveCommand();

        public ReactiveCommand<string> CloseDialogCommand { get; } = new ReactiveCommand<string>();

        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameOverDialogViewModel()
        {
            LoadedDialogCommand.Subscribe(OnLoadedDialogCommand);
            CloseDialogCommand.Subscribe(OnCloseDialogCommand);
        }

        #endregion コンストラクター

        #region イベントハンドラ

        void OnLoadedDialogCommand()
        {

        }

        void OnCloseDialogCommand(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
                result = ButtonResult.Yes;
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.No;

            RaiseRequestClose(new DialogResult(result));
        }

        public void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }

        #endregion イベントハンドラ
    }
}
