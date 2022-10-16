using Mov.Bom.Views;
using Mov.Configurator.Views;
using Mov.Designer.Views;
using Mov.Drawer.Views;
using Mov.Driver.Views;
using Mov.Game.Views;
using Mov.Scheduler.Views;
using Mov.WpfApp;
using Mov.WpfControls.ViewModels;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading;

namespace Mov.WpfApp
{
    public class MainWindowViewModel : RegionViewModelBase
    {
        #region プロパティ

        public ReactivePropertySlim<string> Title { get; private set; } = new ReactivePropertySlim<string>();
        public ReactiveCollection<MainWindowModel> Models { get; } = new ReactiveCollection<MainWindowModel>();
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
            Models.Add(new MainWindowModel(0, "Config", "Cog", () =>
                this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, nameof(ConfiguratorView))));
            Models.Add(new MainWindowModel(1, "Designer", "Collage", () => 
                this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, nameof(DesignerView))));
            Models.Add(new MainWindowModel(2, "Game", "blur", () => 
                this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, nameof(GameView))));
            Models.Add(new MainWindowModel(3, "Draw", "Sprout", () =>
                this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, nameof(DrawerView))));
            Models.Add(new MainWindowModel(4, "Driver", "Octahedron", () =>
                this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, nameof(DriverView))));
            Models.Add(new MainWindowModel(5, "Bom", "DNS", () =>
                this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, nameof(BomView))));
            Models.Add(new MainWindowModel(6, "Scheduler", "calendar", () => 
                this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, nameof(SchedulerView))));

            TabChangeCommand.Subscribe(_ => OnChangeTab()).AddTo(Disposables);

            // 定期更新スレッド
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
            });
            timer.AddTo(Disposables);
            timer.Start();
        }

        #region イベント

        protected override void OnLoaded()
        {
            ChangeContent(0);
            //this.RegionManager.RequestNavigate(REGION_NAME_MENUBAR, "MenuView");
            //this.RegionManager.RequestNavigate(REGION_NAME_HEADER, "ToolView");
            //this.RegionManager.RequestNavigate(REGION_NAME_RIGHT, "LayoutView");
            //this.RegionManager.RequestNavigate(REGION_NAME_LEFT, "TreeTableView");
            //this.RegionManager.RequestNavigate(REGION_NAME_FOOTER, "GuideView");
        }

        private void OnChangeTab()
        {
            ChangeContent(TabPage.Value);
        }

        #endregion イベント

        #region メソッド

        private void ChangeContent(int index)
        {
            var model = Models.FirstOrDefault(x => x.Index == index);
            model.TabCommand();
            Title.Value = "Mov" + " - " + model.Title;
        }

        #endregion

    }
}