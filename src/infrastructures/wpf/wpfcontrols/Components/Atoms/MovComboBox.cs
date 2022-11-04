using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
