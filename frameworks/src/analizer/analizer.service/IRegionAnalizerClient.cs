using Mov.Analizer.Models.Entities;
using Mov.Analizer.Models.Schemas;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Core.Repositories.Schemas.Responses;
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
        Task<DbResponseSchema<string, TableLineSchema>> GetTableLineAsync();

        Task<DbResponseSchema< string, TableLineSchema>> GetPrefectureTableLineAsync();

		Task<DbResponseSchema<string, TableLineSchema>> GetCityTableLineAsync();

		Task<DbResponseSchema<string, TableLineSchema>> GetCityTableLineAsync(int prefCode);

		Task<DbResponseSchema<string, TimeLineSchema>> GetTimeLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end);

        Task<DbResponseSchema<string, RegionResponseSchema<TrendLineSchema>>> GetTrendLineAsync(RegionRequestSchema requestSchema, TimeValue start, TimeValue end);

        Task<DbResponseSchema<string, StatisticLineSchema>> GetStatisticLineAsync();

        Task<DbResponseSchema<string, HistgramLineSchema>> GetHistgramLineAsync();
    }
}