﻿using Mov.Core;
using Mov.Core.Repositories.Repositories.DbObjects;
using Mov.Core.Repositories.Repositories.Domains;
using Mov.Core.Templates.Repositories;
using Mov.Driver.Models;
using Mov.Driver.Models.Entities.Schemas;

namespace Mov.Suite.Respsitory
{
    public class FileDriverRepository : FileDomainRepositoryBase, IDriverRepository
    {
        public override string DomainPath => "driver";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public FileDriverRepository(string endpoint, string fileDir, string extension, string encoding = CoreConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            Commands = new FileDbObjectRepository<Command, CommandCollection>(GetPath("command"), encoding);
            Queries = new FileDbObjectRepository<Query, QueryCollection>(GetPath("query"), encoding);
            Macros = new FileDbObjectRepository<Macro, MacroCollection>(GetPath("macro"), encoding);
            Variables = new FileDbObjectRepository<Variable, VariableCollection>(GetPath("variable"), encoding);
            Connects = new FileDbObjectRepository<Connect, ConnectCollection>(GetPath("connect"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbObjectRepository<Command, CommandCollection> Commands { get; }

        public IDbObjectRepository<Query, QueryCollection> Queries { get; }

        public IDbObjectRepository<Macro, MacroCollection> Macros { get; }

        public IDbObjectRepository<Variable, VariableCollection> Variables { get; }

        public IDbObjectRepository<Connect, ConnectCollection> Connects { get; }

        #endregion プロパティ
    }
}