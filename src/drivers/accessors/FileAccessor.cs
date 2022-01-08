using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public abstract class FileAccessor<T>
    {
        private readonly IFileHelper fileHelper;
        public FileAccessor(IFileHelper fileHelper)
        {
            this.fileHelper = fileHelper;
        }
        public IEnumerable<T> Gets()
        {
            return fileHelper.Read<IEnumerable<T>>();
        }

        public async Task<IEnumerable<T>> GetsAsync()
        {
            return await Task.Run(Gets);
        }

        public T Get()
        {
            return fileHelper.Read<T>();
        }
        
        public async Task<T> GetAsync()
        {
            return await Task.Run(Get);
        }
        public async Task<IEnumerable<T>> GetTableAsync()
        {
            return (await Task.Run(() => fileHelper.Read<ITable<T>>())).Items;
        }
    }
}
