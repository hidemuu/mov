using Mov.Game.Models;
using Mov.Game.Service;
using Mov.Game.ViewModels.Models;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Mov.Game.ViewModels.ViewModels
{
    public class MainVindowViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        public MainWindowModel Models { get; } = new MainWindowModel();
        public IRegionManager RegionManager { get; }
        private IRegionNavigationJournal journal;
        private readonly IDialogService dialogService;
        private readonly IGameService gameService;

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureDownCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureLeftCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureRightCommand { get; } = new ReactiveCommand();

        private CompositeDisposable disposables = new CompositeDisposable();

        public bool KeepAlive => true;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainVindowViewModel(IRegionManager regionManager, IDialogService dialogService, IGameService gameService) 
        {
            this.RegionManager = regionManager;
            this.dialogService = dialogService;
            this.gameService = gameService;

            LoadedCommand.Subscribe(() => { this.RegionManager.RequestNavigate("MainRegion", "TitleView"); });
            KeyUpCommand.Subscribe(() => KeyUp());
            KeyGestureUpCommand.Subscribe(() => KeyGestureUp());
            KeyGestureDownCommand.Subscribe(() => KeyGestureDown());
            KeyGestureLeftCommand.Subscribe(() => KeyGestureLeft());
            KeyGestureRightCommand.Subscribe(() => KeyGestureRight());

            // 定期更新スレッド
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
                
            });
            timer.AddTo(disposables);
            timer.Start();
        }

        private void KeyUp()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_NONE);
        }

        private void KeyGestureUp()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_UP);
        }

        private void KeyGestureDown()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_DOWN);
        }

        private void KeyGestureLeft()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_LEFT);
        }

        private void KeyGestureRight()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_RIGHT);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //MessageBox.Show("退出完了");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            journal = navigationContext.NavigationService.Journal;

        }


    }
}
