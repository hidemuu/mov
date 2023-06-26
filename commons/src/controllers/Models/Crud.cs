using System;
using System.Collections.Generic;
using System.Text;
using Mov.Utilities.Templates.Crud;

namespace Mov.Controllers.Models
{
    public class Crud<T> : IRead<T>, ISave<T>, IDelete<T>
    {
        public T Read(Guid id)
        {
            return default;
        }

        public IEnumerable<T> ReadAll()
        {
            return new List<T>();
        }

        public void Save(T entity)
        {

        }

        public void Delete(T entity)
        {

        }
    }
}
