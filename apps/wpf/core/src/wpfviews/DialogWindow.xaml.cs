using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace Mov.WpfViews
{
    /// <summary>
    /// DialogWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogWindow : Window, IDialogWindow
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {

        }

        public IDialogResult Result { get; set; }
    }
}
