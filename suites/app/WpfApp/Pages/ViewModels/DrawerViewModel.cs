using Mov.Core.Graphicers.Services.Controllers;
using Mov.Suite.WpfApp.Shared;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Suite.WpfApp.Pages.ViewModels
{
    public class DrawerViewModel : DrawViewModelBase
    {
        #region property

        protected override GraphicControllerBase Service { get; set; }

        public ReactiveCollection<string> Canvases { get; } = new ReactiveCollection<string>();

        public ReactivePropertySlim<string> SelectedCanvas { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<double> RefleshRate { get; } = new ReactivePropertySlim<double>();

        #endregion property

        #region command

        public ReactiveCommand DrawCommand { get; } = new ReactiveCommand();

        public ReactiveCommand StopCommand { get; } = new ReactiveCommand();

        #endregion command

        #region constructor

        public DrawerViewModel(IRegionManager regionManager, IDialogService dialogService) 
            : base(regionManager, dialogService)
        {
        }

        #endregion constructor

        #region event

        private void OnDrawCommand()
        {
            Stop();
            UpdateService(SelectedCanvas.Value);
            Start();
        }

        private void OnStopCommand()
        {
            Stop();
        }

        private void UpdateService(string category)
        {

        }

        #endregion event

        #region method

        private void CreateService()
        {
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Next()
        {
            base.Next();
        }

        #endregion method

    }
}
