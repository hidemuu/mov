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
        public ReactivePropertySlim<string> Category { get; }
        public ReactivePropertySlim<string> Code { get; }
        public ReactivePropertySlim<string> Name { get; }
        public ReactivePropertySlim<string> Value { get; }
        public ReactivePropertySlim<string> Description { get; }
    }
}
