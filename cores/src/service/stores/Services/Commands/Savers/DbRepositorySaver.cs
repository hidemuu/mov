using Mov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Stores.Services.Commands.Savers
{
	public class DbRepositorySaver<TDbRepository, TEntity, TIdentifier, TRequest> : ISave<TEntity>
		where TDbRepository : IDbRepository<TEntity, TIdentifier, TRequest>
		where TEntity : IDbSchema<TIdentifier>
		where TRequest : IDbRequestSchema
	{
		#region field

		private readonly TDbRepository _repository;

		#endregion field

		#region constructor

		public DbRepositorySaver(TDbRepository repository) 
		{
			_repository = repository;
		}

		#endregion constructor

		#region method

		public void Save(TEntity entity)
		{
			Task.WhenAll(_repository.PostAsync(entity));
		}

		public void Save(IEnumerable<TEntity> entities)
		{
			Task.WhenAll(_repository.PostsAsync(entities));
		}

		#endregion method
	}
}
