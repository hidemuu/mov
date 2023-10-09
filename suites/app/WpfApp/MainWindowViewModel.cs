using Mov.Suite.WpfApp.Pages.Views;
using Mov.Suite.WpfApp.Shared;
using Mov.Suite.WpfApp.Shared.Models;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading;

namespace Mov.Suite.WpfApp
{
    public class MainWindowViewModel : RegionViewModelBase
    {
        #region property

        public ReactivePropertySlim<string> Title { get; private set; } = new ReactivePropertySlim<string>();
        public ReactiveCollection<TabItemModel> TabItems { get; } = new ReactiveCollection<TabItemModel>();
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);

        #endregion property

        #region command

        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();

        #endregion command

        #region constructor

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
            : base(regionManager, dialogService)
        {
            TabItems.Add(new TabItemModel(0, "Dashboard", "DNS", () =>
                this.RegionManager.RequestNavigate("CENTER", nameof(DashboardView))));
            TabItems.Add(new TabItemModel(1, "Game", "blur", () =>
                this.RegionManager.RequestNavigate("CENTER", nameof(GameView))));
            TabItems.Add(new TabItemModel(2, "Chart", "ChartLine", () =>
                this.RegionManager.RequestNavigate("CENTER", nameof(ChartView))));
            TabItems.Add(new TabItemModel(3, "Web", "Home", () =>
                this.RegionManager.RequestNavigate("CENTER", nameof(WebView))));

            TabChangeCommand.Subscribe(_ => OnChangeTab()).AddTo(Disposables);

            // 定期更新スレッド
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
            });
            timer.AddTo(Disposables);
            timer.Start();
        }

        #endregion constructor

        #region event

        protected override void OnLoaded()
        {
            ChangeContent(0);
        }

        private void OnChangeTab()
        {
            ChangeContent(TabPage.Value);
        }

        #endregion event

        #region method

        #endregion method

        #region inner method

        private void ChangeContent(int index)
        {
            var tabItem = TabItems.FirstOrDefault(x => x.Index == index);
            tabItem?.TabCommand();
            Title.Value = "Mov.Suite" + " - " + tabItem?.Title ?? "Nothing";
        }

        #endregion inner method
    }
}
