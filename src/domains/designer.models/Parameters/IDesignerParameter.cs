using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Parameters
{
    public interface IDesignerParameter
    {
        IDesignerCommand Command { get; }

        IDesignerQuery Query { get; }
    }
}
