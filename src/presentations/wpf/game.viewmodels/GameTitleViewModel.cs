using Mov.Game.Models;
using Mov.Game.Service;
using Mov.WpfControls.ViewModels;
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
    public class GameTitleViewModel : ViewModelBase
    {
        #region フィールド

        private IActionGame gameService;

        #endregion フィールド

        #region プロパティ
        public IRegionManager RegionManager { get; }

        public ReactiveCollection<string> Softs { get; } = new ReactiveCollection<string>();

        public ReactivePropertySlim<string> SelectedSoft { get; } = new ReactivePropertySlim<string>();

        public ReactiveCollection<int> Levels { get; } = new ReactiveCollection<int>();

        public ReactivePropertySlim<int> SelectedLevel { get; } = new ReactivePropertySlim<int>();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand StartCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        #region コンストラクター

        public GameTitleViewModel(IRegionManager regionManager, IActionGame gameService)
        {
            this.RegionManager = regionManager;
            this.gameService = gameService;
            StartCommand.Subscribe(OnStartCommand).AddTo(Disposables);
            Softs.AddRangeOnScheduler(new string[] { GameViewConstants.VIEW_NAME_SOFT });
            SelectedSoft.Value = GameViewConstants.VIEW_NAME_SOFT;
            SelectedSoft.Where(x => !string.IsNullOrEmpty(x)).Subscribe(OnSoftSelectChanged).AddTo(Disposables);
            Levels.AddRangeOnScheduler(gameService.GetLevels());
            SelectedLevel.Value = 1;
            SelectedLevel.Where(x => x > 0).Subscribe(OnLevelSelectChanged).AddTo(Disposables);
        }

        #endregion コンストラクター

        #region イベントハンドラ

        private void OnStartCommand()
        {
            if(SelectedLevel.Value > 0) this.gameService.SetLevel(SelectedLevel.Value);
            this.RegionManager.RequestNavigate(GameViewConstants.REGION_NAME_MAIN, SelectedSoft.Value);
        }

        private void OnSoftSelectChanged(string soft)
        {

        }

        private void OnLevelSelectChanged(int lv)
        {

        }

        #endregion イベントハンドラ
    }
}
