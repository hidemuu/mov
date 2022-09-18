using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Repository
{
    public class DriverRepository : FileDomainRepositoryBase, IDriverRepository
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public DriverRepository(string dir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encoding)
        {
            Commands = new FileDbObjectRepository<Command, CommandCollection>(dir, GetRelativePath("command"), encoding);
            Queries = new FileDbObjectRepository<Query, QueryCollection>(dir, GetRelativePath("query"), encoding);
            Errors = new FileDbObjectRepository<Error, ErrorCollection> (dir, GetRelativePath("error"), encoding);
            Macros = new FileDbObjectRepository<Macro, MacroCollection>(dir, GetRelativePath("macro"), encoding);
            Variables = new FileDbObjectRepository<Variable, VariableCollection>(dir, GetRelativePath("variable"), encoding);
            Schemas = new FileDbObjectRepository<Schema, SchemaCollection>(dir, GetRelativePath("schema"), encoding);
            Connects = new FileDbObjectRepository<Connect, ConnectCollection>(dir, GetRelativePath("connect"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Command, CommandCollection> Commands { get; }

        public IDbObjectRepository<Query, QueryCollection> Queries { get; }

        public IDbObjectRepository<Error, ErrorCollection> Errors { get; }

        public IDbObjectRepository<Macro, MacroCollection> Macros { get; }

        public IDbObjectRepository<Variable, VariableCollection> Variables { get; }

        public IDbObjectRepository<Schema, SchemaCollection> Schemas { get; }

        public IDbObjectRepository<Connect, ConnectCollection> Connects { get; }

        #endregion
    }
}
