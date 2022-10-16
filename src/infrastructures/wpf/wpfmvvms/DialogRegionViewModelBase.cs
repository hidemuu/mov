using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfMvvms
{
    public abstract class DialogRegionViewModelBase : RegionViewModelBase, IDialogAware
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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DialogRegionViewModelBase(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
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
