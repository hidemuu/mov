using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.ViewModels.Models
{
    public class ConfigModel
    {
        public ReactivePropertySlim<int> Index { get; } = new ReactivePropertySlim<int>();
    }
}
