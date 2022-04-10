using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class ThemeCollection : DbObjectCollection<Theme>
    {
        public override Theme[] Items { get; set; }
    }

    public class Theme : DbObject
    {
    }
}
