using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Repository
{
    public interface IDbObjectRepository<T> where T : DbObject
    {
        IEnumerable<T> Gets();

        void Post(T item);
    }
}
