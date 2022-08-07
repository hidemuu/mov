using Mov.Designer.Models;
using Mov.WpfControls.ViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerShellViewModel : RegionViewModelBase
    {
        public DesignerShellViewModel(IRegionManager regionManager, IDialogService dialogService) :base(regionManager, dialogService)
        {

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            var repository = navigationContext.Parameters[DesignerViewModel.PARAM_NAME_DESIGN_REPOSITORY] as IDesignerRepository;
        }
    }
}
