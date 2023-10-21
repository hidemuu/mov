using Mov.Core.Valuables;
using System.Threading.Tasks;

namespace Mov.Analizer.Service
{
    /// <summary>
    /// 地域データ分析クライアント
    /// </summary>
    public interface IRegionAnalizerClient
    {
        Task UpdateTableAsync();

        Task GetTimeLineAsync(int prefCode, int cityCode, TimeValue start, TimeValue end);

        Task GetTimeTrendAsync(int prefCode, int cityCode, TimeValue start, TimeValue end);
    }
}