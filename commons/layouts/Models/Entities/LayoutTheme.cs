using Mov.Layouts.Models.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Models.Entities
{
    public class LayoutTheme
    {
        ThemeStyle Theme { get; }

        public LayoutTheme(ThemeStyle theme)
        {
            Theme = theme;
        }
    }
}
