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
        #region �t�B�[���h

        private IRegionNavigationJournal journal;
        private readonly IDialogService dialogService;
        private readonly IGameService gameService;
        private CompositeDisposable disposables = new CompositeDisposable();

        #endregion �t�B�[���h

        #region �v���p�e�B

        public MainWindowModel Models { get; } = new MainWindowModel();
        public IRegionManager RegionManager { get; }
        public bool KeepAlive => true;

        #endregion �v���p�e�B

        #region �R�}���h

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureEnterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureEscapeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureUpAndShiftCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureDownCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureLeftCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureRightCommand { get; } = new ReactiveCommand();

        #endregion �R�}���h

        #region �R���X�g���N�^�[

        /// <summary>
        /// �R���X�g���N�^
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

            // ����X�V�X���b�h
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
                
            });
            timer.AddTo(disposables);
            timer.Start();
        }

        #endregion �R���X�g���N�^�[

        #region �C�x���g�n���h��

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
            //MessageBox.Show("�ޏo����");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            journal = navigationContext.NavigationService.Journal;

        }

        #endregion �C�x���g�n���h��

    }
}
