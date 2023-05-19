using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors.Services.Serializer
{
    /// <summary>
    /// シリアライザーのインターフェース
    /// </summary>
    public interface ISerializerAsync
    {
        Task<TResponse> GetAsync<TResponse>(string url);

        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest body);

        Task DeleteAsync(string url, string key);
    }
}
