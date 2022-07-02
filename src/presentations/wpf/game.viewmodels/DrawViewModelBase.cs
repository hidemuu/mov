using Mov.Game.Models.interfaces;
using Mov.Game.Service;
using Mov.Game.ViewModels.Models;
using Mov.WpfControls.ViewModels;
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
    public abstract class DrawViewModelBase : RegionViewModelBase
    {
        #region フィールド

        protected readonly IGameRepositoryCollection repository;

        private Bitmap bitmap;
        private Graphics graphics;

        #endregion フィールド

        #region プロパティ

        public abstract DrawModel Model { get; }
        protected abstract DrawServiceBase Service { get; set; }
        public ReactiveTimer Timer { get; } = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));

        #endregion プロパティ

        #region コンストラクター

        public DrawViewModelBase(IRegionManager regionManager, IDialogService dialogService, IGameRepositoryCollection repository) : base(regionManager, dialogService)
        {
            this.repository = repository;

            Initialize();
        }

        #endregion コンストラクター

        #region メソッド

        protected virtual void Initialize()
        {
            this.bitmap = new Bitmap(Service.FrameWidth, Service.FrameHeight);
            this.graphics = Graphics.FromImage(bitmap);

        }

        protected override void Dispose(bool disposing)
        {
            Service.End();
            base.Dispose(disposing);
        }

        /// <inheritdoc/>
        protected virtual void Update()
        {

        }

        protected virtual void Next()
        {

        }

        protected void Start()
        {
            // 定期更新スレッド
            Timer.Subscribe(_ => OnTimer());
            Timer.AddTo(Disposables);
            Timer.Start();

            Service.Initialize();
            Service.Run();
        }

        protected void Stop()
        {
            Service.Wait();
            Timer.Stop();
        }

        #endregion メソッド

        #region イベントハンドラ

        protected override void OnLoaded()
        {
            Start();
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
