using MaterialDesignColors;
using Mov.Designer.Models.interfaces;
using Mov.WpfDesigns.Services;
using Mov.WpfViewModels;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerThemeViewModel : ViewModelBase
    {
        #region フィールド

        private readonly IDesignerRepositoryCollection repository;

        #endregion フィールド

        #region プロパティ

        public Swatch[] Swatches { get; } = new SwatchesProvider().Swatches.ToArray();

        public ReactivePropertySlim<Swatch> SelectedSwatch { get; }

        #endregion プロパティ

        #region コンストラクター

        public DesignerThemeViewModel(IDesignerRepositoryCollection repository)
        {
            this.repository = repository;
            // ComboBoxの初期値を設定するにはItemsSourceで利用しているインスタンスの中から指定する必要がある
            SelectedSwatch = new ReactivePropertySlim<Swatch>(Swatches.FirstOrDefault(s => s.Name == ThemeService.CurrentTheme.Name));
            SelectedSwatch.Subscribe(s => ChangeTheme(s)).AddTo(this.Disposables);

        }

        #endregion コンストラクター

        #region メソッド

        private void ChangeTheme(Swatch swatch)
        {
            ThemeService.ApplyTheme(swatch);
        }

        #endregion メソッド
    }
}
