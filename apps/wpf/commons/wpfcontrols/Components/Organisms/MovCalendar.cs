using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
