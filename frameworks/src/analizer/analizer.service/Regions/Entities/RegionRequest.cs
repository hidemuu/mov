using Mov.Analizer.Models;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Analizer.Service.Regions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Analizer.Service.Regions.Entities
{
    public class RegionRequest
    {
        #region constant

        #endregion constant

        #region property

        public IDictionary<int, List<int>> RegionCodes { get; } = new Dictionary<int, List<int>>();

        public RegionCategory Category { get; }

        public RegionLabel Label { get; }

        #endregion property

        #region constructor

        public RegionRequest(IDictionary<int, List<int>> regionCodes, string category, string label)
        {
            RegionCodes= regionCodes;
            Category = new RegionCategory(category);
            Label = new RegionLabel(label);
        }

        public static class Factory
        {
            public static RegionRequest Create(RegionRequestSchema schema)
            {
                var regions = new Dictionary<int, List<int>>();
                foreach(var prefecture in schema.Prefectures)
                {
                    var cityCodes = new List<int>();
                    foreach(var city in prefecture.CityCodes)
                    {
                        cityCodes.Add(city);
                    }
                    regions.Add(prefecture.PrefCode, cityCodes);
                }
                return new RegionRequest(regions, schema.Flag.Category, schema.Flag.Label);
            }
        }


        #endregion constructor

        #region method

        public RegionRequestSchema CreateSchema()
        {
            var prefectures = new List<PrefectureSchema>();
            foreach(var regionCode in RegionCodes) 
            {
                var prefCode = regionCode.Key;
                var cityCodes = new List<int>();
                foreach(var cityCode in regionCode.Value)
                {
                    cityCodes.Add(cityCode);
                }
                prefectures.Add(new PrefectureSchema() 
                {
                    PrefCode= prefCode,
                    CityCodes= cityCodes,
                });
            }

            return new RegionRequestSchema()
            {
                Prefectures = prefectures,
                Flag = new FlagSchema()
                {
					Category = Category.Value,
					Label = Label.Value,
				}
            };
        }

        #endregion method
    }
}
