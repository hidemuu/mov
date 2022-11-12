using Mov.Accessors.Repository;
using Mov.Designer.Models;
using Mov.Designer.Models.Repositories;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mov.UseCase.ViewModels
{
    public class DashboardViewModel : RegionViewModelBase
    {
        #region プロパティ

        public IDesignerService DesignerService { get; }

        public string RepositoryName { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DashboardViewModel(IRegionManager regionManager, IDialogService dialogService, IDesignerService designerService, IDesignerRepositoryCollection designerRepository) : base(regionManager, dialogService)
        {
            DesignerService = designerService;

            RepositoryName = "dashboard";

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
