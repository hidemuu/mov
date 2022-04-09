using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IShellLayoutRepository
    {
        IEnumerable<ShellLayout> Gets();

        ShellLayout Get();
    }
}
