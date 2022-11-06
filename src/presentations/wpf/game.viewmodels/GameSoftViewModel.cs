using Mov.Drawer.Models;
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
using Mov.Game.Engine;
using Mov.WpfMvvms;

namespace Mov.Game.ViewModels
{
    public class GameSoftViewModel : GraphicViewModelBase
    {
        #region フィールド

        private IActionGame game;

        #endregion フィールド

        #region プロパティ
        public GameSoftModel Model { get; } = new GameSoftModel();
        
        protected override GraphicControllerBase Controller { get; set; }

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

        public GameSoftViewModel(IRegionManager regionManager, IDialogService dialogService, IGameService service) : base(regionManager, dialogService)
        {
            KeyUpCommand.Subscribe(() => OnKeyUp()).AddTo(Disposables);
            KeyGestureEnterCommand.Subscribe(() => OnKeyGestureEnter()).AddTo(Disposables);
            KeyGestureEscapeCommand.Subscribe(() => OnKeyGestureEscape()).AddTo(Disposables);
            KeyGestureUpCommand.Subscribe(() => OnKeyGestureUp()).AddTo(Disposables);
            KeyGestureUpAndShiftCommand.Subscribe(() => OnKeyGestureUpAndShift()).AddTo(Disposables);
            KeyGestureDownCommand.Subscribe(() => OnKeyGestureDown()).AddTo(Disposables);
            KeyGestureLeftCommand.Subscribe(() => OnKeyGestureLeft()).AddTo(Disposables);
            KeyGestureRightCommand.Subscribe(() => OnKeyGestureRight()).AddTo(Disposables);
            this.game = new PackmanGame(service);
            Controller = this.game.GraphicController;
        }

        #endregion コンストラクター

        #region メソッド

        protected override void Update()
        {
            Model.Level.Value = this.game.Engine.Service.Level;
            Model.Life.Value = this.game.GetLife();
            Model.CurrentScore.Value = this.game.Engine.Service.Score;
            Model.ClearScore.Value = this.game.Engine.Service.GetLandmark().ClearScore;
            base.Update();
        }

        protected override void Next()
        {
            //ゲームオーバー時
            if (this.game.Engine.Service.IsGameOver)
            {
                DialogService.ShowDialog(GameViewConstants.DIALOG_NAME_GAME_OVER, new DialogParameters($"message={"ゲームオーバー!"}"), result =>
                {
                    if (result.Result == ButtonResult.Yes)
                    {
                        RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
                        Disposables.Clear();
                        this.game.Wait();
                    }
                    else
                    {
                        RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
                        Disposables.Clear();
                        this.game.Wait();
                    }
                });
                Stop();
            }
            //ステージクリアー時
            if (this.game.Engine.Service.IsStageClear)
            {
                DialogService.ShowDialog(GameViewConstants.DIALOG_NAME_STAGE_CLEAR, new DialogParameters($"message={"ステージクリア!"}"), result =>
                {
                    if (result.Result == ButtonResult.Yes)
                    {
                        this.game.Next();
                    }
                    else
                    {
                        this.game.Next();
                    }
                });
            }

            base.Next();
        }

        #endregion メソッド

        #region イベントハンドラ

        private void OnKeyUp()
        {
            this.game.SetKeyCode(FsmGameEngine.KEY_CODE_NONE);
        }

        private void OnKeyGestureEnter()
        {

        }

        private void OnKeyGestureEscape()
        {

        }

        private void OnKeyGestureUp()
        {
            this.game.SetKeyCode(FsmGameEngine.KEY_CODE_UP);
        }

        private void OnKeyGestureUpAndShift()
        {
            this.game.SetKeyCode(FsmGameEngine.KEY_CODE_UP);
        }

        private void OnKeyGestureDown()
        {
            this.game.SetKeyCode(FsmGameEngine.KEY_CODE_DOWN);
        }

        private void OnKeyGestureLeft()
        {
            this.game.SetKeyCode(FsmGameEngine.KEY_CODE_LEFT);
        }

        private void OnKeyGestureRight()
        {
            this.game.SetKeyCode(FsmGameEngine.KEY_CODE_RIGHT);
        }

        #endregion イベントハンドラ

    }
}
