using Mov.Core.Models.ValueObjects.Layouts;

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