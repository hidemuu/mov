using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfViewModels.Components.Tables
{
    public class ColumnAttribute
    {
        public ReactivePropertySlim<string> Header { get; set; } = new ReactivePropertySlim<string>(string.Empty);

        public ReactivePropertySlim<int> Width { get; set; } = new ReactivePropertySlim<int>(100);

        public ReactivePropertySlim<bool> IsVisible { get; } = new ReactivePropertySlim<bool>(true);

        public ColumnAttribute(string header, int width = 100)
        {
            Header.Value = header;
            Width.Value = width;
        }

    }
}
