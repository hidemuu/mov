using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
