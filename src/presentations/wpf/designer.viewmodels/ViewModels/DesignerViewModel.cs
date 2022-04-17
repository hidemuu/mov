using Mov.WpfViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerViewModel : RegionViewModelBase
    {
        #region フィールド

        public const string REGION_NAME_CENTER = "DESIGNER_CENTER";

        public const string PAGE_NAME_TREE = "DesignerTree";

        public const string PAGE_NAME_TABLE = "DesignerTable";

        public const string PAGE_NAME_PARTS = "DesignerParts";

        private readonly IDictionary<string, string> pageDictionary = new Dictionary<string, string>() {
            { PAGE_NAME_TREE, "DesignerTreeView" },
            { PAGE_NAME_TABLE, "DesignerTableView" },
            { PAGE_NAME_PARTS, "DesignerPartsView" },
        };

        private string pageName = PAGE_NAME_TREE;

        #endregion フィールド

        #region コマンド

        public ReactiveCommand<string> ShowPageCommand { get; } = new ReactiveCommand<string>();

        #endregion コマンド

        public DesignerViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
            ShowPageCommand.Subscribe(DisplayPage).AddTo(Disposables);
        }

        #region イベント

        protected override void OnLoaded() => DisplayPage(this.pageName);

        #endregion イベント

        #region メソッド

        private void DisplayPage(string pageName)
        {
            this.pageName = pageName;
            this.RegionManager.RequestNavigate(REGION_NAME_CENTER, pageDictionary[this.pageName]);
        }

        #endregion

    }
}
