using Mov.Driver.Models;
using Mov.Repositories.Services;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Mov.Driver.ViewModels
{
    public class DriverViewModel : RegionViewModelBase
    {
        #region フィールド

        private readonly IDomainRepositoryCollection<IDriverRepository> driverDatabase;

        #endregion フィールド

        #region コンストラクター

        public DriverViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IDriverRepository> driverDatabase) : base(regionManager, dialogService)
        {
            this.driverDatabase = driverDatabase;
        }

        #endregion コンストラクター
    }
}