using Mov.Core.Accessors.Models;
using Mov.Framework.Services;
using Mov.Game.Models;
using Mov.Game.Repository;
using Mov.Suite.WpfApp.Pages.ViewModels;
using Mov.Suite.WpfApp.Pages.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace Mov.Suite.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        #region field

        private Mutex _mutex = new Mutex(false, "Mov_Suite_WpfApp");

        #endregion field

        #region event

        /// <summary>ApplicationのStartupイベントハンドラ。</summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントデータを格納しているStartupEventArgs。</param>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            if (this._mutex.WaitOne(0, false))
                return;

            MessageBox.Show("二重起動できません。", "情報", MessageBoxButton.OK, MessageBoxImage.Information);
            this._mutex.Close();
            this._mutex = null;
            this.Shutdown();
        }

        /// <summary>ApplicationのExitイベントハンドラ。</summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントデータを格納しているExitEventArgs。</param>
        private void OnExit(object sender, ExitEventArgs e)
        {
            if (this._mutex != null)
            {
                this._mutex.ReleaseMutex();
                this._mutex.Close();
            }
        }

        #endregion event

        #region inner method

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //DIコンテナ GetContainerでUnityのコンテナに直接アクセス可能
            var container = containerRegistry.GetContainer();

            //リポジトリの登録
            var resourcePath = PathCreator.GetResourcePath();
            containerRegistry.RegisterInstance<IGameRepository>(new FileGameRepository(Path.Combine(resourcePath, "game"), FileType.Json, EncodingValue.UTF8));

            //インターフェースとクラスを紐付けて登録
            //container.RegisterType<IHomeService, HomeService>();

            //サービスの登録
            //containerRegistry.RegisterInstance<IGameFacade>(new GameFacade(designerRepositories));

            //Viewの登録
            containerRegistry.RegisterForNavigation<DashboardView>();
            containerRegistry.RegisterForNavigation<GameView>();
            containerRegistry.RegisterForNavigation<WebView>();
            //Dialogの登録
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
            ViewModelLocationProvider.Register<DashboardView, DashboardViewModel>();
            ViewModelLocationProvider.Register<GameView, GameViewModel>();
            ViewModelLocationProvider.Register<WebView, WebViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        #endregion inner method
    }
}
