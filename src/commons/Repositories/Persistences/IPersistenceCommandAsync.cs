using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Controllers.Repository.Persistences
{
    public interface IPersistenceCommandAsync<T>
    {
        Task WriteAsync();

        Task PostsAsync(IEnumerable<T> items);

        Task PostAsync(T item);

        Task PutAsync(T item);

        Task DeleteAsync(T item);
    }
}
