using System.Threading.Tasks;

namespace Mov.Core.Accessors.Services.Serializer
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
