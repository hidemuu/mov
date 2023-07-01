using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovCheckBox : CheckBox
    {
        static MovCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovCheckBox), new FrameworkPropertyMetadata(typeof(MovCheckBox)));
        }

    }
}
