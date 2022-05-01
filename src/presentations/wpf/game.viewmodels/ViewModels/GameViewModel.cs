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

namespace Mov.Game.ViewModels.ViewModels
{
    public class GameViewModel : BindableBase
    {
        public GameModel Models { get; } = new GameModel();
        private IRegionManager regionManager { get; }
        private readonly IDialogService dialogService;

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();
        public ReactiveTimer Timer { get; } = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));

        private readonly IGameService gameService;
        private Bitmap bitmap;
        private Graphics graphics;
        private CompositeDisposable disposables = new CompositeDisposable();
        private bool isLoaded = false;

        public GameViewModel(IRegionManager regionManager, IDialogService dialogService, IGameService gameService)
        {
            this.regionManager = regionManager;
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

        private void OnLoadedCommand()
        {
            isLoaded = true;
            gameService.Run();
        }

        private void OnTimer()
        {
            if (isLoaded)
            {
                gameService.Draw(graphics);
                var hbitmap = bitmap.GetHbitmap();
                Models.ImageSource.Value = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                Models.Life.Value = gameService.GetLife();
                DeleteObject(hbitmap);
                Models.Score.Value = gameService.Score;
                if (gameService.IsGameOver)
                {
                    dialogService.ShowDialog("GameOverDialog", new DialogParameters($"message={"ゲームオーバー!"}"), result =>
                    {
                        if (result.Result == ButtonResult.Yes)
                        {
                            regionManager.RequestNavigate("MainRegion", "GameTitleView");
                            isLoaded = false;
                            gameService.End();
                        }
                    });
                }
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject); // gdi32.dllのDeleteObjectメソッドの使用を宣言する。

    }
}
