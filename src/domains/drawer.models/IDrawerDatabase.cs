using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Models
{
    public interface IDrawerDatabase
    {
        IRepository<DrawItem, DrawItemCollection> DrawItems { get; }
    }
}
