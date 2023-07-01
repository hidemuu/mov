using Mov.Core.Layouts.Models.Themes.ValueObjects;

namespace Mov.Core.Layouts.Models.Themes.Entities
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