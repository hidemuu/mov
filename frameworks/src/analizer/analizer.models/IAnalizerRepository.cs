using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using System;

namespace Mov.Analizer.Models
{
    public interface IAnalizerRepository
    {
		IDbRepository<TimeLineSchema, int, DbRequestSchemaString> TimeLines { get; }

		IDbRepository<TimeTrendSchema, int, DbRequestSchemaString> TimeTrends { get; }

		IDbRepository<TableLineSchema, int, DbRequestSchemaString> TableLines { get; }
	}
}