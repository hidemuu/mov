using Mov.WpfMvvms;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows.Controls;

namespace Mov.WpfViewModels
{
    public class MenuTabViewModel
    {
        public ReactiveCollection<MenuTabModel> Models { get; } = new ReactiveCollection<MenuTabModel>();
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);
        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();

        private CompositeDisposable disposables = new CompositeDisposable();

        public MenuTabViewModel()
        {
            TabChangeCommand.Subscribe(() => { Models.FirstOrDefault(x => x.Index == TabPage.Value).TabCommand(); }).AddTo(disposables);
        }
    }
}