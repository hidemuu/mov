using Mov.Core.Graphicers.Services.Controllers;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;
using WpfApp.Shared;

namespace WpfApp.Pages.ViewModels
{
    public class GameViewModel : GraphicViewModelBase
    {
        #region field

        #endregion field

        #region property

        public GameStatusModel StatusModel { get; }

        protected override GraphicControllerBase Controller { get; }

        #endregion property

        #region constructor

        public GameViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
        }

        #endregion constructor
    }
}
