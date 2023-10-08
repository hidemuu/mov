using Mov.Suite.WpfApp.Shared;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Mov.Suite.WpfApp.Pages.ViewModels
{
    public class DashboardViewModel : RegionViewModelBase
    {
        #region constructor

        public DashboardViewModel(IRegionManager regionManager, IDialogService dialogService)
            : base(regionManager, dialogService)
        {
        }

        #endregion constructor

        #region event

        protected override void OnLoaded()
        {

        }

        #endregion event
    }
}
