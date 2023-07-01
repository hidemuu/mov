using Microsoft.Web.WebView2.Core;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfWebs
{
    /// <summary>
    /// WebControl.xaml の相互作用ロジック
    /// </summary>
    public partial class WebControl : UserControl
    {
        public WebControl()
        {
            InitializeComponent();
            webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webView.CoreWebView2.Navigate("https://www.example.com");
            MessageBox.Show("ページが読み込まれました。");
        }
    }
}
