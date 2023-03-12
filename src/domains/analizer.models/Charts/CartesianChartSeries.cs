using Mov.Schemas.Styles;
using Mov.Schemas.Units.Coordinates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Charts
{
    public class CartesianChartSeries : IEnumerable<Point2D>
    {
        public IEnumerator<Point2D> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
