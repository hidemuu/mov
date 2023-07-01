using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Molecules
{
    public class MovSpinBox : TextBox
    {
        static MovSpinBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovSpinBox), new FrameworkPropertyMetadata(typeof(MovSpinBox)));
        }

    }
}
