using Mov.Accessors.Repository;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.WpfControls.ViewModels;
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

        private readonly IDomainRepositoryCollection<IDesignerRepository> designerDatabase;

        #endregion フィールド

        #region プロパティ

        public IDesignerRepository DesignerRepository { get; }

        #endregion プロパティ

        #region コンストラクター

        public DriverViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IDriverRepository> driverDatabase, IDomainRepositoryCollection<IDesignerRepository> designerDatabase) : base(regionManager, dialogService)
        {
            this.driverDatabase = driverDatabase;
            this.designerDatabase = designerDatabase;
            DesignerRepository = designerDatabase.GetRepository("driver");
        }

        #endregion コンストラクター
    }
}
