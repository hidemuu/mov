using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovTextBox : TextBox
    {
        static MovTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovTextBox), new FrameworkPropertyMetadata(typeof(MovTextBox)));
        }

    }
}
