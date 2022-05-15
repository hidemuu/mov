using Mov.Game.Service;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.ViewModels
{
    public class GameTitleViewModel : BindableBase
    {
        #region フィールド

        private IMachineGameService gameService;
        private CompositeDisposable disposables = new CompositeDisposable();

        #endregion フィールド

        #region プロパティ
        public IRegionManager RegionManager { get; }

        public ReactiveCollection<int> Levels { get; } = new ReactiveCollection<int>();

        public ReactivePropertySlim<int> SelectedLevel { get; } = new ReactivePropertySlim<int>();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand StartCommand { get; } = new ReactiveCommand();
        public ReactiveCommand CanvasCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ConfigCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        #region コンストラクター

        public GameTitleViewModel(IRegionManager regionManager, IMachineGameService gameService)
        {
            this.RegionManager = regionManager;
            this.gameService = gameService;
            StartCommand.Subscribe(OnStartCommand).AddTo(disposables);
            CanvasCommand.Subscribe(OnCanvasCommand).AddTo(disposables);
            ConfigCommand.Subscribe(OnConfigCommand).AddTo(disposables); ;
            Levels.AddRangeOnScheduler(gameService.GetLevels());
            SelectedLevel.Where(x => x > 0).Subscribe(OnLevelSelectChanged);
        }

        #endregion コンストラクター

        #region イベントハンドラ

        private void OnStartCommand()
        {
            if(SelectedLevel.Value > 0) this.gameService.SetLevel(SelectedLevel.Value);
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_MAP);
        }

        private void OnConfigCommand()
        {
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_CONFIG);
        }

        private void OnCanvasCommand()
        {
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, GameViewConstants.VIEW_NAME_CANVAS);
        }

        private void OnLevelSelectChanged(int lv)
        {

        }

        #endregion イベントハンドラ
    }
}
