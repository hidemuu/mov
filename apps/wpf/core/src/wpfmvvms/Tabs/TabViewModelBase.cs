using Reactive.Bindings;
using System.Reactive.Disposables;

namespace Mov.WpfMvvms.Tabs
{
    public abstract class TabViewModelBase
    {
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);
        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();

        private CompositeDisposable disposables = new CompositeDisposable();

        public TabViewModelBase()
        {

        }
    }
}
