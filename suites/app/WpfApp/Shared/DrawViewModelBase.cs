using Mov.Core.Graphicers.Services.Controllers;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Reactive.Bindings.Extensions;

namespace Mov.Suite.WpfApp.Shared
{
    public abstract class DrawViewModelBase : RegionViewModelBase
    {
        #region field

        private Bitmap bitmap;
        private Graphics graphics;

        #endregion field

        #region property

        protected abstract GraphicControllerBase Service { get; set; }
        public ReactiveTimer Timer { get; } = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));

        public ReactivePropertySlim<BitmapSource> ImageSource { get; set; } = new ReactivePropertySlim<BitmapSource>();

        #endregion property

        #region constructor

        public DrawViewModelBase(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {

        }

        #endregion constructor

        #region event

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
            ImageSource.Value = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Update();
            DeleteObject(hbitmap);
            Next();
        }

        #endregion event

        #region method

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

        #endregion method

        #region external method

        /// <summary>
        /// gdi32.dllのDeleteObjectメソッドの使用を宣言する
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        #endregion external method
    }
}
