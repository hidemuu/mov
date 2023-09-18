using Microsoft.EntityFrameworkCore;
using Mov.Core.Repositories.Schemas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Services
{
    public class SqlDbRepository<TEntity, TIdentifier> : IDbRepository<TEntity, TIdentifier>
        where TEntity : DbSchemaBase<TIdentifier>
    {
        private readonly DbContext db;
        private readonly DbSet<TEntity> ts;

        #region property

        public string Endpoint => "";

        #endregion property

        public SqlDbRepository(DbContext db, DbSet<TEntity> ts)
        {
            this.db = db;
            this.ts = ts;

        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await ts
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetAsync(TIdentifier identifier)
        {
            return await ts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(identifier));
        }

        public async Task PostAsync(TEntity entity)
        {
            var current = await ts.FirstOrDefaultAsync(_m => _m.Id.Equals(entity.Id));
            if (null == current)
            {
                ts.Add(entity);
            }
            else
            {
                var value = entity;
                value.Id = current.Id;
                db.Entry(current).CurrentValues.SetValues(value);
            }

            await db.SaveChangesAsync();
        }

        public async Task PostAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(async () =>
            {
                foreach (var entity in entities)
                {
                    await PostAsync(entity);
                }
            });

        }

        public Task PutAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var identtifier = entity.Id;
            await DeleteAsync(identtifier);
        }

        public async Task DeleteAsync(TIdentifier identifier)
        {
            var query = ts.Where(x => x.Id.Equals(identifier));
            foreach (var q in query)
            {
                var item = await ts.FirstOrDefaultAsync(_m => _m.Id.Equals(q.Id));
                if (null != item)
                {
                    ts.Remove(item);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
