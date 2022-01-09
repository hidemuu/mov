using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows.Controls;

namespace Mov.WpfControls.ViewModels.Molecules
{
    public class MenuTabViewModel
    {
        public ReactiveCollection<MenuTabItem> Models { get; } = new ReactiveCollection<MenuTabItem>();
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);
        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();

        private CompositeDisposable disposables = new CompositeDisposable();

        public MenuTabViewModel()
        {
            TabChangeCommand.Subscribe(() => { Models.FirstOrDefault(x => x.Index == TabPage.Value).TabCommand(); }).AddTo(disposables);
        }

        public class MenuTabItem
        {
            public int Index { get; }
            public Action TabCommand { get; }

            public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<Image> IconKey { get; } = new ReactivePropertySlim<Image>();
            public ReactivePropertySlim<bool> IsSelected { get; } = new ReactivePropertySlim<bool>();

            public MenuTabItem(int index, string title, Image iconkey, Action tabcommand)
            {
                Index = index;
                TabCommand = tabcommand;
                Title.Value = title;
                IconKey.Value = iconkey;
            }
        }
    }
}