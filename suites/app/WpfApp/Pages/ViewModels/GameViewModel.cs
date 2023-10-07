using Mov.Core.Graphicers.Services.Controllers;
using Mov.Core.Models;
using Mov.Game.Models;
using Mov.Game.Service;
using Mov.Suite.WpfApp.Shared;
using Mov.Suite.WpfApp.Shared.Models;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace Mov.Suite.WpfApp.Pages.ViewModels
{
    public class GameViewModel : GraphicViewModelBase
    {
        #region field

        private readonly IGameFacade facade;

        private IGraphicGame game;

        #endregion field

        #region property

        public GameStatusModel Status { get; }

        protected override IGraphicController Controller { get; }

        #endregion property

        #region command

        public ReactiveCommand KeyUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureEnterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureEscapeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureUpAndShiftCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureDownCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureLeftCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyGestureRightCommand { get; } = new ReactiveCommand();

        #endregion command

        #region constructor

        public GameViewModel(IRegionManager regionManager, IDialogService dialogService, IGameFacade facade) : base(regionManager, dialogService)
        {
            KeyUpCommand.Subscribe(() => OnKeyUp()).AddTo(Disposables);
            KeyGestureEnterCommand.Subscribe(() => OnKeyGestureEnter()).AddTo(Disposables);
            KeyGestureEscapeCommand.Subscribe(() => OnKeyGestureEscape()).AddTo(Disposables);
            KeyGestureUpCommand.Subscribe(() => OnKeyGestureUp()).AddTo(Disposables);
            KeyGestureUpAndShiftCommand.Subscribe(() => OnKeyGestureUpAndShift()).AddTo(Disposables);
            KeyGestureDownCommand.Subscribe(() => OnKeyGestureDown()).AddTo(Disposables);
            KeyGestureLeftCommand.Subscribe(() => OnKeyGestureLeft()).AddTo(Disposables);
            KeyGestureRightCommand.Subscribe(() => OnKeyGestureRight()).AddTo(Disposables);
            this.facade = facade;
            this.game = facade.CreateGraphicGame();
            Controller = this.game.GraphicController;
        }

        #endregion constructor

        #region event

        private void OnKeyUp()
        {
            this.game.SetKeyCode(KeyboardCode.None.Value);
        }

        private void OnKeyGestureEnter()
        {
        }

        private void OnKeyGestureEscape()
        {
        }

        private void OnKeyGestureUp()
        {
            this.game.SetKeyCode(KeyboardCode.Up.Value);
        }

        private void OnKeyGestureUpAndShift()
        {
            this.game.SetKeyCode(KeyboardCode.Up.Value);
        }

        private void OnKeyGestureDown()
        {
            this.game.SetKeyCode(KeyboardCode.Down.Value);
        }

        private void OnKeyGestureLeft()
        {
            this.game.SetKeyCode(KeyboardCode.Left.Value);
        }

        private void OnKeyGestureRight()
        {
            this.game.SetKeyCode(KeyboardCode.Right.Value);
        }

        #endregion event

        #region inner method

        protected override void Update()
        {
            Status.Level.Value = this.game.Level;
            Status.Life.Value = this.facade.GetPlayerLife();
            Status.CurrentScore.Value = this.game.Score;
            Status.ClearScore.Value = this.facade.GetLandmark().ClearScore;
            base.Update();
        }

        protected override void Next()
        {
            //ゲームオーバー時
            if (this.game.IsGameOver)
            {
                DialogService.ShowDialog("GAME_OVER", new DialogParameters($"message={"ゲームオーバー!"}"), result =>
                {
                    if (result.Result == ButtonResult.Yes)
                    {
                        RegionManager.RequestNavigate("MAIN", "TITLE");
                        Disposables.Clear();
                        this.game.Wait();
                    }
                    else
                    {
                        RegionManager.RequestNavigate("MAIN", "TITLE");
                        Disposables.Clear();
                        this.game.Wait();
                    }
                });
                Stop();
            }
            //ステージクリアー時
            if (this.game.IsStageClear)
            {
                DialogService.ShowDialog("STAGE_CLEAR", new DialogParameters($"message={"ステージクリア!"}"), result =>
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

        #endregion inner method
    }
}
