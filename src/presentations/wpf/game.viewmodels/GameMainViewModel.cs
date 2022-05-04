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

namespace Mov.Game.ViewModels
{
    public class GameMainViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        #region フィールド

        private IRegionNavigationJournal journal;
        private readonly IDialogService dialogService;
        private readonly IGameService gameService;
        private CompositeDisposable disposables = new CompositeDisposable();

        #endregion フィールド

        #region プロパティ

        public MainWindowModel Models { get; } = new MainWindowModel();
        public IRegionManager RegionManager { get; }
        public bool KeepAlive => true;

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureEnterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureEscapeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureUpAndShiftCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureDownCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureLeftCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureRightCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameMainViewModel(IRegionManager regionManager, IDialogService dialogService, IGameService gameService) 
        {
            this.RegionManager = regionManager;
            this.dialogService = dialogService;
            this.gameService = gameService;

            LoadedCommand.Subscribe(() => OnLoaded());
            KeyUpCommand.Subscribe(() => OnKeyUp());
            KeyGestureEnterCommand.Subscribe(() => OnKeyGestureEnter());
            KeyGestureEscapeCommand.Subscribe(() => OnKeyGestureEscape());
            KeyGestureUpCommand.Subscribe(() => OnKeyGestureUp());
            KeyGestureUpAndShiftCommand.Subscribe(() => OnKeyGestureUpAndShift());
            KeyGestureDownCommand.Subscribe(() => OnKeyGestureDown());
            KeyGestureLeftCommand.Subscribe(() => OnKeyGestureLeft());
            KeyGestureRightCommand.Subscribe(() => OnKeyGestureRight());

            // 定期更新スレッド
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
                
            });
            timer.AddTo(disposables);
            timer.Start();
        }

        #endregion コンストラクター

        #region イベントハンドラ

        private void OnLoaded()
        {
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
        }

        private void OnKeyUp()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_NONE);
        }

        private void OnKeyGestureEnter()
        {
            
        }

        private void OnKeyGestureEscape()
        {

        }

        private void OnKeyGestureUp()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_UP);
        }

        private void OnKeyGestureUpAndShift()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_UP);
        }

        private void OnKeyGestureDown()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_DOWN);
        }

        private void OnKeyGestureLeft()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_LEFT);
        }

        private void OnKeyGestureRight()
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

        #endregion イベントハンドラ

    }
}
