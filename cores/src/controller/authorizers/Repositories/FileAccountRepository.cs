﻿using Mov.Core.Authorizers.Models.Entities;
using System;

namespace Mov.Core.Authorizers.Repositories
{
    public class FileAccountRepository : IAccountRepository
    {
        #region constructor

        public FileAccountRepository()
        {
        }

        #endregion constructor

        #region method

        public Account GetByName(string name)
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
