using Mov.Game.Models.interfaces;
using Mov.Game.Service;
using Mov.Game.Service.Canvas;
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
    public class GameCanvasViewModel : BindableBase
    {
        #region フィールド

        private readonly IDialogService dialogService;
        private readonly IGameRepositoryCollection repository;

        private readonly ICanvasService service;
        private readonly CanvasServiceFactory serviceFactory;
        
        private Bitmap bitmap;
        private Graphics graphics;
        private CompositeDisposable disposables = new CompositeDisposable();

        #endregion フィールド

        #region プロパティ

        public GameCanvasModel Model { get; } = new GameCanvasModel();
        private IRegionManager RegionManager { get; }
        public ReactiveTimer Timer { get; } = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));

        #endregion プロパティ

        #region コマンド
        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        #region コンストラクター

        public GameCanvasViewModel(IRegionManager regionManager, IDialogService dialogService, IGameRepositoryCollection repository)
        {
            this.RegionManager = regionManager;
            this.dialogService = dialogService;
            this.repository = repository;

            this.serviceFactory = new CanvasServiceFactory(this.repository);
            this.service = serviceFactory.Create("TreeCurve");

            this.bitmap = new Bitmap(service.FrameWidth, service.FrameHeight);
            this.graphics = Graphics.FromImage(bitmap);

            LoadedCommand.Subscribe(() => OnLoadedCommand());
        }

        #endregion コンストラクター

        #region イベントハンドラ

        private void OnLoadedCommand()
        {
            // 定期更新スレッド
            Timer.Subscribe(_ => OnTimer());
            Timer.AddTo(disposables);
            Timer.Start();

            service.Initialize();
            service.Run();
        }

        private void OnTimer()
        {
            this.service.Draw(graphics);
            var hbitmap = bitmap.GetHbitmap();
            //モデル生成
            Model.ImageSource.Value = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hbitmap);
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
