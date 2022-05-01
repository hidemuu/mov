using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.ViewModels.ViewModels
{
    public class GameTitleViewModel : BindableBase
    {
        public IRegionManager regionManager { get; }

        public ReactiveCommand StartCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ConfigCommand { get; } = new ReactiveCommand();

        public GameTitleViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            StartCommand.Subscribe(() => { this.regionManager.RequestNavigate("MainRegion", "GameView"); });
            ConfigCommand.Subscribe(() => { this.regionManager.RequestNavigate("MainRegion", "GameConfigView"); });
        }
    }
}
