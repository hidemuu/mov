using Mov.Designer.Models.interfaces;
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
using System.Windows.Media;

namespace Mov.Designer.ViewModels
{
    public class DesignerViewModel : RegionViewModelBase
    {
        #region フィールド

        public const string REGION_NAME_CONTENT = "DESIGNER_CENTER";

        public const string PAGE_NAME_TREE = "Tree";

        public const string PAGE_NAME_TABLE = "Table";

        public const string PAGE_NAME_PARTS = "Parts";

        private readonly IDictionary<string, string> pageDictionary = new Dictionary<string, string>() {
            { PAGE_NAME_TREE, "DesignerTreeView" },
            { PAGE_NAME_TABLE, "DesignerTableView" },
            { PAGE_NAME_PARTS, "DesignerPartsView" },
        };

        private string pageName = PAGE_NAME_TREE;

        private readonly IDesignerRepositoryCollection repository;

        #endregion フィールド

        #region コマンド

        public ReactiveCommand<string> ShowPageCommand { get; } = new ReactiveCommand<string>();

        public ReactiveCommand<string> SaveCommand { get; } = new ReactiveCommand<string>();

        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        public DesignerViewModel(IRegionManager regionManager, IDialogService dialogService, IDesignerRepositoryCollection repository) : base(regionManager, dialogService)
        {
            this.repository = repository;
            ShowPageCommand.Subscribe(OnPageChangeCommand).AddTo(Disposables);
            SaveCommand.Subscribe(OnSaveCommand).AddTo(Disposables);
        }

        #endregion コンストラクター

        #region イベント

        protected override void OnLoaded() => OnPageChangeCommand(this.pageName);

        #endregion イベント

        #region 内部メソッド

        private void OnPageChangeCommand(string pageName)
        {
            this.pageName = pageName;
            this.RegionManager.RequestNavigate(REGION_NAME_CONTENT, pageDictionary[this.pageName]);
        }

        private void OnSaveCommand(string parameter)
        {
            switch (this.pageName)
            {
                case PAGE_NAME_TREE:
                    this.repository.LayoutTrees.Posts();
                    break;
                case PAGE_NAME_TABLE:
                    this.repository.ContentTables.Posts();
                    break;
            }
        }

        #endregion

    }
}
