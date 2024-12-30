using Mov.Analizer.Models;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Analizer.Service.Regions.Schemas.Contents;
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

        public IEnumerable<PrefectureSchema> Regions { get; } = new List<PrefectureSchema>();

        public RegionCategory Category { get; }

        public RegionLabel Label { get; }

        #endregion property

        #region constructor

        private RegionRequest(IEnumerable<PrefectureSchema> regions, string category, string label)
        {
            Regions= regions;
            Category = new RegionCategory(category);
            Label = new RegionLabel(label);
        }

        public static class Factory
        {
            public static RegionRequest Create(RegionRequestSchema schema)
            {
                return new RegionRequest(schema.Prefectures, schema.Flag.Category, schema.Flag.Label);
            }
        }


        #endregion constructor

        #region method

    //    public RegionRequestSchema CreateSchema()
    //    {
    //        var prefectures = new List<PrefectureSchema>();
    //        foreach(var regionCode in RegionCodes) 
    //        {
    //            var prefCode = regionCode.Key;
    //            var cityCodes = new List<int>();
    //            foreach(var cityCode in regionCode.Value)
    //            {
    //                cityCodes.Add(cityCode);
    //            }
    //            prefectures.Add(new PrefectureSchema() 
    //            {
    //                Code= prefCode,
    //                Cities= cityCodes,
    //            });
    //        }

    //        return new RegionRequestSchema()
    //        {
    //            Prefectures = prefectures,
    //            Flag = new FlagSchema()
    //            {
				//	Category = Category.Value,
				//	Label = Label.Value,
				//}
    //        };
    //    }

        #endregion method
    }
}
