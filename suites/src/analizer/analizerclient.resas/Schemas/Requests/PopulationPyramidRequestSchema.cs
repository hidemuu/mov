using Mov.Core.Repositories.Schemas;
using Mov.Core.Repositories.Schemas.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Requests
{
    public sealed class PopulationPyramidRequestSchema : DbRequestSchemaBase
    {
        #region constructor

        public PopulationPyramidRequestSchema(int cityCode, int prefCode, int yearRight, int yearLeft) 
            : base(new Dictionary<string, string>()
			{
				{ "cityCode", cityCode.ToString() },
				{ "yearRight", yearRight.ToString() },
				{ "prefCode", prefCode.ToString() },
				{ "yearLeft", yearLeft.ToString() },
			})
        {
        }

        #endregion constructor
    }
}
