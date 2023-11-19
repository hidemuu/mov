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

        public int PrefCode { get; }

        public IEnumerable<int> CityCodes { get; }

        public RegionCategory Category { get; }

        public RegionLabel Label { get; }

        #endregion property

        #region constructor

        public RegionRequest(int prefCode, IEnumerable<int> cityCodes, string category, string label)
        {
            PrefCode = prefCode;
            CityCodes = cityCodes;
            Category = new RegionCategory(category);
            Label = new RegionLabel(label);
        }

        public static class Factory
        {
            public static RegionRequest Create(RegionRequestSchema schema)
            {
                return new RegionRequest(schema.PrefCode, schema.CityCodes, schema.Category, schema.Label);
            }

            public static RegionRequest Create(string pref, IEnumerable<string> cities, string category, string label, IAnalizerQuery query)
            {
                int prefCode = -1;
                List<int> cityCodes = new List<int>();
                var tableLines = query.TableLines.Reader.ReadAll();
                foreach (var tableLine in tableLines)
                {
                    if (tableLine.Category.Equals(RegionCategory.Prefecture.Value) && tableLine.Content.Equals(pref))
                    {
                        prefCode = tableLine.Id;
                    }
                    if (tableLine.Category.Equals(RegionCategory.City.Value) && tableLine.Content.Equals(cities.ToArray()[0]))
                    {
                        cityCodes.Add(tableLine.Id);
                    }
                    if (prefCode >= 0 && cityCodes.Any())
                    {
                        break;
                    }
                }
                return new RegionRequest(prefCode, cityCodes, category, label);
            }
        }


        #endregion constructor

        #region method

        public RegionRequestSchema CreateSchema()
        {
            return new RegionRequestSchema()
            {
                PrefCode = PrefCode,
                CityCodes = CityCodes.ToList(),
                Category = Category.Value,
                Label = Label.Value,
            };
        }

        #endregion method
    }
}
