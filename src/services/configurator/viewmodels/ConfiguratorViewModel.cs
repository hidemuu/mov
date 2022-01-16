using Mov.WpfViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Configurator.ViewModels
{
    public class ConfiguratorViewModel : RegionViewModelBase
    {

        public ConfiguratorViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {

        }

    }
}
