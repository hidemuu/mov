﻿using Mov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Stores.Services.Commands.Savers
{
	public class DbRepositorySaver<TDbRepository, TEntity, TIdentifier> : ISave<TEntity>
		where TDbRepository : IDbRepository<TEntity, TIdentifier>
		where TEntity : IDbSchema<TIdentifier>
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

		#endregion method
	}
}