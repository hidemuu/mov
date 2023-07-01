using Mov.Designer.Engine;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using Mov.WpfMvvms;
using Mov.WpfMvvms.Lists;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Linq;
using System.Reflection;

namespace Mov.Designer.ViewModels
{
    public class DesignerShellViewModel : GridListViewModelBase<ShellSchema>
    {
        #region フィールド

        private IDesignerFacade facade;

        #endregion フィールド

        #region コンストラクター

        public DesignerShellViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
        }

        #endregion コンストラクター

        #region 内部メソッド

        protected override void Import(NavigationContext navigationContext)
        {
            this.facade = navigationContext.Parameters[DesignerViewModel.NAVIGATION_PARAM_NAME_SERVICE] as IDesignerFacade;
            this.facade.Read();
        }

        protected override void Export()
        {
            this.facade.Write();
        }

        protected override void BindItems()
        {
            Items.Clear();
            var properties = ShellSchema.GetProperties();
            //foreach (Shell item in this.service.GetShells())
            //{
            //    Items.Add(GetColumnItems(properties.Select(x => x.propertyInfo), item).ToArray());
            //}
            Attributes.Value = GetColumnAttributes(properties.Select(x => x.name)).ToArray();
        }

        protected override void PostItems()
        {
            var shells = GetDbObjects(ShellSchema.GetProperties().Select(x => x.propertyInfo)).ToList();
            foreach (var shell in shells)
            {
                this.facade.Command.Shells.Saver.Save(shell);
            }
        }

        protected override void PutItem()
        {
            this.facade.Command.Shells.Saver.Save(new ShellSchema());
        }

        protected override void DeleteItem()
        {
            //this.service.DeleteShell((Guid)SelectedItem.Value[0].GetValue());
        }

        #endregion 内部メソッド
    }
}