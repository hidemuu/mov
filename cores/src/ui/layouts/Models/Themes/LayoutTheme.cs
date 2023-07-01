using Mov.Core.Contexts.Layouts.ValueObjects;

namespace Mov.Core.Layouts.Models.Themes
{
    public class LayoutTheme
    {
        private ThemeStyle Theme { get; }

        public LayoutTheme(ThemeStyle theme)
        {
            Theme = theme;
        }
    }
}