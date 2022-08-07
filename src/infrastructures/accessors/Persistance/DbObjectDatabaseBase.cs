using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mov.Accessors
{
    public abstract class DbObjectDatabaseBase<T, TInstance> where TInstance : T
    {
        #region プロパティ

        public IDictionary<string, T> Repositories { get; }

        #endregion プロパティ

        #region コンストラクター

        public DbObjectDatabaseBase(string baseDir, string extension, string encode)
        {
            Repositories = new Dictionary<string, T>();
            var directories = GetDirectories(baseDir);
            CreateRepository(directories, baseDir, extension, encode);
        }

        #endregion コンストラクター

        #region メソッド

        public T GetRepository(string dirName)
        {
            if (!Repositories.TryGetValue(dirName, out T repository)) return default(T);
            return repository;
        }

        #endregion メソッド

        #region 内部メソッド

        private void CreateRepository(IEnumerable<DirectoryInfo> directories, string baseDir, string extension, string encode)
        {
            if (directories == null || !directories.Any())
            {
                Repositories.Add("", (T)Activator.CreateInstance(typeof(TInstance), baseDir, extension, encode));
                return;
            }
            foreach (var directory in directories)
            {
                Repositories.Add(directory.Name, (T)Activator.CreateInstance(typeof(TInstance), directory.FullName, extension, encode));
            }
        }

        private IEnumerable<DirectoryInfo> GetDirectories(string baseDir)
        {
            var directoryInfo = new DirectoryInfo(baseDir);
            if(!directoryInfo.Exists) return null;
            return directoryInfo.GetDirectories();
        }

        #endregion 内部メソッド

    }
}