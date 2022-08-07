using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Drawer.Models
{
    public interface IDrawerRepository
    {
        IRepository<DrawItem, DrawItemCollection> DrawItems { get; }
    }
}
