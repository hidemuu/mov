using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();

        Task<T> GetAsync(string param);

        Task PostAsync(T item);
    }
}
