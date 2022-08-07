using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Models
{
    public interface IDrawerDatabase
    {
        IDictionary<string, IDrawerRepository> Repositories { get; }

        IDrawerRepository GetRepository(string dirName);
    }
}
