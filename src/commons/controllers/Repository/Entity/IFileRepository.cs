﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Repository
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