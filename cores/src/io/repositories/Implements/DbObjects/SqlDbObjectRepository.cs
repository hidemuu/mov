using Microsoft.EntityFrameworkCore;
using Mov.Core.Repositories.Models;
using Mov.Core.Repositories.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Implements.DbObjects
{
    public class SqlDbObjectRepository<TEntity, TKey> : IDbObjectRepository<TEntity, TKey> 
        where TEntity : DbObjectBase<TKey>
    {
        private readonly DbContext db;
        private readonly DbSet<TEntity> ts;

        public SqlDbObjectRepository(DbContext db, DbSet<TEntity> ts)
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

        public async Task<TEntity> GetAsync(TKey key)
        {
            return await ts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(key));
        }

        public async Task PostAsync(TEntity item)
        {
            var current = await ts.FirstOrDefaultAsync(_m => _m.Id.Equals(item.Id));
            if (null == current)
            {
                ts.Add(item);
            }
            else
            {
                var value = item;
                value.Id = current.Id;
                db.Entry(current).CurrentValues.SetValues(value);
            }

            await db.SaveChangesAsync();
        }

        public async Task PostAsync(IEnumerable<TEntity> items)
        {
            await Task.Run(async () =>
            {
                foreach (var item in items)
                {
                    await PostAsync(item);
                }
            });

        }

        public async Task DeleteAsync(string name)
        {
            var query = ts.Where(x => x.Id.ToString() == name);
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
