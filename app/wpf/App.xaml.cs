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
using System.Threading.Tasks;
using System.Windows;

namespace Mov.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
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
            var rootPath = assembly.Location.TrimEnd(assembly.ManifestModule.Name.ToCharArray());
            var resourcePath = Path.Combine(rootPath, "Resources");
            containerRegistry.RegisterInstance<IConfiguratorRepositoryCollection>(new ConfiguratorRepositoryCollection(resourcePath, "json"));
            containerRegistry.RegisterInstance<IDesignerRepositoryCollection>(new DesignerRepositoryCollection(resourcePath, "xml"));
            containerRegistry.RegisterInstance<IAuthorizerRepositoryCollection>(new AuthorizerRepositoryCollection(resourcePath, "json"));
            containerRegistry.RegisterInstance<ITranslatorRepositoryCollection>(new TranslatorRepositoryCollection(resourcePath, "json"));

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
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
