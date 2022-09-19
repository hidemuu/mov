using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Repository
{
    public class FileDriverRepository : FileDomainRepositoryBase, IDriverRepository
    {
        public override string RelativePath => "driver";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public FileDriverRepository(string endpoint, string fileDir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8) 
            : base(endpoint, fileDir, extension, encoding)
        {
            Commands = new FileDbObjectRepository<Command, CommandCollection>(GetPath("command"), encoding);
            Queries = new FileDbObjectRepository<Query, QueryCollection>(GetPath("query"), encoding);
            Errors = new FileDbObjectRepository<Error, ErrorCollection> (GetPath("error"), encoding);
            Macros = new FileDbObjectRepository<Macro, MacroCollection>(GetPath("macro"), encoding);
            Variables = new FileDbObjectRepository<Variable, VariableCollection>(GetPath("variable"), encoding);
            Schemas = new FileDbObjectRepository<Schema, SchemaCollection>(GetPath("schema"), encoding);
            Connects = new FileDbObjectRepository<Connect, ConnectCollection>(GetPath("connect"), encoding);
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
