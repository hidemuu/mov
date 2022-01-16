using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfViewModels.Components.Tables
{
    public interface ITableViewModelContent
    {
        public ReactivePropertySlim<int> Id { get; }
    }
}
