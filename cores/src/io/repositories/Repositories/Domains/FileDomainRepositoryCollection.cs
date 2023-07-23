using Mov.Core.Accessors;
using Mov.Core.Models.Texts;
using Mov.Core.Templates.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mov.Core.Repositories.Repositories.Domains
{
    public class FileDomainRepositoryCollection<TRepository, TInstance>
        : IDomainRepositoryCollection<TRepository>
        where TRepository : IDomainRepository
        where TInstance : FileDomainRepositoryBase
    {
        #region プロパティ

        public IDictionary<string, TRepository> Repositories { get; }

        public virtual string DefaultRepositoryName => "dashboard";

        #endregion プロパティ

        #region コンストラクター

        public FileDomainRepositoryCollection(string endpoint, FileType fileType, string encode = AccessConstants.ENCODE_NAME_UTF8)
        {
            Repositories = new Dictionary<string, TRepository>();
            CreateRepository(endpoint, fileType, encode);
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<string> GetRepositoryNames()
        {
            return Repositories.Keys;
        }

        public TRepository GetRepository(string dirName)
        {
            if (string.IsNullOrEmpty(dirName)) return Repositories[""];
            if (!Repositories.TryGetValue(dirName, out TRepository repository)) return default;
            return repository;
        }

        public TRepository GetDefaultRepository() => GetRepository(DefaultRepositoryName);

        #endregion メソッド

        #region 内部メソッド

        private void CreateRepository(string endpoint, FileType fileType, string encode)
        {
            var defaultRepository = (TRepository)Activator.CreateInstance(typeof(TInstance), endpoint, "", fileType, encode);
            var directories = GetDirectories(defaultRepository.RelativePath);
            Repositories.Add("", defaultRepository);
            foreach (var directory in directories)
            {
                Repositories.Add(directory.Name, (TRepository)Activator.CreateInstance(typeof(TInstance), endpoint, directory.Name, fileType, encode));
            }
        }

        private IEnumerable<DirectoryInfo> GetDirectories(string baseDir)
        {
            var directoryInfo = new DirectoryInfo(baseDir);
            if (!directoryInfo.Exists) return null;
            return directoryInfo.GetDirectories();
        }

        #endregion 内部メソッド
    }
}
