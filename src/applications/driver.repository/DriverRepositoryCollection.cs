using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Repository
{
    public class DriverRepositoryCollection : DbObjectRepositoryCollectionBase, IDriverRepositoryCollection
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DriverRepositoryCollection(string resourceDir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir, extension)
        {
            Variables = new DbObjectRepository<Variable, VariableCollection>(GetRepositoryPath("variable"), encoding);
            Errors = new DbObjectRepository<Error, ErrorCollection > (GetRepositoryPath("error"), encoding);
            Macros = new DbObjectRepository<Macro, MacroCollection>(GetRepositoryPath("macro"), encoding);
            Schemas = new DbObjectRepository<Schema, SchemaCollection>(GetRepositoryPath("schema"), encoding);
            Connects = new DbObjectRepository<Connect, ConnectCollection>(GetRepositoryPath("connect"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public DbObjectRepository<Variable, VariableCollection> Variables { get; }

        public DbObjectRepository<Error, ErrorCollection> Errors { get; }

        public DbObjectRepository<Macro, MacroCollection> Macros { get; }

        public DbObjectRepository<Schema, SchemaCollection> Schemas { get; }

        public DbObjectRepository<Connect, ConnectCollection> Connects { get; }

        #endregion
    }
}
