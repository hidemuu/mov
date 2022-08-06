using Mov.Drawer.ViewModels;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Mov.Game.ViewModels
{
    public class GameSoftModel : DrawModel
    {

        public ReactivePropertySlim<int> Life { get; set; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> Level { get; set; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> CurrentScore { get; set; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> ClearScore { get; set; } = new ReactivePropertySlim<int>();
    }
}
