using Mov.Accessors.Repository;
using Mov.Analizer.Models;
using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Analizer.ViewModels
{
    public class AnalizerViewModel : RegionViewModelBase
    {
        #region フィールド

        private readonly IDomainRepositoryCollection<IAnalizerRepository> repositories;

        #endregion フィールド

        #region プロパティ



        #endregion プロパティ

        #region コンストラクター

        public AnalizerViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IAnalizerRepository> repositories) : base(regionManager, dialogService)
        {
            this.repositories = repositories;
        }

        #endregion コンストラクター
    }
}
