using Mov.Accessors.Repository.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Accessors.Repository.Implement
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

        public FileDomainRepositoryCollection(string endpoint, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8)
        {
            Repositories = new Dictionary<string, TRepository>();
            CreateRepository(endpoint, extension, encode);
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
            if (!Repositories.TryGetValue(dirName, out TRepository repository)) return default(TRepository);
            return repository;
        }

        public TRepository GetDefaultRepository() => GetRepository(DefaultRepositoryName);

        #endregion メソッド

        #region 内部メソッド

        private void CreateRepository(string endpoint, string extension, string encode)
        {
            var defaultRepository = (TRepository)Activator.CreateInstance(typeof(TInstance), endpoint, "", extension, encode);
            var directories = GetDirectories(defaultRepository.GetRelativePath());
            Repositories.Add("", defaultRepository);
            foreach (var directory in directories)
            {
                Repositories.Add(directory.Name, (TRepository)Activator.CreateInstance(typeof(TInstance), endpoint, directory.Name, extension, encode));
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
