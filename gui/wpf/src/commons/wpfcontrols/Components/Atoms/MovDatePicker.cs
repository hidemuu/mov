using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovDatePicker : DatePicker
    {
        static MovDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovDatePicker), new FrameworkPropertyMetadata(typeof(MovDatePicker)));
        }

    }
}
