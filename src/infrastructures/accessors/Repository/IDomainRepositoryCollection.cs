using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Repository
{
    public interface IDomainRepositoryCollection<TRepository>
    {
        IDictionary<string, TRepository> Repositories { get; }

        TRepository GetRepository(string dirName);
    }
}
