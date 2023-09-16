using Mov.Core;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using System;

namespace Mov.Designer.Repository.File
{
    /// <summary>
    /// デザイナーのリポジトリ
    /// </summary>
    public class FileDesignerRepository : IDesignerRepository
    {
        public string Endpoint => "designer";

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="encoding"></param>
        public FileDesignerRepository(string endpoint, FileType fileType, EncodingValue encoding)
        {
            Shells = new FileDbRepository<ShellSchema, Guid>(GetPath("shell"), encoding);
            Nodes = new FileDbRepository<NodeSchema, Guid>(GetPath("node"), encoding);
            Contents = new FileDbRepository<ContentSchema, Guid>(GetPath("content"), encoding);
            Themes = new FileDbRepository<ThemeSchema, Guid>(GetPath("theme"), encoding);
        }

        #endregion コンストラクター

        #region プロパティ

        public IDbRepository<ShellSchema, Guid> Shells { get; }

        public IDbRepository<NodeSchema, Guid> Nodes { get; }

        public IDbRepository<ContentSchema, Guid> Contents { get; }

        public IDbRepository<ThemeSchema, Guid> Themes { get; }

        #endregion プロパティ
    }
}