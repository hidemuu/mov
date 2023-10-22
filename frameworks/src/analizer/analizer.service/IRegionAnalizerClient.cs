using Mov.Analizer.Models.Entities;
using Mov.Core.Valuables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Analizer.Service
{
    /// <summary>
    /// 地域データ分析クライアント
    /// </summary>
    public interface IRegionAnalizerClient
    {
        Task<IEnumerable<TableLine>> GetTableLineAsync();

        Task<IEnumerable<TimeLine>> GetTimeLineAsync(int prefCode, int cityCode, string category, string label, TimeValue start, TimeValue end);

        Task<IEnumerable<TimeTrend>> GetTimeTrendAsync(int prefCode, int cityCode, string category, string label, TimeValue start, TimeValue end);
    }
}