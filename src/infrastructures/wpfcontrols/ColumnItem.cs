using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.WpfControls
{
    public class ColumnItem
    {
        public ReactivePropertySlim<string> Path { get; set; } = new ReactivePropertySlim<string>(string.Empty);
        public ReactivePropertySlim<string> Value { get; set; } = new ReactivePropertySlim<string>(string.Empty);
        public ReactivePropertySlim<string> Type { get; set; } = new ReactivePropertySlim<string>(string.Empty);
    }
}
