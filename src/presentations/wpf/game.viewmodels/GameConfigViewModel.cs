using Mov.Game.ViewModels.Models;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.ViewModels
{
    public class GameConfigViewModel : BindableBase
    {
        #region プロパティ

        public ReadOnlyReactiveCollection<ConfigModel> Models { get; }
        public IRegionManager regionManager { get; }

        #endregion プロパティ

        #region コンストラクター

        public GameConfigViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

        }

        #endregion コンストラクター
    }
}
