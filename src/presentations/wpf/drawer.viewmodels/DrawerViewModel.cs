using Mov.Accessors.Repository;
using Mov.Drawer.Models;
using Mov.Drawer.Service;
using Mov.Drawer.Service.Canvas;
using Mov.Painters;
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

namespace Mov.Drawer.ViewModels
{
    public class DrawerViewModel : DrawViewModelBase
    {
        #region フィールド

        private CanvasServiceFactory serviceFactory;
        
        #endregion フィールド

        #region プロパティ

        public override DrawModel Model { get; } = new DrawModel();
        
        protected override GraphicControllerBase Service { get; set; }

        public ReactiveCollection<string> Canvases { get; } = new ReactiveCollection<string>();

        public ReactivePropertySlim<string> SelectedCanvas { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<double> RefleshRate { get; } = new ReactivePropertySlim<double>();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand DrawCommand { get; } = new ReactiveCommand();

        public ReactiveCommand StopCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        #region コンストラクター

        public DrawerViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IDrawerRepository> database) : base(regionManager, dialogService, database)
        {
            this.serviceFactory = new CanvasServiceFactory(this.repository);
            var drawItems = this.repository.DrawItems.Get();
            var drawItem = drawItems.FirstOrDefault(x => x.Index == 0);
            CreateService(drawItem);
            Canvases.AddRangeOnScheduler(drawItems.Select(x => x.Category));
            RefleshRate.Value = drawItem.RefleshRate;
            DrawCommand.Subscribe(OnDrawCommand).AddTo(Disposables);
            StopCommand.Subscribe(OnStopCommand).AddTo(Disposables);
        }

        #endregion コンストラクター

        #region メソッド

        private void CreateService(DrawItem drawItem)
        {
            this.Service = serviceFactory.Create(drawItem.Category);
            Service.FrameWidth = drawItem.Width;
            Service.FrameHeight = drawItem.Height;
            Service.RefleshTime = drawItem.RefleshRate;
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Next()
        {
            base.Next();
        }

        #endregion メソッド

        #region イベントハンドラ

        private void OnDrawCommand()
        {
            Stop();
            UpdateService(SelectedCanvas.Value);
            Start();
        }

        private void OnStopCommand()
        {
            Stop();
        }

        private void UpdateService(string category)
        {
            this.Service = serviceFactory.Create(category);
            Service.RefleshTime = RefleshRate.Value;
        }


        #endregion イベントハンドラ


    }
}
