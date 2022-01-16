using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfViewModels.Components.Tables
{
    public class TableColumnAttribute
    {
        public ReactivePropertySlim<string> Header { get; } = new ReactivePropertySlim<string>("");

        public ReactivePropertySlim<bool> IsVisible { get; } = new ReactivePropertySlim<bool>(true);

        public TableColumnAttribute(string header, bool isVisible)
        {
            Header.Value = header;
            IsVisible.Value = isVisible;
        }
    }
}
