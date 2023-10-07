using Reactive.Bindings;

namespace Mov.Suite.WpfApp.Shared.Models
{
    public class GameStatusModel
    {
        public ReactivePropertySlim<int> Life { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> Level { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> CurrentScore { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> ClearScore { get; } = new ReactivePropertySlim<int>();
    }
}
