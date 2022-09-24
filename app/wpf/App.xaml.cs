using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Configurator.ViewModels;
using Mov.Configurator.Views;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.Designer.ViewModels;
using Mov.Designer.Views;
using Mov.Game.Models;
using Mov.Game.Repository;
using Mov.Game.Service;
using Mov.Game.ViewModels;
using Mov.Game.Views;
using Mov.Scheduler.ViewModels;
using Mov.Scheduler.Views;
using Mov.Utilities;
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
using Mov.Game.Views.Dialogs;
using Mov.Game.ViewModels.Dialogs;
using Mov.Game.Service.Machine;
using Mov.WpfControls.Views.Dialogs;
using Mov.WpfControls.ViewModels.Dialogs;
using Mov.WpfControls.Views;
using Mov.Drawer.Models;
using Mov.Drawer.Repository;
using Mov.Drawer.Views;
using Mov.Drawer.ViewModels;
using Mov.Driver.Views;
using Mov.Bom.Views;
using Mov.Driver.ViewModels;
using Mov.Bom.ViewModels;
using Mov.Driver.Models;
using Mov.Driver.Repository;
using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Implement;
using Mov.UseCases.Factories;
using Mov.Accessors;
using Mov.UseCases;
using Mov.Framework;

namespace Mov.WpfApp
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

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
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
            var repositoryFactory = new FileDomainRepositoryCollectionFactory(PathCreator.GetResourcePath());
            containerRegistry.RegisterInstance<IDomainRepositoryCollection<IConfiguratorRepository>>(
                repositoryFactory.Create<IConfiguratorRepository>(SerializeConstants.PATH_JSON));
            containerRegistry.RegisterInstance<IDomainRepositoryCollection<IDesignerRepository>>(
                repositoryFactory.Create<IDesignerRepository>(SerializeConstants.PATH_XML));
            containerRegistry.RegisterInstance<IDomainRepositoryCollection<IGameRepository>>(
                repositoryFactory.Create<IGameRepository>(SerializeConstants.PATH_JSON));
            containerRegistry.RegisterInstance<IDomainRepositoryCollection<IDrawerRepository>>(
                repositoryFactory.Create<IDrawerRepository>(SerializeConstants.PATH_JSON));
            containerRegistry.RegisterInstance<IDomainRepositoryCollection<IDriverRepository>>(
                repositoryFactory.Create<IDriverRepository>(SerializeConstants.PATH_JSON));

            //サービスの登録
            containerRegistry.RegisterInstance<IMachineGameService>(Container.Resolve<PackmanGameService>());

            //Viewの登録
            containerRegistry.RegisterForNavigation<ConfiguratorView>();
            containerRegistry.RegisterForNavigation<DesignerView>();
            containerRegistry.RegisterForNavigation<DesignerTreeView>();
            containerRegistry.RegisterForNavigation<DesignerTableView>();
            containerRegistry.RegisterForNavigation<DesignerShellView>();
            containerRegistry.RegisterForNavigation<DesignerPartsView>();
            containerRegistry.RegisterForNavigation<DesignerThemeView>();
            containerRegistry.RegisterForNavigation<SchedulerView>();
            containerRegistry.RegisterForNavigation<GameView>();
            containerRegistry.RegisterForNavigation<GameTitleView>();
            containerRegistry.RegisterForNavigation<GameSoftView>();
            containerRegistry.RegisterForNavigation<DrawerView>();
            containerRegistry.RegisterForNavigation<DriverView>();
            containerRegistry.RegisterForNavigation<BomView>();

            //Dialogの登録
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();
            containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
            containerRegistry.RegisterDialog<GameOverDialog, GameOverDialogViewModel>();
            containerRegistry.RegisterDialog<StageClearDialog, StageClearDialogViewModel>();
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

            //自動紐づけの命名規則を定義
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(vt =>
            {
                var viewName = vt.FullName;
                var viewKey = "View";
                if (viewName.EndsWith(viewKey)) viewName = viewName.Substring(0, viewName.Length - viewKey.Length);
                var assemblyName = vt.GetTypeInfo().Assembly.FullName;
                var viewModelName = $"{viewName}ViewModel, {assemblyName}";

                return Type.GetType(viewModelName);
            });

            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<ConfiguratorView, ConfiguratorViewModel>();
            ViewModelLocationProvider.Register<DesignerView, DesignerViewModel>();
            ViewModelLocationProvider.Register<DesignerTreeView, DesignerTreeViewModel>();
            ViewModelLocationProvider.Register<DesignerTableView, DesignerTableViewModel>();
            ViewModelLocationProvider.Register<DesignerShellView, DesignerShellViewModel>();
            ViewModelLocationProvider.Register<DesignerPartsView, DesignerPartsViewModel>();
            ViewModelLocationProvider.Register<DesignerThemeView, DesignerThemeViewModel>();
            ViewModelLocationProvider.Register<SchedulerView, SchedulerViewModel>();
            ViewModelLocationProvider.Register<GameView, GameViewModel>();
            ViewModelLocationProvider.Register<GameSoftView, GameSoftViewModel>();
            ViewModelLocationProvider.Register<GameTitleView, GameTitleViewModel>();
            ViewModelLocationProvider.Register<DrawerView, DrawerViewModel>();
            ViewModelLocationProvider.Register<DriverView, DriverViewModel>();
            ViewModelLocationProvider.Register<BomView, BomViewModel>();
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
