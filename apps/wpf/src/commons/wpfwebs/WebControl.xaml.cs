using Microsoft.Web.WebView2.Core;
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
