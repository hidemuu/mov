using Mov.Game.Service;
using Mov.Game.ViewModels.Models;
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

namespace Mov.Game.ViewModels
{
    public class GameViewModel : BindableBase
    {
        #region フィールド

        private readonly IDialogService dialogService;

        private readonly IGameService gameService;
        private Bitmap bitmap;
        private Graphics graphics;
        private CompositeDisposable disposables = new CompositeDisposable();
        private bool isLoaded = false;

        #endregion フィールド

        #region プロパティ
        public GameModel Model { get; } = new GameModel();
        private IRegionManager RegionManager { get; }
        public ReactiveTimer Timer { get; } = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        #region コンストラクター

        public GameViewModel(IRegionManager regionManager, IDialogService dialogService, IGameService gameService)
        {
            this.RegionManager = regionManager;
            this.dialogService = dialogService;
            this.gameService = gameService;

            this.bitmap = new Bitmap(600, 600);
            this.graphics = Graphics.FromImage(bitmap);

            LoadedCommand.Subscribe(() => OnLoadedCommand());
            
            // 定期更新スレッド
            Timer.Subscribe(_ => OnTimer());
            Timer.AddTo(disposables);
            Timer.Start();
        }

        #endregion コンストラクター

        #region イベントハンドラ

        private void OnLoadedCommand()
        {
            isLoaded = true;
            gameService.Initialize();
            gameService.Run();
        }

        private void OnTimer()
        {
            if (isLoaded)
            {
                gameService.Draw(graphics);
                var hbitmap = bitmap.GetHbitmap();
                //モデル生成
                Model.ImageSource.Value = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                Model.Level.Value = gameService.Level;
                Model.Life.Value = gameService.GetLife();
                Model.CurrentScore.Value = gameService.Score;
                Model.ClearScore.Value = gameService.GetLandmark().ClearScore;
                DeleteObject(hbitmap);
                //ゲームオーバー時
                if (gameService.IsGameOver)
                {
                    dialogService.ShowDialog(GameViewConstants.DIALOG_NAME_GAME_OVER, new DialogParameters($"message={"ゲームオーバー!"}"), result =>
                    {
                        if (result.Result == ButtonResult.Yes)
                        {
                            RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
                            isLoaded = false;
                            gameService.End();
                        }
                        else
                        {
                            RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_TITLE);
                            isLoaded = false;
                            gameService.End();
                        }
                    });
                }
                //ステージクリアー時
                if (gameService.IsStageClear)
                {
                    dialogService.ShowDialog(GameViewConstants.DIALOG_NAME_STAGE_CLEAR, new DialogParameters($"message={"ステージクリア!"}"), result => 
                    {
                        if (result.Result == ButtonResult.Yes)
                        {
                            gameService.Next();
                        }
                        else
                        {
                            gameService.Next();
                        }
                    });
                }
            }
        }

        #endregion イベントハンドラ

        #region 拡張メソッド

        /// <summary>
        /// gdi32.dllのDeleteObjectメソッドの使用を宣言する
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        #endregion 拡張メソッド
    }
}
