using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Models.EntityObjects
{
    public interface IFileRepository<TBody>
    {
        /// <summary>
        /// インポート
        /// </summary>
        TBody Read();

        /// <summary>
        /// エクスポート
        /// </summary>
        void Write();
    }
}
