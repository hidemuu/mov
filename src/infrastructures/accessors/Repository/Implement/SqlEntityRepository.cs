using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public class SqlEntityRepository<TModel, TKey> : IEntityRepository<TModel> where TModel : EntityObject<TKey>
    {
        private readonly DbContext db;
        private readonly DbSet<TModel> ts;

        public SqlEntityRepository(DbContext db, DbSet<TModel> ts)
        {
            this.db = db;
            this.ts = ts;

        }

        public async Task<IEnumerable<TModel>> GetAsync()
        {
            return await ts
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TModel> GetAsync(string param)
        {
            return await ts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.ToString() == param);
        }

        public async Task PostAsync(TModel item)
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

        public async Task PostAsync(IEnumerable<TModel> items)
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
