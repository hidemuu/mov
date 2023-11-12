using Mov.Suite.WpfApp.Shared;
using Microsoft.Web.WebView2.Core;
using System.ComponentModel;
using System;
using Mov.Framework.Services;
using System.IO;

namespace Mov.Suite.WpfApp.Pages.ViewModels
{
    public class WebViewModel : ViewModelBase
    {

        #region property

        private string webViewSource = @"https://www.example.com";

        public string WebViewSource
        {
            get { return webViewSource; }
            set
            {
                webViewSource = value;
                OnPropertyChanged(new PropertyChangedEventArgs("WebViewSource"));
            }
        }

        #endregion property

        #region constructor

        public WebViewModel() 
        {
			var path = Path.Combine(PathCreator.GetSolutionPath(), "scripts", "html", "index.html") ?? AppDomain.CurrentDomain.BaseDirectory;
            var fullPath = @"file:///" + path;
			WebViewSource = fullPath;
        }

        #endregion constructor

        #region event handler

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
        }

        #endregion event hendler
    }
}
