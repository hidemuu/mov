using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfControls
{
    public class DragDropItem
    {
        public ReactivePropertySlim<bool> IsDragSource { get; } = new ReactivePropertySlim<bool>();

        public ReactivePropertySlim<bool> IsDropTarget { get; } = new ReactivePropertySlim<bool>();
    }
}
