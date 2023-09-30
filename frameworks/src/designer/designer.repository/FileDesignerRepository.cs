using Mov.Core;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using System;
using System.IO;

namespace Mov.Designer.Repository
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
            Shells = FileDbRepository<ShellSchema, Guid>.Factory.Create(Path.Combine(endpoint, "shell"), fileType, encoding);
            Nodes = FileDbRepository<NodeSchema, Guid>.Factory.Create(Path.Combine(endpoint, "node"), fileType, encoding);
            Contents = FileDbRepository<ContentSchema, Guid>.Factory.Create(Path.Combine(endpoint, "content"), fileType, encoding);
            Themes = FileDbRepository<ThemeSchema, Guid>.Factory.Create(Path.Combine(endpoint, "theme"), fileType, encoding);
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