using System;
using System.Collections.Generic;
using System.Text;

namespace Designer.Models
{
    public interface IDesignerRepository
    {
        ILayoutRepository Layouts { get; }
    }
}
