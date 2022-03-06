using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Wpf.Models
{
    public class MainWindowModel
    {
        public int Index { get; }
        public Action TabCommand { get; }

        public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> IconKey { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<bool> IsSelected { get; } = new ReactivePropertySlim<bool>();


        public MainWindowModel(int index, string title, string iconkey, Action tabcommand)
        {
            Index = index;
            TabCommand = tabcommand;
            Title.Value = title;
            IconKey.Value = iconkey;
        }
    }
}
