using Mov.Accessors;
using Mov.BaseModel;
using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Repository
{
    public class DriverRepository : DomainRepositoryBase, IDriverRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DriverRepository(string dir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            Commands = new DbObjectRepository<Command, CommandCollection>(dir, GetRelativePath("command"), encoding);
            Queries = new DbObjectRepository<Query, QueryCollection>(dir, GetRelativePath("query"), encoding);
            Errors = new DbObjectRepository<Error, ErrorCollection > (dir, GetRelativePath("error"), encoding);
            Macros = new DbObjectRepository<Macro, MacroCollection>(dir, GetRelativePath("macro"), encoding);
            Variables = new DbObjectRepository<Variable, VariableCollection>(dir, GetRelativePath("variable"), encoding);
            Schemas = new DbObjectRepository<Schema, SchemaCollection>(dir, GetRelativePath("schema"), encoding);
            Connects = new DbObjectRepository<Connect, ConnectCollection>(dir, GetRelativePath("connect"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Command> Commands { get; }

        public IDbObjectRepository<Query> Queries { get; }

        public IDbObjectRepository<Error> Errors { get; }

        public IDbObjectRepository<Macro> Macros { get; }

        public IDbObjectRepository<Variable> Variables { get; }

        public IDbObjectRepository<Schema> Schemas { get; }

        public IDbObjectRepository<Connect> Connects { get; }

        #endregion
    }
}
