using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class LayoutTable : DatabaseObject
    {
        public override string ToString() => Id + DatabaseObject.SPACE + Code;
    }
}
