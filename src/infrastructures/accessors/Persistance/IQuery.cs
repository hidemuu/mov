using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Persistance
{
    public interface IQuery<T>
    {
        IEnumerable<T> GetAll();

        T Get(Guid id);

        IEnumerable<T> FindByCriteria(string criteria);
    }
}
