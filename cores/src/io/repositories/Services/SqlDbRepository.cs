using Microsoft.EntityFrameworkCore;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories.Schemas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Services
{
    public class SqlDbRepository<TEntity, TIdentifier> : IDbRepository<TEntity, TIdentifier>
        where TEntity : DbSchemaBase<TIdentifier>
    {
        #region field

        private readonly DbContext _db;
        private readonly DbSet<TEntity> _ts;

        #endregion field

        #region property

        public string Endpoint => "";

        #endregion property

        #region constructor

        public SqlDbRepository(DbContext db, DbSet<TEntity> ts)
        {
            this._db = db;
            this._ts = ts;

        }

        #endregion constructor

        #region method

        public async Task<IEnumerable<TEntity>> GetsAsync()
        {
            return await _ts
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetAsync(TIdentifier identifier)
        {
            return await _ts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(identifier));
        }

        public async Task<ResponseStatus> PostAsync(TEntity entity)
        {
            var current = await _ts.FirstOrDefaultAsync(_m => _m.Id.Equals(entity.Id));
            if (null == current)
            {
                _ts.Add(entity);
            }
            else
            {
                var value = entity;
                value.Id = current.Id;
                _db.Entry(current).CurrentValues.SetValues(value);
            }

            await _db.SaveChangesAsync();
            return ResponseStatus.Success;
        }

        public async Task<ResponseStatus> PostAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(async () =>
            {
                foreach (var entity in entities)
                {
                    await PostAsync(entity);
                }
            });
            return ResponseStatus.Success;
        }

        public Task<ResponseStatus> PutAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseStatus> DeleteAsync(TEntity entity)
        {
            var identtifier = entity.Id;
            await DeleteAsync(identtifier);
            return ResponseStatus.Success;
        }

        public async Task DeleteAsync(TIdentifier identifier)
        {
            var query = _ts.Where(x => x.Id.Equals(identifier));
            foreach (var q in query)
            {
                var item = await _ts.FirstOrDefaultAsync(_m => _m.Id.Equals(q.Id));
                if (null != item)
                {
                    _ts.Remove(item);
                    await _db.SaveChangesAsync();
                }
            }
        }

        #endregion method
    }
}
