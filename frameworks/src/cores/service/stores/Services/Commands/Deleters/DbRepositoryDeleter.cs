using Mov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Stores.Services.Commands.Deleters
{
	public class DbRepositoryDeleter<TDbRepository, TEntity, TIdentifier, TRequest> : IDelete<TEntity>
		where TDbRepository : IDbRepository<TEntity, TIdentifier, TRequest>
		where TEntity : IDbSchema<TIdentifier>
		where TRequest : IDbRequestSchema
	{
		#region field

		private readonly TDbRepository _repository;

		#endregion field

		#region constructor

		public DbRepositoryDeleter(TDbRepository repository) 
		{
			_repository = repository;
		}

		#endregion constructor

		#region method

		public void Delete(TEntity entity)
		{
			Task.WhenAll(_repository.DeleteAsync(entity));
		}

		public void Clear()
		{
			Task.WhenAll(_repository.DeletesAsync());
		}

		#endregion method
	}
}
