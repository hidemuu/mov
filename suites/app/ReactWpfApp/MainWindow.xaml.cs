using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Core;

namespace Mov.Suite.ReactWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

		public MainWindow()
        {
			InitializeComponent();
			webview.NavigationStarting += WebView_NavigationStarting;

			// WebView2 の初期化
			InitializeAsync();
		}

		private async void InitializeAsync()
		{
			await webview.EnsureCoreWebView2Async(null);
		}

		private void WebView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
		{
			// React アプリケーションのビルド出力の index.html などを読み込む
			if (e.Uri.StartsWith("file://"))
			{
				e.Cancel = true;
				string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
				string indexPath = System.IO.Path.Combine(appPath, "build/index.html");
				webview.CoreWebView2.Navigate(indexPath);
			}
		}
	}
}
