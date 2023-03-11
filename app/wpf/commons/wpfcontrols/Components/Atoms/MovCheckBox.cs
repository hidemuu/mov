using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
