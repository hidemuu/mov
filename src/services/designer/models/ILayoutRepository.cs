using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Designer.Models
{
    public interface ILayoutRepository
    {
        LayoutTree Get();
    }
}
