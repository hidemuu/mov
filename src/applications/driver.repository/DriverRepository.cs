using Mov.Accessors;
using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Repository
{
    public class DriverRepository : DbObjectRepositoryBase, IDriverRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DriverRepository(string dir, string extension, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            Errors = new DbObjectRepository<Error, ErrorCollection > (dir, GetRelativePath("error"), encoding);
            Macros = new DbObjectRepository<Macro, MacroCollection>(dir, GetRelativePath("macro"), encoding);
            Variables = new DbObjectRepository<Variable, VariableCollection>(dir, GetRelativePath("variable"), encoding);
            Schemas = new DbObjectRepository<Schema, SchemaCollection>(dir, GetRelativePath("schema"), encoding);
            Connects = new DbObjectRepository<Connect, ConnectCollection>(dir, GetRelativePath("connect"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IRepository<Error, ErrorCollection> Errors { get; }

        public IRepository<Macro, MacroCollection> Macros { get; }

        public IRepository<Variable, VariableCollection> Variables { get; }

        public IRepository<Schema, SchemaCollection> Schemas { get; }

        public IRepository<Connect, ConnectCollection> Connects { get; }

        #endregion
    }
}
