using Mov.Designer.Models;
using Mov.Layouts;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Concurrency;
using System.Threading;

namespace Mov.UseCase.ViewModels
{
    public class DashboardViewModel : RegionViewModelBase
    {
        #region プロパティ

        public IDesignerFacade DesignerService { get; }

        public ILayoutFacade LayoutFacade => DesignerService.LayoutFacade;

        public ReactivePropertySlim<bool> IsUpdate { get; private set; } = new ReactivePropertySlim<bool>(false);

        public string RepositoryName { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DashboardViewModel(IRegionManager regionManager, IDialogService dialogService, IDesignerFacade designerService, IDesignerRepositoryCollection designerRepository) : base(regionManager, dialogService)
        {
            DesignerService = designerService;

            RepositoryName = "dashboard";
            IsUpdate.Value = true;

            // 定期更新スレッド
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
            });
            timer.AddTo(Disposables);
            timer.Start();
        }

        #endregion コンストラクター

        #region イベントハンドラ

        protected override void OnLoaded()
        {
            //this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
        }

        #endregion イベントハンドラ
    }
}