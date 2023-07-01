using Reactive.Bindings;
using System;

namespace Mov.WpfModels.Controls
{
    public class TabItem
    {
        public int Index { get; }
        public Action TabCommand { get; }

        public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> IconKey { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<bool> IsSelected { get; } = new ReactivePropertySlim<bool>();

        public TabItem(int index, string title, string iconkey, Action tabcommand)
        {
            Index = index;
            TabCommand = tabcommand;
            Title.Value = title;
            IconKey.Value = iconkey;
        }
    }
}
