using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Controllers
{
    public interface IPersistenceQueryAsync<T>
    {
        Task<IEnumerable<T>> ReadAsync();

        Task<IEnumerable<T>> GetsAsync();

        Task<IEnumerable<T>> GetsAsync(string param);

        Task<T> GetAsync(Guid id);

        Task<T> GetAsync(string param);

    }
}
