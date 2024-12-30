using System.Collections;
using System.Collections.Generic;

namespace Mov.Core.Stores
{
    public interface IDelete<TEntity>
    {
        void Delete(TEntity entity);

		void Clear();

	}
}
