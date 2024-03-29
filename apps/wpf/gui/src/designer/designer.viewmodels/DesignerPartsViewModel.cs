﻿using Mov.Core.Layouts;
using Mov.Designer.Engine;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;

namespace Mov.Designer.ViewModels
{
    public class DesignerPartsViewModel : RegionViewModelBase
    {
        #region プロパティ

        public ReactivePropertySlim<IDesignerFacade> Service { get; private set; } = new ReactivePropertySlim<IDesignerFacade>();

        public ReactivePropertySlim<ILayoutFacade> LayoutFacade { get; private set; } = new ReactivePropertySlim<ILayoutFacade>();

        public ReactivePropertySlim<string> RepositoryName { get; private set; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<bool> IsUpdate { get; private set; } = new ReactivePropertySlim<bool>(false);

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerPartsViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
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
            this.Service.Value = navigationContext.Parameters[DesignerViewModel.NAVIGATION_PARAM_NAME_SERVICE] as IDesignerFacade;
            this.LayoutFacade.Value = this.Service.Value.LayoutFacade;
            this.RepositoryName.Value = navigationContext.Parameters[DesignerViewModel.NAVIGATION_PARAM_NAME_REPOSITORY_NAME] as string;
            IsUpdate.Value = true;
        }

        #endregion イベント
    }
}