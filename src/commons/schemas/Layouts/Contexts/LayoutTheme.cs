using Mov.Schemas.Layouts.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts
{
    public class LayoutTheme
    {
        ThemeStyle Theme { get; }

        public LayoutTheme(ThemeStyle theme)
        {
            this.Theme = theme;
        }
    }
}
