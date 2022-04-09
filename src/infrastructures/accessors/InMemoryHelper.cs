using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public class InMemoryHelper : IFileHelper
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InMemoryHelper()
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
