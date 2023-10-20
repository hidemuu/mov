using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using System;

namespace Mov.Analizer.Models
{
    public interface IAnalizerRepository
    {
		IDbRepository<TimeLineSchema, Guid, DbRequestSchemaString> TimeLines { get; }

		IDbRepository<TimeTrendSchema, Guid, DbRequestSchemaString> TimeTrends { get; }

		IDbRepository<TableLineSchema, Guid, DbRequestSchemaString> TableLines { get; }
	}
}