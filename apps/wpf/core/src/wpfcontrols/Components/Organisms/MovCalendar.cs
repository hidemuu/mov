using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Organisms
{
    public class MovCalendar : Calendar
    {
        static MovCalendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovCalendar), new FrameworkPropertyMetadata(typeof(MovCalendar)));
        }
    }
}
