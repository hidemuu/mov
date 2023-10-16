using Mov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Stores.Services.Commands.Deleters
{
	public class DbRepositoryDeleter<TDbRepository, TEntity, TIdentifier> : IDelete<TEntity>
		where TDbRepository : IDbRepository<TEntity, TIdentifier>
		where TEntity : IDbSchema<TIdentifier>
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

		#endregion method
	}
}
