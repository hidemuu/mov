using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services
{
    public interface IDomainRepository
    {
        /// <summary>
        /// ドメインの相対パス
        /// </summary>
        string DomainPath { get; }

        string GetRelativePath();
    }
}
