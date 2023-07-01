using Mov.Analizer.Models;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using Mov.Core.Templates.Repositories;

namespace Mov.Analizer.ViewModels
{
    public class AnalizerViewModel : RegionViewModelBase
    {
        #region フィールド

        private readonly IDomainRepositoryCollection<IAnalizerRepository> repositories;

        #endregion フィールド

        #region コンストラクター

        public AnalizerViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IAnalizerRepository> repositories) : base(regionManager, dialogService)
        {
            this.repositories = repositories;
        }

        #endregion コンストラクター
    }
}