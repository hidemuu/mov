﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Repositories.Contexts
{
    public class RepositoryContextCore : DbContext
    {
        #region constructor

        public RepositoryContextCore()
        { }

        public RepositoryContextCore(DbContextOptions<RepositoryContextCore> options) : base(options)
        {
        }

        #endregion constructor

        #region event

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #endregion event
    }
}