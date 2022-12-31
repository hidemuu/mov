using Mov.Designer.Models;
using Mov.WpfMvvms;
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

        private IDesignerService service;

        #endregion フィールド

        #region コンストラクター

        public DesignerShellViewModel(IRegionManager regionManager, IDialogService dialogService) :base(regionManager, dialogService)
        {

        }

        #endregion コンストラクター

        #region 内部メソッド

        protected override void Import(NavigationContext navigationContext)
        {
            this.service = navigationContext.Parameters[DesignerViewModel.NAVIGATION_PARAM_NAME_SERVICE] as IDesignerService;
            this.service.Read();
        }

        protected override void Export()
        {
            this.service.Write();
        }

        protected override void BindItems()
        {
            Items.Clear();
            var properties = Shell.GetProperties();
            //foreach (Shell item in this.service.GetShells())
            //{
            //    Items.Add(GetColumnItems(properties.Select(x => x.propertyInfo), item).ToArray());
            //}
            Attributes.Value = GetColumnAttributes(properties.Select(x => x.name)).ToArray();
        }

        

        protected override void PostItems()
        {
            var configs = GetDbObjects(Shell.GetProperties().Select(x => x.propertyInfo)).ToList();
            this.service.PostShells(configs);
        }

        protected override void PutItem()
        {
            this.service.PostShell(new Shell());
        }

        protected override void DeleteItem()
        {
            //this.service.DeleteShell((Guid)SelectedItem.Value[0].GetValue());
        }

        
        #endregion 内部メソッド

    }
}
