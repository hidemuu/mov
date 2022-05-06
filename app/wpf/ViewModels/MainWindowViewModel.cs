using Mov.Wpf.Models;
using Mov.WpfViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading;

namespace Mov.Wpf.ViewModels
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
            Models.Add(new MainWindowModel(0, "Designer", "Home", () => this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, "DesignerView")));
            Models.Add(new MainWindowModel(1, "Config", "Cog", () => this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, "ConfiguratorView")));
            Models.Add(new MainWindowModel(2, "Auth", "Account", () => this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, "AuthorizerView")));
            Models.Add(new MainWindowModel(3, "Scheduler", "calendar", () => this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, "SchedulerView")));
            Models.Add(new MainWindowModel(4, "Translator", "translate", () => this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, "TranslatorView")));
            Models.Add(new MainWindowModel(5, "Game", "blur", () => this.RegionManager.RequestNavigate(RegionConstants.REGION_NAME_CENTER, "GameMainView")));

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