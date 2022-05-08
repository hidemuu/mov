using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Repository
{
    public interface IRepository<T> where T : DbObject
    {
        IEnumerable<T> Gets();

        void Post(T item);
    }
}
