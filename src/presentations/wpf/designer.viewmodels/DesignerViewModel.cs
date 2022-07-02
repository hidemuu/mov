using Mov.Designer.Models;
using Mov.WpfControls.ViewModels;
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

        public const string PAGE_NAME_SHELL = "Shell";

        public const string PAGE_NAME_PARTS = "Parts";

        public const string PAGE_NAME_THEME = "Theme";

        private readonly IDictionary<string, string> pageDictionary = new Dictionary<string, string>() {
            { PAGE_NAME_TREE, "DesignerTreeView" },
            { PAGE_NAME_TABLE, "DesignerTableView" },
            { PAGE_NAME_SHELL, "DesignerShellView" },
            { PAGE_NAME_PARTS, "DesignerPartsView" },
            { PAGE_NAME_THEME, "DesignerThemeView" },
        };

        private readonly IDesignerRepositoryCollection repository;

        #endregion フィールド

        #region プロパティ

        public ReactivePropertySlim<string> PageName { get; set; } = new ReactivePropertySlim<string>(PAGE_NAME_TREE);

        #endregion プロパティ

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

        protected override void OnLoaded() => OnPageChangeCommand(this.PageName.Value);

        #endregion イベント

        #region 内部メソッド

        private void OnPageChangeCommand(string pageName)
        {
            this.PageName.Value = pageName;
            this.RegionManager.RequestNavigate(REGION_NAME_CONTENT, pageDictionary[this.PageName.Value]);
        }

        private void OnSaveCommand(string parameter)
        {
            switch (this.PageName.Value)
            {
                case PAGE_NAME_TREE:
                    this.repository.LayoutNodes.Export();
                    break;
                case PAGE_NAME_TABLE:
                    this.repository.Contents.Export();
                    break;
            }
        }

        #endregion 内部メソッド

    }
}
