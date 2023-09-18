using Mov.Core.Stores.Models;
using System;
using System.Threading;

namespace Mov.Core.Stores.Services.Commands.Savers.Decorators
{
    public class SaveAuditing<TEntity> : ISave<TEntity>
    {

        private readonly ISave<TEntity> _decorated;

        private readonly ISave<AuditInfo> _auditSave;

        public SaveAuditing(ISave<TEntity> decorated, ISave<AuditInfo> auditSave)
        {
            this._decorated = decorated;
            this._auditSave = auditSave;
        }

        public void Save(TEntity entity)
        {
            _decorated.Save(entity);
            var auditInfo = new AuditInfo
            {
                UserName = Thread.CurrentPrincipal.Identity.Name,
                TimeStamp = DateTime.Now,
            };
            _auditSave.Save(auditInfo);
        }

    }

}
