using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public class InMemorySerializer : IFileSerializer
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InMemorySerializer()
        {

        }

        public T Read<T>()
        {
            throw new NotImplementedException();
        }

        public void Write<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
