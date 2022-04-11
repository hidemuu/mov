using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Mov.Game.ViewModels.Models
{
    public class GameModel
    {
        public ReactivePropertySlim<int> Life { get; set; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> Stage { get; set; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<int> Score { get; set; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<BitmapSource> ImageSource { get; set; } = new ReactivePropertySlim<BitmapSource>();
    }
}
