using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfModels
{
    public class DragDropModel
    {
        public ReactivePropertySlim<bool> IsDragSource { get; } = new ReactivePropertySlim<bool>(true);

        public ReactivePropertySlim<bool> IsDropTarget { get; } = new ReactivePropertySlim<bool>(true);
    }
}
