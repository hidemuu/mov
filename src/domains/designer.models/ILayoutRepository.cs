using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.Models
{
    public interface ILayoutRepository
    {
        LayoutTree Get();
    }
}
