using Mov.Designer.Models;
using Mov.Designer.Service;
using Mov.Designer.Service.Nodes;
using Mov.WpfControls.ViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerPartsViewModel : RegionViewModelBase
    {
        #region フィールド

        private LayoutBuilder builder;

        private IDesignerRepository repository;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<LayoutNodeBase> Models { get; } = new ReactiveCollection<LayoutNodeBase>();

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerPartsViewModel(IRegionManager regionManager, IDialogService dialogService, IDesignerDatabase database) : base(regionManager, dialogService)
        {
            
        }

        #endregion コンストラクター

        #region イベント

        protected override void OnLoaded()
        {

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            this.repository = navigationContext.Parameters[DesignerViewModel.PARAM_NAME_DESIGN_REPOSITORY] as IDesignerRepository;
            builder = new LayoutBuilder(this.repository);
            Models.Clear();
            Models.AddRangeOnScheduler(builder.Build().Layout.Children);
        }

        #endregion イベント

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
