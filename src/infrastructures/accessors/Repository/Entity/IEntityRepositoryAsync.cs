﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public interface IEntityRepositoryAsync<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(string param);

        Task PostAsync(TEntity item);
    }
}