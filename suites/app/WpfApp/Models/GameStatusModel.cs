using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class GameStatusModel
    {
        public ReactivePropertySlim<int> Life { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> Level { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> CurrentScore { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> ClearScore { get; } = new ReactivePropertySlim<int>();
    }
}
