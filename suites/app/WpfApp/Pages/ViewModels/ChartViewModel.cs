using Mov.Suite.WpfApp.Shared;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Mov.Suite.WpfApp.Pages.ViewModels
{
    public class ChartViewModel : RegionViewModelBase
    {
        #region constructor

        public ChartViewModel(IRegionManager regionManager, IDialogService dialogService)
            : base(regionManager, dialogService)
        {
        }

        #endregion constructor
    }
}
