using Microsoft.AspNetCore.Mvc;
using Mov.Analizer.Service.Regions.Schemas.Contents;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Analizer.Service;
using Mov.Core.Valuables;

namespace Mov.Suite.Api.Controllers.Analizers.Regions
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/analizers/regions/[controller]")]
    [ApiController]
    public class TimeLineController : Controller
    {
        #region field

        private readonly IRegionAnalizerClient _client;

        #endregion field

        #region constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public TimeLineController(IRegionAnalizerClient client)
        {
            _client = client;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet("{prefCode}/{cityCode}/{category}/{label}/{start}/{end}")]
        public async Task<IActionResult> Get(int prefCode, int cityCode, string category, string label, string srart, string end)
        {
            var prefecture = (await _client.GetPrefectureTableLineAsync()).Results.FirstOrDefault(x => x.Id.Equals(prefCode));
            var city = (await _client.GetCityTableLineAsync()).Results.FirstOrDefault(x => x.Id.Equals(cityCode));

            return Ok(await _client.GetTimeLineAsync(
                new RegionRequestSchema()
                {
                    Prefectures = new List<PrefectureSchema>()
                    {
                        new PrefectureSchema()
                        {
                            Code = prefCode,
                            Name = prefecture?.Name ?? string.Empty,
                            Cities = new List<CitySchema>{
                                new CitySchema()
                                {
                                    Code = cityCode,
                                    Name = city?.Name ?? string.Empty
                                }
                            },
                        }
                    },
                    Flag = new FlagSchema()
                    {
                        Category = category,
                        Label = label
                    },
                },
                TimeValue.Factory.Create(srart),
                TimeValue.Factory.Create(end)
            ));
        }

        #endregion method
    }
}
