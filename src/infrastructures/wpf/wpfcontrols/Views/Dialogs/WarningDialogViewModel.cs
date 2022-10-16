using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfControls.ViewModels.Dialogs
{
    public class WarningDialogViewModel
    {
        #region フィールド

        public string Title => "Notification";

        public ReactivePropertySlim<string> Message { get; } = new ReactivePropertySlim<string>();

        public string ImagePath { get; }

        #endregion

        #region コマンド



        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WarningDialogViewModel()
        {

        }

        #region メソッド

        protected async void OnLoaded()
        {
            await Task.Delay(2000);
            //RequestCloseInvoke(new DialogResult(ButtonResult.No));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message.Value = parameters.GetValue<string>("message");
        }

        #endregion

    }
}
