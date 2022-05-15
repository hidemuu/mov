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
    public class GameCanvasViewModel : DrawViewModelBase
    {
        #region フィールド

        private CanvasServiceFactory serviceFactory;
        
        #endregion フィールド

        #region プロパティ

        public override DrawModel Model { get; } = new GameCanvasModel();
        
        protected override DrawServiceBase Service { get; set; }

        #endregion プロパティ

        #region コンストラクター

        public GameCanvasViewModel(IRegionManager regionManager, IDialogService dialogService, IGameRepositoryCollection repository) : base(regionManager, dialogService, repository)
        {

        }

        #endregion コンストラクター

        #region メソッド

        protected override void Initialize()
        {
            this.serviceFactory = new CanvasServiceFactory(this.repository);
            this.Service = serviceFactory.Create("TreeCurve");
            base.Initialize();
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


    }
}
