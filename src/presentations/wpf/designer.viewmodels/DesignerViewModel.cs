using Mov.Accessors.Repository;
using Mov.Designer.Models;
using Mov.WpfMvvms;
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

        public const string NAVIGATION_PARAM_NAME_REPOSITORY = "repository";

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

        private readonly IDomainRepositoryCollection<IDesignerRepository> database;

        private IDesignerRepository repository;

        #endregion フィールド

        #region プロパティ

        public ReactivePropertySlim<string> PageName { get; set; } = new ReactivePropertySlim<string>(PAGE_NAME_PARTS);


        public ReactiveCollection<string> ComboItems { get; } = new ReactiveCollection<string>()
        {
            "", "driver",
        };
        public ReactivePropertySlim<string> SelectedComboItem { get; } = new ReactivePropertySlim<string>("");


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
        public DesignerViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IDesignerRepository> database) : base(regionManager, dialogService)
        {
            this.database = database;
            this.repository = database.GetRepository(SelectedComboItem.Value);
            ShowPageCommand.Subscribe(OnPageChangeCommand).AddTo(Disposables);
            SaveCommand.Subscribe(OnSaveCommand).AddTo(Disposables);
        }

        #endregion コンストラクター

        #region イベント

        protected override void OnLoaded() 
        { 
            OnPageChangeCommand(this.PageName.Value);
            SelectedComboItem.Subscribe(OnSelectedComboItemChanged).AddTo(Disposables);
        }

        #endregion イベント

        #region 内部メソッド

        private void OnPageChangeCommand(string pageName)
        {
            this.PageName.Value = pageName;
            RequestNavigate(pageName, SelectedComboItem.Value);
        }

        private void OnSelectedComboItemChanged(string selectedComboItem)
        {
            RequestNavigate(this.PageName.Value, selectedComboItem);
        }

        private void RequestNavigate(string pageName, string selectedComboItem)
        {
            var param = new NavigationParameters();
            param.Add(NAVIGATION_PARAM_NAME_REPOSITORY, database.GetRepository(selectedComboItem));
            this.RegionManager.RequestNavigate(REGION_NAME_CONTENT, pageDictionary[pageName], param);
        }

        private void OnSaveCommand(string parameter)
        {
            switch (this.PageName.Value)
            {
                case PAGE_NAME_TREE:
                    this.repository.Nodes.Write();
                    break;
                case PAGE_NAME_TABLE:
                    this.repository.Contents.Write();
                    break;
            }
        }

        #endregion 内部メソッド

    }
}
