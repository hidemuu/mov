using Mov.Suite.WpfApp.Shared;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
