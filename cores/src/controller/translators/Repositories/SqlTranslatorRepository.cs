using Microsoft.EntityFrameworkCore;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Core.Translators.Contexts;
using Mov.Core.Translators.Models.Schemas;

namespace Mov.Core.Translators.Repositories
{
    public class SqlTranslatorRepository : ITranslatorRepository
    {
        #region field

        private readonly DbContextOptions<TranslatorDbContext> _dbOptions;
        private readonly TranslatorDbContext _db;

        #endregion field

        #region property

        public IDbRepository<TranslateSchema, int> Translates => new SqlDbRepository<TranslateSchema, int>(_db, _db.Translates);

        #endregion proeprty

        #region constructor

        public SqlTranslatorRepository(DbContextOptionsBuilder<TranslatorDbContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new TranslatorDbContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
            _db = new TranslatorDbContext(_dbOptions);
        }

        #endregion constructor
    }
}
