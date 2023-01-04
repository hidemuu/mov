using Mov.Schemas.Elements.Styles;
using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Creationals.Factories.Themes
{
    public class ReplaceableThemeFactory
    {
        private readonly List<WeakReference<Ref<ThemeStyle>>> themes
      = new List<WeakReference<Ref<ThemeStyle>>>();

        private ThemeStyle createThemeImpl(bool dark)
        {
            return dark ? ThemeStyle.Dark : ThemeStyle.Light;
        }

        public Ref<ThemeStyle> CreateTheme(bool dark)
        {
            var r = new Ref<ThemeStyle>(createThemeImpl(dark));
            themes.Add(new WeakReference<Ref<ThemeStyle>>(r));
            return r;
        }

        public void ReplaceTheme(bool dark)
        {
            foreach (var wr in themes)
            {
                if (wr.TryGetTarget(out var reference))
                {
                    reference.Value = createThemeImpl(dark);
                }
            }
        }
    }
}
