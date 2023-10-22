using Mov.Analizer.Models.Entities;
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
        Task<IEnumerable<TableLine>> GetTableLineAsync();

        Task<IEnumerable<TimeLine>> GetTimeLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end);

        Task<IEnumerable<TimeTrend>> GetTimeTrendAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end);
    }
}