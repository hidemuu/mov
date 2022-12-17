using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mov.Controllers
{
    public class SaveAuditing<T> : ISave<T>
    {

        private readonly ISave<T> decorated;

        private readonly ISave<AuditInfo> auditSave;

        public SaveAuditing(ISave<T> decorated, ISave<AuditInfo> auditSave)
        {
            this.decorated = decorated;
            this.auditSave = auditSave;
        }

        public void Save(T entity)
        {
            decorated.Save(entity);
            var auditInfo = new AuditInfo
            {
                UserName = Thread.CurrentPrincipal.Identity.Name,
                TimeStamp = DateTime.Now,
            };
            auditSave.Save(auditInfo);
        }

    }

}
