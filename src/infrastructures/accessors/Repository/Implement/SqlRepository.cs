using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public class SqlRepository<T> : IRepository<T> where T: EntityObject
    {
        private readonly DbContext db;
        private readonly DbSet<T> ts;

        public SqlRepository(DbContext db, DbSet<T> ts)
        {
            this.db = db;
            this.ts = ts;

        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await ts
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetAsync(string param)
        {
            return await ts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Code == param);
        }

        public async Task PostAsync(T item)
        {
            var current = await ts.FirstOrDefaultAsync(_m => _m.Id == item.Id);
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

        public async Task PostAsync(IEnumerable<T> items)
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
            var query = ts.Where(x => x.Code == name);
            foreach (var q in query)
            {
                var item = await ts.FirstOrDefaultAsync(_m => _m.Id == q.Id);
                if (null != item)
                {
                    ts.Remove(item);
                    await db.SaveChangesAsync();
                }
            }

        }

    }
}
