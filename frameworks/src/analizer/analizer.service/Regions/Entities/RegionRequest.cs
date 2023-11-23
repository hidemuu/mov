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

        public IEnumerable<int> PrefCodes { get; }

        public IEnumerable<int> CityCodes { get; }

        public RegionCategory Category { get; }

        public RegionLabel Label { get; }

        #endregion property

        #region constructor

        public RegionRequest(IEnumerable<int> prefCodes, IEnumerable<int> cityCodes, string category, string label)
        {
            PrefCodes = prefCodes;
            CityCodes = cityCodes;
            Category = new RegionCategory(category);
            Label = new RegionLabel(label);
        }

        public static class Factory
        {
            public static RegionRequest Create(RegionRequestSchema schema)
            {
                return new RegionRequest(schema.PrefCodes, schema.CityCodes, schema.Category, schema.Label);
            }

            //public static RegionRequest Create(IEnumerable<string> pref, IEnumerable<string> cities, string category, string label, IAnalizerQuery query)
            //{
            //    var prefCodes = new List<int>();
            //    List<int> cityCodes = new List<int>();
            //    var tableLines = query.TableLines.Reader.ReadAll();
            //    foreach (var tableLine in tableLines)
            //    {
            //        if (tableLine.Category.Equals(RegionCategory.Prefecture.Value) && tableLine.Content.Equals(pref))
            //        {
            //            prefCodes.Add(tableLine.Id);
            //        }
            //        if (tableLine.Category.Equals(RegionCategory.City.Value) && tableLine.Content.Equals(cities.ToArray()[0]))
            //        {
            //            cityCodes.Add(tableLine.Id);
            //        }
            //    }
            //    return new RegionRequest(prefCodes, cityCodes, category, label);
            //}
        }


        #endregion constructor

        #region method

        public RegionRequestSchema CreateSchema()
        {
            return new RegionRequestSchema()
            {
                PrefCodes = PrefCodes.ToList(),
                CityCodes = CityCodes.ToList(),
                Category = Category.Value,
                Label = Label.Value,
            };
        }

        #endregion method
    }
}
