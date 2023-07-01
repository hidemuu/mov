using Reactive.Bindings;

namespace Mov.WpfModels.Controls
{
    public class DragDropModel
    {
        public ReactivePropertySlim<bool> IsDragSource { get; } = new ReactivePropertySlim<bool>(true);

        public ReactivePropertySlim<bool> IsDropTarget { get; } = new ReactivePropertySlim<bool>(true);
    }
}
