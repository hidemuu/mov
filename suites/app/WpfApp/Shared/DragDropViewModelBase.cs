using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Suite.WpfApp.Shared
{
    public class DragDropViewModelBase : RegionViewModelBase, INotifyPropertyChanged
    {
        #region property

        public ReactivePropertySlim<bool> IsDragSource { get; } = new ReactivePropertySlim<bool>(true);

        public ReactivePropertySlim<bool> IsDropTarget { get; } = new ReactivePropertySlim<bool>(true);

        //public DropTargetHandler<DragDropViewModelBase> DropTargetHandler { get; set; } = new DropTargetHandler<DragDropViewModelBase>();

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DragDropViewModelBase(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
            //IsDragSource.Subscribe(OnPropertyChanged);
            //IsDropTarget.Subscribe(OnPropertyChanged);
        }

        #endregion constructor

        #region event

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion event

    }
}
