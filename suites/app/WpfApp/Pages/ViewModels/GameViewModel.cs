using Mov.Core.Graphicers.Services.Controllers;
using Mov.Suite.WpfApp.Models;
using Mov.Suite.WpfApp.Shared;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Mov.Suite.WpfApp.Pages.ViewModels
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
