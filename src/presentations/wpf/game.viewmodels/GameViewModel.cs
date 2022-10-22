using Mov.Game.Models;
using Mov.Game.Service;
using Mov.WpfMvvms;
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
    public class GameViewModel : RegionViewModelBase
    {
        #region �t�B�[���h

        private readonly IActionGame gameService;

        #endregion �t�B�[���h

        #region �v���p�e�B


        #endregion �v���p�e�B

        #region �R�}���h

        public ReactiveCommand ReturnCommand { get; } = new ReactiveCommand();

        #endregion �R�}���h

        #region �R���X�g���N�^�[

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GameViewModel(IRegionManager regionManager, IDialogService dialogService, IActionGame gameService) : base(regionManager, dialogService)
        {
            this.gameService = gameService;

            ReturnCommand.Subscribe(() => OnReturnCommand()).AddTo(Disposables);

            // ����X�V�X���b�h
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
                
            });
            timer.AddTo(Disposables);
            timer.Start();
        }

        #endregion �R���X�g���N�^�[

        #region �C�x���g�n���h��

        protected override void OnLoaded()
        {
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
        }

        private void OnReturnCommand()
        {
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
        }

        #endregion �C�x���g�n���h��

    }
}
