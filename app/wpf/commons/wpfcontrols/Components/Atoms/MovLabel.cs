using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
