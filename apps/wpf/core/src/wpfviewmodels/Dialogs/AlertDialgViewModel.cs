using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;

namespace Mov.WpfViewModels.Dialogs
{
    public class AlertDialogViewModel
    {

        #region フィールド

        public string Title => "Notification";

        public ReactivePropertySlim<string> Message { get; } = new ReactivePropertySlim<string>();

        public string ImagePath { get; }

        #endregion

        #region コマンド

        public ReactiveCommand<string> RequestCloseCommand { get; } = new ReactiveCommand<string>();

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AlertDialogViewModel()
        {
            RequestCloseCommand.Subscribe(OnRequestClose);
        }

        void OnRequestClose(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
                result = ButtonResult.Yes;
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.No;
            else
                result = ButtonResult.None;
            //RequestCloseInvoke(new DialogResult(result));

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message.Value = parameters.GetValue<string>("message");
        }

    }
}
