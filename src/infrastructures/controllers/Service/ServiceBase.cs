using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public abstract class ServiceBase<T>
    {
        private readonly IFactory<T> factory;
        private T created;

        public ServiceBase(IFactory<T> factory)
        {
            this.factory = factory;
        }

        public virtual void Create(string createType)
        {
            this.created = this.factory.Create(createType);
        }
    }
}
