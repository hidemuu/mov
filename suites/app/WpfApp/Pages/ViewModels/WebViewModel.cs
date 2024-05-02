using Mov.Suite.WpfApp.Shared;
using Microsoft.Web.WebView2.Core;
using System.ComponentModel;
using System;
using Mov.Framework.Services;
using System.IO;
using Mov.Core.Configurators.Contexts;
using System.Linq;

namespace Mov.Suite.WpfApp.Pages.ViewModels
{
    public class WebViewModel : ViewModelBase
    {

        #region property

        private Uri webViewSource = new Uri("https://www.example.com");

		public Uri WebViewSource
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
			var userSettings = ConfiguratorContext.Current.Service.UserSettingQuery.Reader.ReadAll().ToArray();
            var reactPath = userSettings.FirstOrDefault(x => x.Code.Value.Equals("react_path"));
            var clientPath = userSettings.FirstOrDefault(x => x.Code.Value.Equals("client_path"));
			if (clientPath != null)
            {
				var path = Path.Combine(PathCreator.GetSolutionPath(), clientPath.Value) ?? AppDomain.CurrentDomain.BaseDirectory;
				var fullPath = @"file:///" + path;
				WebViewSource = new Uri(fullPath);
				return;
            }
            else if(reactPath != null)
            {
				WebViewSource = new Uri("http://localhost:5000");
				return;
			}
            else
            {
				var path = Path.Combine(PathCreator.GetSolutionPath(), "scripts", "html", "index.html") ?? AppDomain.CurrentDomain.BaseDirectory;
				var fullPath = @"file:///" + path;
				WebViewSource = new Uri(fullPath);
			}
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
