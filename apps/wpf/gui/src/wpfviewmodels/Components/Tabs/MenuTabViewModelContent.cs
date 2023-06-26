using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mov.WpfViewModels.Components.Tabs
{
    public class MenuTabViewModelContent
    {
        public int Index { get; }
        public Action TabCommand { get; }

        public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<Image> IconKey { get; } = new ReactivePropertySlim<Image>();
        public ReactivePropertySlim<bool> IsSelected { get; } = new ReactivePropertySlim<bool>();

        public MenuTabViewModelContent(int index, string title, Image iconkey, Action tabcommand)
        {
            Index = index;
            TabCommand = tabcommand;
            Title.Value = title;
            IconKey.Value = iconkey;
        }
    }
}
