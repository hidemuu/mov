using Mov.Core.Accessors.Models;
using Mov.Core.Models;
using Mov.Core.Repositories.Schemas.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Services
{
	public class InMemoryDbRepository<TEntity, TIdentifier> : IDbRepository<TEntity, TIdentifier, DbRequestSchemaString>
		where TEntity : IDbSchema<TIdentifier>
	{
		#region field

		private readonly ICollection<TEntity> _cached;

		#endregion field

		#region property

		public string Name { get; }

		public string Endpoint { get; } = string.Empty;

		#endregion property

		#region constructor

		public InMemoryDbRepository(string name)
		{
			_cached = new List<TEntity>();
			this.Name = name;
		}

		#endregion constructor

		#region method

		public async Task<TEntity> GetAsync(TIdentifier identifier)
		{
			return await Task.Run(() => _cached.FirstOrDefault(x => x.Id.Equals(identifier)));
		}

		public async Task<TEntity> GetRequestAsync(DbRequestSchemaString request)
		{
			return await Task.Run(() => _cached.FirstOrDefault(x => x.Id.Equals(request.Uri)));
		}

		public async Task<IEnumerable<TEntity>> GetsAsync()
		{
			return await Task.Run(() => _cached);
		}

		public async Task<ResponseStatus> PostAsync(TEntity entity)
		{
			await Task.Run(() => _cached.Add(entity));
			return ResponseStatus.Success;
		}

		public async Task<ResponseStatus> PostsAsync(IEnumerable<TEntity> entities)
		{
			await Task.Run(() => 
			{
				foreach (var entity in entities)
				{
					_cached.Add(entity);
				}
			});
			return ResponseStatus.Success;
		}

		public async Task<ResponseStatus> PutAsync(TEntity entity)
		{
			await Task.Run(() => _cached.Add(entity));
			return ResponseStatus.Success;
		}

		public async Task<ResponseStatus> DeleteAsync(TEntity entity)
		{
			await Task.Run(() => _cached.Remove(entity));
			return ResponseStatus.Success;
		}

		public async Task<ResponseStatus> DeletesAsync()
		{
			await Task.Run(() => _cached.Clear());
			return ResponseStatus.Success;
		}


		#endregion method
	}
}
