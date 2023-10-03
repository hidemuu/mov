using Reactive.Bindings;

namespace Mov.Suite.WpfApp.Models
{
    public class GameStatusModel
    {
        public ReactivePropertySlim<int> Life { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> Level { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> CurrentScore { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> ClearScore { get; } = new ReactivePropertySlim<int>();
    }
}
