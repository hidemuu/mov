using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public interface IRepository<TModel>
    {
        Task<IEnumerable<TModel>> GetAsync();

        Task<TModel> GetAsync(string param);

        Task PostAsync(TModel item);
    }
}
