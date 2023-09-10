using Mov.Core.Templates.Crud;
using System;
using System.Collections.Generic;

namespace Mov.Core.Functions.Cruds
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
