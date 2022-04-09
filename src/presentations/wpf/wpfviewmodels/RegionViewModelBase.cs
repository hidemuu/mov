using Prism.Regions;
using Prism.Services.Dialogs;

namespace Mov.WpfViewModels
{
    /// <summary>
    /// リージョンビューモデル基盤クラス
    /// </summary>
    public abstract class RegionViewModelBase : ViewModelBase, INavigationAware, IRegionMemberLifetime
    {
        #region プロパティ

        /// <summary>
        /// ダイアログサービス
        /// </summary>
        protected readonly IDialogService DialogService;

        /// <summary>
        /// リージョンマネージャー
        /// </summary>
        public IRegionManager RegionManager { get; }

        /// <summary>
        /// ナビゲーションジャーナル
        /// </summary>
        protected IRegionNavigationJournal Journal { get; private set; }

        /// <summary>
        /// キープアライブ
        /// </summary>
        public virtual bool KeepAlive => true;

        #endregion プロパティ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        public RegionViewModelBase(IRegionManager regionManager, IDialogService dialogService) : base()
        {
            this.RegionManager = regionManager;
            DialogService = dialogService;
        }

        #region ナビゲーションメソッド

        /// <summary>
        /// このメソッドの返す値により、画面のインスタンスを使いまわすかどうか制御できる。
        /// true ：インスタンスを使いまわす(画面遷移してもコンストラクタ呼ばれない)
        /// false：インスタンスを使いまわさない(画面遷移するとコンストラクタ呼ばれる)
        /// メソッド実装なし：trueになる
        /// ※コンストラクタは呼ばれないが、Loadedイベントは起きる
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;

        /// <summary>
        /// この画面から他の画面に遷移する時の処理
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// 他の画面からこの画面に遷移してきた時の処理
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            Journal = navigationContext.NavigationService.Journal;
        }

        #endregion ナビゲーションメソッド
    }
}