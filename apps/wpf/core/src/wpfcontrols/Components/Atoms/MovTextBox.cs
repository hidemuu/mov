using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovTextBox : TextBox
    {
        static MovTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovTextBox), new FrameworkPropertyMetadata(typeof(MovTextBox)));
        }

    }
}
