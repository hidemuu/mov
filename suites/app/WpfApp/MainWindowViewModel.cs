using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Shared;

namespace WpfApp
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
