using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public class GenericController<T>
    {

        private readonly IRead<T> reader;
        private readonly ISave<T> saver;
        private readonly IDelete<T> deleter;

        public GenericController(IRead<T> reader, ISave<T> saver, IDelete<T> deleter)
        {
            this.reader = reader;
            this.saver = saver;
            this.deleter = deleter;
        }

        public T Get(Guid identity)
        {
            return reader.Read(identity);
        }

        public void Post(T entity)
        {
            saver.Save(entity);
        }

        public void Put(T entity)
        {
            saver.Save(entity);
        }

        public void Delete(T entity)
        {
            deleter.Delete(entity);
        }

    }
}
