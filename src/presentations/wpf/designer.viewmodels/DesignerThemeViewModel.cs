using MaterialDesignColors;
using Mov.Accessors.Repository;
using Mov.Designer.Models;
using Mov.WpfDesigns.Services;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerThemeViewModel : RegionViewModelBase
    {
        #region フィールド

        private IDesignerRepository repository;

        #endregion フィールド

        #region プロパティ

        public Swatch[] Swatches { get; } = new SwatchesProvider().Swatches.ToArray();

        public ReactivePropertySlim<Swatch> SelectedSwatch { get; }

        #endregion プロパティ

        #region コンストラクター

        public DesignerThemeViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
            // ComboBoxの初期値を設定するにはItemsSourceで利用しているインスタンスの中から指定する必要がある
            SelectedSwatch = new ReactivePropertySlim<Swatch>(Swatches.FirstOrDefault(s => s.Name == ThemeService.CurrentTheme.Name));
            SelectedSwatch.Subscribe(s => ChangeTheme(s)).AddTo(this.Disposables);

        }

        #endregion コンストラクター

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            this.repository = navigationContext.Parameters[DesignerViewModel.NAVIGATION_PARAM_NAME_REPOSITORY] as IDesignerRepository;
        }

        #region メソッド

        private void ChangeTheme(Swatch swatch)
        {
            ThemeService.ApplyTheme(swatch);
        }

        #endregion メソッド
    }
}
