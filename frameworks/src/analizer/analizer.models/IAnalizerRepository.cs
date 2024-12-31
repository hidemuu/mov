using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using System;

namespace Mov.Analizer.Models
{
    public interface IAnalizerRepository
    {
		IDbRepository<TableLineSchema, int, DbRequestSchemaString> TableLines { get; }

		IDbRepository<TimeLineSchema, string, DbRequestSchemaString> TimeLines { get; }

		IDbRepository<TrendLineSchema, string, DbRequestSchemaString> TrendLines { get; }

		IDbRepository<StatisticLineSchema, string, DbRequestSchemaString> StatisticLines { get; }

		IDbRepository<HistgramLineSchema, string, DbRequestSchemaString> HistgramLines { get; }

	}
}