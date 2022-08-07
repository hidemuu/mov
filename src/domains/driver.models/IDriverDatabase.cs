using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IDriverDatabase
    {
        IDictionary<string, IDriverRepository> Repositories { get; }

        IDriverRepository GetRepository(string dirName);
    }
}
