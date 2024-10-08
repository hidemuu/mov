﻿using Mov.Core.Graphicers;
using Mov.Core.Templates.Repositories;
using Mov.Drawer.Models;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Drawing;
using System.Reactive.Concurrency;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Mov.Drawer.ViewModels
{
    public abstract class DrawViewModelBase : RegionViewModelBase
    {
        #region フィールド

        protected readonly IDomainRepositoryCollection<IDrawerRepository> database;

        protected IDrawerRepository repository;

        private Bitmap bitmap;
        private Graphics graphics;

        #endregion フィールド

        #region プロパティ

        public abstract DrawModel Model { get; }
        protected abstract GraphicControllerBase Service { get; set; }
        public ReactiveTimer Timer { get; } = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));

        #endregion プロパティ

        #region コンストラクター

        public DrawViewModelBase(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IDrawerRepository> database) : base(regionManager, dialogService)
        {
            this.database = database;
            this.repository = database.GetRepository("");
        }

        #endregion コンストラクター

        #region メソッド

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
            this.bitmap = new Bitmap(Service.FrameWidth, Service.FrameHeight);
            this.graphics = Graphics.FromImage(bitmap);
            Start();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }

        private void OnTimer()
        {
            this.Service.Draw(this.graphics);
            var hbitmap = this.bitmap.GetHbitmap();
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