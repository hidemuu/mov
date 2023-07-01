using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovLabel : Label
    {
        static MovLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovLabel), new FrameworkPropertyMetadata(typeof(MovLabel)));
        }

    }
}
