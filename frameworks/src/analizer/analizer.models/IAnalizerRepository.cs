using Mov.Analizer.Models.Schemas;
using Mov.Core.Repositories;
using System;

namespace Mov.Analizer.Models
{
    public interface IAnalizerRepository
    {
		IDbRepository<TimeLineSchema, Guid> TimeLines { get; }

		IDbRepository<TimeTrendSchema, Guid> TimeTrends { get; }

		IDbRepository<TableLineSchema, Guid> TableLines { get; }
	}
}