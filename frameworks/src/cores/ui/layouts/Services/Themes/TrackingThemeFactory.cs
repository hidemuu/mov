using Mov.Core.Styles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Layouts.Services.Themes
{
    public class TrackingThemeFactory
    {
        private readonly List<WeakReference<ThemeStyle>> themes = new List<WeakReference<ThemeStyle>>();

        public ThemeStyle CreateTheme(bool dark)
        {
            ThemeStyle theme = dark ? ThemeStyle.Dark : ThemeStyle.Light;
            themes.Add(new WeakReference<ThemeStyle>(theme));
            return theme;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var reference in themes)
                {
                    if (reference.TryGetTarget(out var theme))
                    {
                        bool dark = theme.Equals(ThemeStyle.Dark);
                        sb.Append(dark ? "Dark" : "Light")
                          .AppendLine(" theme");
                    }
                }
                return sb.ToString();
            }
        }
    }
}
