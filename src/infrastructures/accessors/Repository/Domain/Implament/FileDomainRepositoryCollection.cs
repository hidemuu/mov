using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Accessors.Repository.Implement
{
    public class FileDomainRepositoryCollection<TRepository, TInstance> : IDomainRepositoryCollection<TRepository>
    {
        #region プロパティ

        public IDictionary<string, TRepository> Repositories { get; }

        #endregion プロパティ

        #region コンストラクター

        public FileDomainRepositoryCollection(string baseDir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8)
        {
            Repositories = new Dictionary<string, TRepository>();
            var directories = GetDirectories(baseDir);
            CreateRepository(directories, baseDir, extension, encode);
        }

        #endregion コンストラクター

        #region メソッド

        public TRepository GetRepository(string dirName)
        {
            if (!Repositories.TryGetValue(dirName, out TRepository repository)) return default(TRepository);
            return repository;
        }

        #endregion メソッド

        #region 内部メソッド

        private void CreateRepository(IEnumerable<DirectoryInfo> directories, string baseDir, string extension, string encode)
        {

            Repositories.Add("", (TRepository)Activator.CreateInstance(typeof(TInstance), baseDir, extension, encode));
            foreach (var directory in directories)
            {
                Repositories.Add(directory.Name, (TRepository)Activator.CreateInstance(typeof(TInstance), directory.FullName, extension, encode));
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
