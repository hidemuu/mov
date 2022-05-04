using Mov.Game.Service;
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
    public class GameTitleViewModel : BindableBase
    {
        #region フィールド

        private IGameService gameService;

        #endregion フィールド

        #region プロパティ
        public IRegionManager RegionManager { get; }

        public ReactiveCollection<int> MapLevels { get; } = new ReactiveCollection<int>();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand StartCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ConfigCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        #region コンストラクター

        public GameTitleViewModel(IRegionManager regionManager, IGameService gameService)
        {
            this.RegionManager = regionManager;
            this.gameService = gameService;
            StartCommand.Subscribe(OnStartCommand);
            ConfigCommand.Subscribe(OnConfigCommand);
            MapLevels.AddRangeOnScheduler(gameService.GetLevels());
        }

        #endregion コンストラクター

        #region イベントハンドラ

        private void OnStartCommand()
        {
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_GAME);
        }

        private void OnConfigCommand()
        {
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_CONFIG);
        }

        #endregion イベントハンドラ
    }
}
