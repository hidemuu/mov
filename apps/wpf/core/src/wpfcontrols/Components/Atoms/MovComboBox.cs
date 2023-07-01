using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovComboBox : ComboBox
    {
        static MovComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovComboBox), new FrameworkPropertyMetadata(typeof(MovComboBox)));
        }

    }
}
