using Mov.Analizer.Models;
using Mov.Analizer.Service.Regions.Schemas;
using Mov.Analizer.Service.Regions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Entities
{
    public class RegionRequest
    {
        #region constant

        #endregion constant

        #region property

        public int PrefCode { get; }

        public int CityCode { get; }

        public RegionCategory Category { get; }

        public RegionLabel Label { get; }

        #endregion property

        #region constructor

        public RegionRequest(int prefCode, int cityCode, string category, string label)
        {
            PrefCode = prefCode;
            CityCode = cityCode;
            Category = new RegionCategory(category);
            Label = new RegionLabel(label);
        }

        public static class Factory
        {
            public static RegionRequest Create(RegionRequestSchema schema)
            {
                return new RegionRequest(schema.PrefCode, schema.CityCode, schema.Category, schema.Label);
            }

            public static RegionRequest Create(string pref, string city, string category, string label, IAnalizerStoreQuery query)
            {
                int prefCode = -1;
                int cityCode = -1;
                var tableLines = query.TableLines.Reader.ReadAll();
                foreach (var tableLine in tableLines)
                {
                    if (tableLine.Category.Equals(RegionCategory.Prefecture.Value) && tableLine.Content.Equals(pref))
                    {
                        prefCode = tableLine.Id;
                    }
                    if (tableLine.Category.Equals(RegionCategory.City.Value) && tableLine.Content.Equals(city))
                    {
                        cityCode = tableLine.Id;
                    }
                    if (prefCode >= 0 && cityCode >= 0)
                    {
                        break;
                    }
                }
                return new RegionRequest(prefCode, cityCode, category, label);
            }
        }


        #endregion constructor

        #region method

        public RegionRequestSchema CreateSchema()
        {
            return new RegionRequestSchema()
            {
                PrefCode = PrefCode,
                CityCode = CityCode,
                Category = Category.Value,
                Label = Label.Value,
            };
        }

        #endregion method
    }
}
