using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerRepositoryCollection
    {
        #region プロパティ

        IDictionary<string, IDesignerRepository> Repositories { get; }

        string DefaultRepositoryName { get; }

        #endregion プロパティ

        #region メソッド

        IEnumerable<string> GetRepositoryNames();

        IDesignerRepository GetRepository(string repositoryName);

        #endregion メソッド

    }
}
