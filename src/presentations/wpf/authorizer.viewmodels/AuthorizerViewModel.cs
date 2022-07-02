using Mov.WpfControls.ViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Authorizer.ViewModels
{
    public class AuthorizerViewModel : RegionViewModelBase
    {
        public AuthorizerViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {

        }
    }
}
