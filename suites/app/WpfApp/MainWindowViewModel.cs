using Mov.Suite.WpfApp.Shared;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Mov.Suite.WpfApp
{
    public class MainWindowViewModel : RegionViewModelBase
    {
        #region constructor

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
            : base(regionManager, dialogService)
        {
        }

        #endregion constructor
    }
}
