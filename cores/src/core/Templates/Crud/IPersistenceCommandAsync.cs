using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Templates.Crud
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