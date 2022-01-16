using Mov.WpfViewModels;
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

namespace Mov.Wpf.ViewModels
{
    public class MainWindowViewModel : RegionViewModelBase
    {
        #region フィールド

        public ReactiveCollection<MainWindowModel> Models { get; } = new ReactiveCollection<MainWindowModel>();
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);

        #endregion

        #region コマンド

        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
            Models.Add(new MainWindowModel(0, "Config", "Cog", () => this.RegionManager.RequestNavigate("CENTER", "ConfiguratorView")));
            Models.Add(new MainWindowModel(1, "Auth", "Home", () => this.RegionManager.RequestNavigate("CENTER", "AuthorizerView")));
            
            TabChangeCommand.Subscribe(_ => OnChangeTab()).AddTo(Disposables);

            // 定期更新スレッド
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
            });
            timer.AddTo(Disposables);
            timer.Start();
        }

        #region メソッド

        protected override void OnLoaded()
        {
            //this.RegionManager.RequestNavigate("MENUBAR", "MenuView");
            //this.RegionManager.RequestNavigate("TOOLBAR", "ToolView");
            //this.RegionManager.RequestNavigate("RIGHT", "LayoutView");
            //this.RegionManager.RequestNavigate("LEFT", "TreeTableView");
            this.RegionManager.RequestNavigate("CENTER", "ConfiguratorView");
            //this.RegionManager.RequestNavigate("FOOTER", "GuideView");
        }

        private void OnChangeTab()
        {
            Models.FirstOrDefault(x => x.Index == TabPage.Value).TabCommand();
        }

        #endregion

        public class MainWindowModel
        {
            public int Index { get; }
            public Action TabCommand { get; }

            public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> IconKey { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<bool> IsSelected { get; } = new ReactivePropertySlim<bool>();


            public MainWindowModel(int index, string title, string iconkey, Action tabcommand)
            {
                Index = index;
                TabCommand = tabcommand;
                Title.Value = title;
                IconKey.Value = iconkey;
            }
        }

    }
}
