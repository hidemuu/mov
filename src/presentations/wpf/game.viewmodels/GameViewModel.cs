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
        #region フィールド

        private readonly IActionGame gameService;

        #endregion フィールド

        #region プロパティ


        #endregion プロパティ

        #region コマンド

        public ReactiveCommand ReturnCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameViewModel(IRegionManager regionManager, IDialogService dialogService, IActionGame gameService) : base(regionManager, dialogService)
        {
            this.gameService = gameService;

            ReturnCommand.Subscribe(() => OnReturnCommand()).AddTo(Disposables);

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
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
        }

        private void OnReturnCommand()
        {
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
        }

        #endregion イベントハンドラ

    }
}
