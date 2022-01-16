using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfViewModels
{
    /// <summary>
    /// コンテンツビューモデル基盤クラス
    /// </summary>
    public abstract class ContentViewModelBase : ViewModelBase
    {
        #region フィールド

        /// <summary>
        /// ダイアログサービス
        /// </summary>
        protected readonly IDialogService DialogService;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dialogService"></param>
        public ContentViewModelBase(IDialogService dialogService)
        {
            this.DialogService = dialogService;
        }

    }
}
