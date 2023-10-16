using Mov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Stores.Services.Queries.Readers
{
	public class DbRepositoryReader<TDbRepository, TEntity, TIdentifier> : IRead<TEntity, TIdentifier>
		where TDbRepository : IDbRepository<TEntity, TIdentifier>
		where TEntity : IDbSchema<TIdentifier>
	{
		#region field

		private readonly TDbRepository _repository;

		#endregion field

		#region constructor

		public DbRepositoryReader(TDbRepository repository) 
		{
			_repository= repository;
		}

		#endregion constructor

		#region method

		public TEntity Read(TIdentifier id)
		{
			return Task.WhenAll(_repository.GetAsync(id)).Result[0];
		}

		public IEnumerable<TEntity> ReadAll()
		{
			var result = Task.WhenAll(_repository.GetsAsync()).Result[0];
			foreach (var item in result)
			{
				yield return item;
			}
		}

		#endregion method
	}
}
