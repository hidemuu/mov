using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas;
using Mov.Core.Repositories.Schemas.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.Suite.AnalizerClient.Resas.Schemas.Requests
{
    public sealed class PopulationPerYearRequestSchema : DbRequestSchemaBase
    {
        
		#region constructor

		public PopulationPerYearRequestSchema(int cityCode, int prefCode) 
            : base(new Dictionary<string, string>()
			{
				{ "cityCode", cityCode.ToString() },
				{ "prefCode", prefCode.ToString() },
			})
        {
            
        }

		#endregion constructor

	}
}
