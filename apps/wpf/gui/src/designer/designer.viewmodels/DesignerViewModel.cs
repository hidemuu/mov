using Mov.Designer.Engine;
using Mov.Designer.Models;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;

namespace Mov.Designer.ViewModels
{
    public class DesignerViewModel : RegionViewModelBase
    {
        #region フィールド

        public const string NAVIGATION_PARAM_NAME_REPOSITORY = "repository";

        public const string NAVIGATION_PARAM_NAME_SERVICE = "service";

        public const string NAVIGATION_PARAM_NAME_REPOSITORY_NAME = "repositoryName";

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

        private readonly IDesignerFacade service;

        #endregion フィールド

        #region プロパティ

        public ReactivePropertySlim<string> PageName { get; set; } = new ReactivePropertySlim<string>(PAGE_NAME_TREE);

        public ReactiveCollection<string> ComboItems { get; } = new ReactiveCollection<string>();

        public ReactivePropertySlim<string> SelectedComboItem { get; } = new ReactivePropertySlim<string>();

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
        public DesignerViewModel(IRegionManager regionManager, IDialogService dialogService, IDesignerFacade service, IDesignerRepositoryCollection repositories) : base(regionManager, dialogService)
        {
            this.service = service;
            this.SelectedComboItem.Value = repositories.DefaultRepositoryName;
            this.ComboItems.AddRangeOnScheduler(repositories.GetRepositoryNames());
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
            param.Add(NAVIGATION_PARAM_NAME_SERVICE, this.service);
            param.Add(NAVIGATION_PARAM_NAME_REPOSITORY_NAME, selectedComboItem);
            this.RegionManager.RequestNavigate(REGION_NAME_CONTENT, pageDictionary[pageName], param);
        }

        private void OnSaveCommand(string parameter)
        {
            this.service.Write();
        }

        #endregion 内部メソッド
    }
}