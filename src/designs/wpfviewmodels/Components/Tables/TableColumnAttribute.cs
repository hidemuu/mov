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
        public string Header { get; set; }

        public int Width { get; set; }

        public ReactivePropertySlim<bool> IsVisible { get; } = new ReactivePropertySlim<bool>(true);

    }
}
