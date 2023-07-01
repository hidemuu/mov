using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovLamp : Label
    {
        static MovLamp()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovLamp), new FrameworkPropertyMetadata(typeof(MovLamp)));
        }

    }
}
