using Mov.Accessors.Repository;
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

        #endregion フィールド

        #region プロパティ

        public ReactivePropertySlim<IDesignerRepository> Repository { get; private set; } = new ReactivePropertySlim<IDesignerRepository>();

        public ReactivePropertySlim<bool> IsUpdate { get; private set; } = new ReactivePropertySlim<bool>(false);

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerPartsViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IDesignerRepository> database) : base(regionManager, dialogService)
        {
            
        }

        #endregion コンストラクター

        #region イベント

        protected override void OnLoaded()
        {

        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
            this.IsUpdate.Value = false;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            this.Repository.Value = navigationContext.Parameters[DesignerViewModel.NAVIGATION_PARAM_NAME_REPOSITORY] as IDesignerRepository;
            IsUpdate.Value = true;
        }

        #endregion イベント

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
