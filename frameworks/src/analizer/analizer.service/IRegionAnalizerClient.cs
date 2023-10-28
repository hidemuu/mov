using Mov.Analizer.Models.Entities;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Service.Regions;
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
        Task<IEnumerable<TableLineSchema>> GetTableLineAsync();

        Task<IEnumerable<TimeLineSchema>> GetTimeLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end);

        Task<IEnumerable<TrendLineSchema>> GetTrendLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end);
    }
}