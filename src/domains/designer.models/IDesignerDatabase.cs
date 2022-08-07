using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerDatabase
    {
        IDictionary<string, IDesignerRepository> Repositories { get; }

        IDesignerRepository GetRepository(string dirName);
    }
}
