using Mov.Core;
using Mov.Core.Graphicers;
using Mov.Game.Engine;
using Mov.Game.Models;
using Mov.WpfMvvms.Renders;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace Mov.Game.ViewModels
{
    public class GameSoftViewModel : GraphicViewModelBase
    {
        #region フィールド

        private readonly IGameFacade service;

        private IGraphicGame game;

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

        public GameSoftViewModel(IRegionManager regionManager, IDialogService dialogService, IGameFacade service) : base(regionManager, dialogService)
        {
            KeyUpCommand.Subscribe(() => OnKeyUp()).AddTo(Disposables);
            KeyGestureEnterCommand.Subscribe(() => OnKeyGestureEnter()).AddTo(Disposables);
            KeyGestureEscapeCommand.Subscribe(() => OnKeyGestureEscape()).AddTo(Disposables);
            KeyGestureUpCommand.Subscribe(() => OnKeyGestureUp()).AddTo(Disposables);
            KeyGestureUpAndShiftCommand.Subscribe(() => OnKeyGestureUpAndShift()).AddTo(Disposables);
            KeyGestureDownCommand.Subscribe(() => OnKeyGestureDown()).AddTo(Disposables);
            KeyGestureLeftCommand.Subscribe(() => OnKeyGestureLeft()).AddTo(Disposables);
            KeyGestureRightCommand.Subscribe(() => OnKeyGestureRight()).AddTo(Disposables);
            this.service = service;
            this.game = service.CreateGraphicGame();
            Controller = (GraphicControllerBase)this.game.GraphicController;
        }

        #endregion コンストラクター

        #region メソッド

        protected override void Update()
        {
            Model.Level.Value = this.game.Level;
            Model.Life.Value = this.service.GetPlayerLife();
            Model.CurrentScore.Value = this.game.Score;
            Model.ClearScore.Value = this.service.GetLandmark().ClearScore;
            base.Update();
        }

        protected override void Next()
        {
            //ゲームオーバー時
            if (this.game.IsGameOver)
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
            if (this.game.IsStageClear)
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
            this.game.SetKeyCode(CoreConstants.KEY_CODE_NONE);
        }

        private void OnKeyGestureEnter()
        {
        }

        private void OnKeyGestureEscape()
        {
        }

        private void OnKeyGestureUp()
        {
            this.game.SetKeyCode(CoreConstants.KEY_CODE_UP);
        }

        private void OnKeyGestureUpAndShift()
        {
            this.game.SetKeyCode(CoreConstants.KEY_CODE_UP);
        }

        private void OnKeyGestureDown()
        {
            this.game.SetKeyCode(CoreConstants.KEY_CODE_DOWN);
        }

        private void OnKeyGestureLeft()
        {
            this.game.SetKeyCode(CoreConstants.KEY_CODE_LEFT);
        }

        private void OnKeyGestureRight()
        {
            this.game.SetKeyCode(CoreConstants.KEY_CODE_RIGHT);
        }

        #endregion イベントハンドラ
    }
}