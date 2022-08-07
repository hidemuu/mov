using Mov.WpfControls.ViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Bom.ViewModels
{
    public class BomViewModel : RegionViewModelBase
    {
        public BomViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {

        }
    }
}
