using Mov.Designer.Models;
using Mov.WpfControls;
using Mov.WpfControls.ViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerShellViewModel : GridListViewModelBase<Shell>
    {
        #region フィールド

        private IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public DesignerShellViewModel(IRegionManager regionManager, IDialogService dialogService) :base(regionManager, dialogService)
        {

        }

        #endregion コンストラクター

        #region 内部メソッド

        protected override void Import(NavigationContext navigationContext)
        {
            this.repository = navigationContext.Parameters[DesignerViewModel.NAVIGATION_PARAM_NAME_REPOSITORY] as IDesignerRepository;
            this.repository.Shells.Import();
        }

        protected override void Export()
        {
            this.repository.Shells.Export();
        }

        protected override void BindItems()
        {
            Items.Clear();
            var properties = Shell.GetProperties();
            foreach (Shell item in this.repository?.Shells?.Gets())
            {
                Items.Add(GetColumnItems(properties.Select(x => x.propertyInfo), item).ToArray());
            }
            Attributes.Value = GetColumnAttributes(properties.Select(x => x.name)).ToArray();
        }

        

        protected override void PostItems()
        {
            var configs = GetDbObjects(Shell.GetProperties().Select(x => x.propertyInfo)).ToList();
            this.repository?.Shells.Posts(configs);
        }

        protected override void PutItem()
        {
            repository.Shells.Put(new Shell());
        }

        protected override void DeleteItem()
        {
            repository.Shells.Delete((Guid)SelectedItem.Value[0].GetValue());
        }

        
        #endregion 内部メソッド

    }
}
