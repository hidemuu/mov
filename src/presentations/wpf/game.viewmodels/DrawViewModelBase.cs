using Mov.Game.Models.interfaces;
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
    public abstract class DrawViewModelBase : BindableBase
    {
        #region フィールド

        protected readonly IDialogService dialogService;
        protected readonly IGameRepositoryCollection repository;

        private Bitmap bitmap;
        private Graphics graphics;
        protected CompositeDisposable disposables = new CompositeDisposable();

        #endregion フィールド

        #region プロパティ

        public abstract DrawModel Model { get; }
        protected abstract DrawServiceBase Service { get; set; }
        protected IRegionManager RegionManager { get; }
        public ReactiveTimer Timer { get; } = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));

        #endregion プロパティ

        #region コマンド
        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        #region コンストラクター

        public DrawViewModelBase(IRegionManager regionManager, IDialogService dialogService, IGameRepositoryCollection repository)
        {
            this.RegionManager = regionManager;
            this.dialogService = dialogService;
            this.repository = repository;

            Initialize();
            LoadedCommand.Subscribe(() => OnLoadedCommand());
        }

        #endregion コンストラクター

        #region メソッド

        protected virtual void Initialize()
        {
            this.bitmap = new Bitmap(Service.FrameWidth, Service.FrameHeight);
            this.graphics = Graphics.FromImage(bitmap);

        }

        protected virtual void Update()
        {

        }

        protected virtual void Next()
        {

        }

        #endregion メソッド

        #region イベントハンドラ

        private void OnLoadedCommand()
        {
            // 定期更新スレッド
            Timer.Subscribe(_ => OnTimer());
            Timer.AddTo(disposables);
            Timer.Start();

            Service.Initialize();
            Service.Run();
        }

        private void OnTimer()
        {
            this.Service.Draw(graphics);
            var hbitmap = bitmap.GetHbitmap();
            //モデル生成
            Model.ImageSource.Value = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Update();
            DeleteObject(hbitmap);
            Next();
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
