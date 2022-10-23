using Mov.Accessors.Repository;
using Mov.Driver.Models;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Driver.ViewModels
{
    public class DriverViewModel : RegionViewModelBase
    {
        #region フィールド

        private readonly IDomainRepositoryCollection<IDriverRepository> driverDatabase;

        #endregion フィールド

        #region プロパティ

        

        #endregion プロパティ

        #region コンストラクター

        public DriverViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IDriverRepository> driverDatabase) : base(regionManager, dialogService)
        {
            this.driverDatabase = driverDatabase;
        }

        #endregion コンストラクター
    }
}
