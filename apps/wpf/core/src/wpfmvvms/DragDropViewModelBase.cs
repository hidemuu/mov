using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mov.WpfMvvms
{
    public class DragDropViewModelBase : RegionViewModelBase, INotifyPropertyChanged
    {
        #region プロパティ

        public ReactivePropertySlim<bool> IsDragSource { get; } = new ReactivePropertySlim<bool>(true);

        public ReactivePropertySlim<bool> IsDropTarget { get; } = new ReactivePropertySlim<bool>(true);

        //public DropTargetHandler<DragDropViewModelBase> DropTargetHandler { get; set; } = new DropTargetHandler<DragDropViewModelBase>();

        #endregion プロパティ



        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DragDropViewModelBase(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
            //IsDragSource.Subscribe(OnPropertyChanged);
            //IsDropTarget.Subscribe(OnPropertyChanged);
        }

        #endregion コンストラクター

        #region イベントハンドラ

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion イベントハンドラ

    }
}
