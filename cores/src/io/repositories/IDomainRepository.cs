﻿namespace Mov.Core.Repositories
{
    public interface IDomainRepository
    {
        /// <summary>
        /// ドメインの相対パス
        /// </summary>
        string DomainPath { get; }

        string RelativePath { get; }
    }
}