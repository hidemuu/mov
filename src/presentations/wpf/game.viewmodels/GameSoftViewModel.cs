using Mov.Drawer.Models;
using Mov.Drawer.Service;
using Mov.Drawer.ViewModels;
using Mov.Game.Models.Engines;
using Mov.Game.Models;
using Mov.Game.Service;
using Mov.Game.Service.Machine;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Mov.Painters;
using Mov.Accessors.Repository;

namespace Mov.Game.ViewModels
{
    public class GameSoftViewModel : DrawViewModelBase
    {
        #region フィールド

        #endregion フィールド

        #region プロパティ
        public override GameSoftModel Model { get; } = new GameSoftModel();
        
        protected override GraphicControllerBase Service { get; set; }

        #endregion プロパティ

        #region コマンド

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

        public GameSoftViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IDrawerRepository> database, IDomainRepositoryCollection<IGameRepository> gameDatabase, IMachineGameService gameService) : base(regionManager, dialogService, database)
        {
            KeyUpCommand.Subscribe(() => OnKeyUp()).AddTo(Disposables);
            KeyGestureEnterCommand.Subscribe(() => OnKeyGestureEnter()).AddTo(Disposables);
            KeyGestureEscapeCommand.Subscribe(() => OnKeyGestureEscape()).AddTo(Disposables);
            KeyGestureUpCommand.Subscribe(() => OnKeyGestureUp()).AddTo(Disposables);
            KeyGestureUpAndShiftCommand.Subscribe(() => OnKeyGestureUpAndShift()).AddTo(Disposables);
            KeyGestureDownCommand.Subscribe(() => OnKeyGestureDown()).AddTo(Disposables);
            KeyGestureLeftCommand.Subscribe(() => OnKeyGestureLeft()).AddTo(Disposables);
            KeyGestureRightCommand.Subscribe(() => OnKeyGestureRight()).AddTo(Disposables);
            Service = new PackmanGameService(gameDatabase);
        }

        #endregion コンストラクター

        #region メソッド

        protected override void Update()
        {
            if(Service is PackmanGameService packmanGameService)
            {
                Model.Level.Value = packmanGameService.Level;
                Model.Life.Value = packmanGameService.GetLife();
                Model.CurrentScore.Value = packmanGameService.Score;
                Model.ClearScore.Value = packmanGameService.GetLandmark().ClearScore;
            }
            base.Update();
        }

        protected override void Next()
        {
            if (Service is PackmanGameService packmanGameService)
            {
                //ゲームオーバー時
                if (packmanGameService.IsGameOver)
                {
                    DialogService.ShowDialog(GameViewConstants.DIALOG_NAME_GAME_OVER, new DialogParameters($"message={"ゲームオーバー!"}"), result =>
                    {
                        if (result.Result == ButtonResult.Yes)
                        {
                            RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
                            Disposables.Clear();
                            packmanGameService.Wait();
                        }
                        else
                        {
                            RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
                            Disposables.Clear();
                            packmanGameService.Wait();
                        }
                    });
                    Stop();
                }
                //ステージクリアー時
                if (packmanGameService.IsStageClear)
                {
                    DialogService.ShowDialog(GameViewConstants.DIALOG_NAME_STAGE_CLEAR, new DialogParameters($"message={"ステージクリア!"}"), result =>
                    {
                        if (result.Result == ButtonResult.Yes)
                        {
                            packmanGameService.Next();
                        }
                        else
                        {
                            packmanGameService.Next();
                        }
                    });
                }
            }
                
            base.Next();
        }

        #endregion メソッド

        #region イベントハンドラ

        private void OnKeyUp()
        {
            if (Service is PackmanGameService packmanGameService)
            {
                packmanGameService.SetKeyCode(FsmGameEngine.KEY_CODE_NONE);
            }
        }

        private void OnKeyGestureEnter()
        {

        }

        private void OnKeyGestureEscape()
        {

        }

        private void OnKeyGestureUp()
        {
            if (Service is PackmanGameService packmanGameService)
            {
                packmanGameService.SetKeyCode(FsmGameEngine.KEY_CODE_UP);
            }
        }

        private void OnKeyGestureUpAndShift()
        {
            if (Service is PackmanGameService packmanGameService)
            {
                packmanGameService.SetKeyCode(FsmGameEngine.KEY_CODE_UP);
            }
        }

        private void OnKeyGestureDown()
        {
            if (Service is PackmanGameService packmanGameService)
            {
                packmanGameService.SetKeyCode(FsmGameEngine.KEY_CODE_DOWN);
            }
        }

        private void OnKeyGestureLeft()
        {
            if (Service is PackmanGameService packmanGameService)
            {
                packmanGameService.SetKeyCode(FsmGameEngine.KEY_CODE_LEFT);
            }
        }

        private void OnKeyGestureRight()
        {
            if (Service is PackmanGameService packmanGameService)
            {
                packmanGameService.SetKeyCode(FsmGameEngine.KEY_CODE_RIGHT);
            }
        }

        #endregion イベントハンドラ

    }
}
