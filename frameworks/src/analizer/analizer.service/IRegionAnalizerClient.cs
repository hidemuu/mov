using System.Threading.Tasks;

namespace Mov.Analizer.Service
{
    /// <summary>
    /// 地域データ分析クライアント
    /// </summary>
    public interface IRegionAnalizerClient
    {
        Task UpdateTableAsync();

        Task UpdateTimeLineAsync();

        Task UpdateTimeTrendAsync();
    }
}