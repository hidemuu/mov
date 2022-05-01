using Configurator.Views;
using Mov.Authorizer.Models;
using Mov.Authorizer.Repository;
using Mov.Authorizer.ViewModels;
using Mov.Authorizer.Views;
using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Configurator.ViewModels;
using Mov.Configurator.Views;
using Mov.Designer.Models;
using Mov.Designer.Models.interfaces;
using Mov.Designer.Repository.Xml;
using Mov.Designer.ViewModels;
using Mov.Designer.Views;
using Mov.Game.Models.interfaces;
using Mov.Game.Repository;
using Mov.Game.Service;
using Mov.Game.ViewModels.Services;
using Mov.Game.ViewModels.ViewModels;
using Mov.Game.Views;
using Mov.Scheduler.ViewModels;
using Mov.Scheduler.Views;
using Mov.Translator.Models;
using Mov.Translator.Repository;
using Mov.Translator.ViewModels;
using Mov.Translator.Views;
using Mov.Utilities;
using Mov.Wpf.ViewModels;
using Mov.WpfViewModels.Components.Dialogs;
using Mov.WpfViews;
using Mov.WpfViews.Components.Dialogs;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Mov.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        #region フィールド

        private Mutex mutex = new Mutex(false, "HalationGhostPrismMov");

        #endregion フィールド

        #region イベントハンドラ

        /// <summary>ApplicationのStartupイベントハンドラ。</summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントデータを格納しているStartupEventArgs。</param>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            if (this.mutex.WaitOne(0, false))
                return;

            MessageBox.Show("二重起動できません。", "情報", MessageBoxButton.OK, MessageBoxImage.Information);
            this.mutex.Close();
            this.mutex = null;
            this.Shutdown();
        }

        /// <summary>ApplicationのExitイベントハンドラ。</summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントデータを格納しているExitEventArgs。</param>
        private void OnExit(object sender, ExitEventArgs e)
        {
            if (this.mutex != null)
            {
                this.mutex.ReleaseMutex();
                this.mutex.Close();
            }
        }

        #endregion イベントハンドラ

        #region メソッド

        /// <summary>
        /// シェル生成
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>(); //初期表示ビュー
        }

        /// <summary>
        /// コンテナ登録
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //DIコンテナ GetContainerでUnityのコンテナに直接アクセス可能
            var container = containerRegistry.GetContainer();

            //リポジトリの登録
            var assembly = Assembly.GetEntryAssembly();
            //var rootPath = assembly.Location.TrimEnd(assembly.ManifestModule.Name.ToCharArray());
            var rootPath = PathHelper.GetCurrentRootPath("mov");
            var resourcePath = Path.Combine(rootPath, "resources");
            containerRegistry.RegisterInstance<IConfiguratorRepositoryCollection>(new ConfiguratorRepositoryCollection(resourcePath, "json"));
            containerRegistry.RegisterInstance<IDesignerRepositoryCollection>(new DesignerRepositoryCollection(resourcePath, "xml"));
            containerRegistry.RegisterInstance<IAuthorizerRepositoryCollection>(new AuthorizerRepositoryCollection(resourcePath, "json"));
            containerRegistry.RegisterInstance<ITranslatorRepositoryCollection>(new TranslatorRepositoryCollection(resourcePath, "json"));
            containerRegistry.RegisterInstance<IGameRepositoryCollection>(new GameRepositoryCollection(resourcePath, "json"));
            
            //サービスの登録
            containerRegistry.RegisterInstance<IGameService>(Container.Resolve<GameService>());

            //Viewの登録
            containerRegistry.RegisterForNavigation<ConfiguratorView>();
            containerRegistry.RegisterForNavigation<UserSettingTableView>();
            containerRegistry.RegisterForNavigation<AppSettingTableView>();
            containerRegistry.RegisterForNavigation<VariableTableView>();
            containerRegistry.RegisterForNavigation<AuthorizerView>();
            containerRegistry.RegisterForNavigation<DesignerView>();
            containerRegistry.RegisterForNavigation<DesignerTreeView>();
            containerRegistry.RegisterForNavigation<DesignerTableView>();
            containerRegistry.RegisterForNavigation<DesignerShellView>();
            containerRegistry.RegisterForNavigation<DesignerPartsView>();
            containerRegistry.RegisterForNavigation<DesignerThemeView>();
            containerRegistry.RegisterForNavigation<SchedulerView>();
            containerRegistry.RegisterForNavigation<TranslatorView>();
            containerRegistry.RegisterForNavigation<GameMainView>();
            containerRegistry.RegisterForNavigation<GameTitleView>();
            containerRegistry.RegisterForNavigation<GameConfigView>();
            containerRegistry.RegisterForNavigation<GameCanvasView>();
            containerRegistry.RegisterForNavigation<GameView>();

            //Dialogの登録
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();
            containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
            containerRegistry.RegisterDialogWindow<DialogWindow>();

        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        }

        /// <summary>
        /// View-ViewModel関連付け
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<ConfiguratorView, ConfiguratorViewModel>();
            ViewModelLocationProvider.Register<UserSettingTableView, UserSettingTableViewModel>();
            ViewModelLocationProvider.Register<AppSettingTableView, AppSettingTableViewModel>();
            ViewModelLocationProvider.Register<VariableTableView, VariableTableViewModel>();
            ViewModelLocationProvider.Register<AuthorizerView, AuthorizerViewModel>();
            ViewModelLocationProvider.Register<DesignerView, DesignerViewModel>();
            ViewModelLocationProvider.Register<DesignerTreeView, DesignerTreeViewModel>();
            ViewModelLocationProvider.Register<DesignerTableView, DesignerTableViewModel>();
            ViewModelLocationProvider.Register<DesignerShellView, DesignerShellViewModel>();
            ViewModelLocationProvider.Register<DesignerPartsView, DesignerPartsViewModel>();
            ViewModelLocationProvider.Register<DesignerThemeView, DesignerThemeViewModel>();
            ViewModelLocationProvider.Register<SchedulerView, SchedulerViewModel>();
            ViewModelLocationProvider.Register<TranslatorView, TranslatorViewModel>();
            ViewModelLocationProvider.Register<GameMainView, GameMainViewModel>();
            ViewModelLocationProvider.Register<GameView, GameViewModel>();
            ViewModelLocationProvider.Register<GameTitleView, GameTitleViewModel>();
            ViewModelLocationProvider.Register<GameConfigView, GameConfigViewModel>();
            ViewModelLocationProvider.Register<GameCanvasView, GameCanvasViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        #endregion メソッド
    }
}
