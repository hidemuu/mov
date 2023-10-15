using Mov.Suite.WpfApp.Shared;
using Microsoft.Web.WebView2.Core;
using System.ComponentModel;
using System;

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
            WebViewSource = "file://" + AppDomain.CurrentDomain.BaseDirectory + "build/index.html";
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
