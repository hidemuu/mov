using Mov.Core.Graphicers;
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

namespace Mov.WpfMvvms.Renders
{
    public abstract class GraphicViewModelBase : RegionViewModelBase
    {
        #region フィールド

        private Bitmap bitmap;
        private Graphics graphics;

        #endregion フィールド

        #region プロパティ

        public ReactivePropertySlim<BitmapSource> ImageSource { get; set; } = new ReactivePropertySlim<BitmapSource>();

        protected abstract GraphicControllerBase Controller { get; set; }

        public ReactiveTimer Timer { get; } = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));

        #endregion プロパティ

        #region コンストラクター

        public GraphicViewModelBase(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
        }

        #endregion コンストラクター

        #region メソッド

        protected override void Dispose(bool disposing)
        {
            Controller.End();
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

            Controller.Initialize();
            Controller.Run();
        }

        protected void Stop()
        {
            Controller.Wait();
            Timer.Stop();
        }

        #endregion メソッド

        #region イベントハンドラ

        protected override void OnLoaded()
        {
            bitmap = new Bitmap(Controller.FrameWidth, Controller.FrameHeight);
            graphics = Graphics.FromImage(bitmap);
            Start();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }

        private void OnTimer()
        {
            Controller.Draw(graphics);
            var hbitmap = bitmap.GetHbitmap();
            //モデル生成
            ImageSource.Value = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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