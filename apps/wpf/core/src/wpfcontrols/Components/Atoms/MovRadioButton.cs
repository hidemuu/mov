using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovRadioButton : RadioButton
    {
        static MovRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovRadioButton), new FrameworkPropertyMetadata(typeof(MovRadioButton)));
        }

    }
}
