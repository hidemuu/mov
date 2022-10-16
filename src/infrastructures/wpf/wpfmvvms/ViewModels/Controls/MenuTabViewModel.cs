using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows.Controls;

namespace Mov.WpfMvvms.ViewModels.Tabs
{
    public class MenuTabViewModel
    {
        public ReactiveCollection<MenuTabViewModelContent> Models { get; } = new ReactiveCollection<MenuTabViewModelContent>();
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);
        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();

        private CompositeDisposable disposables = new CompositeDisposable();

        public MenuTabViewModel()
        {
            TabChangeCommand.Subscribe(() => { Models.FirstOrDefault(x => x.Index == TabPage.Value).TabCommand(); }).AddTo(disposables);
        }
    }
}