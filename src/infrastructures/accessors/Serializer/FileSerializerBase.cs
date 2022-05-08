using System;
using System.IO;
using System.Text;

namespace Mov.Accessors
{
    public abstract class FileSerializerBase : ISerializer
    {
        #region フィールド

        protected abstract string Extension { get; }
        protected string Path { get; }
        protected Encoding Encoding { get; }

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public FileSerializerBase(string path, string encoding)
        {
            this.Path = path;
            if (string.IsNullOrEmpty(System.IO.Path.GetExtension(path))) this.Path += Extension;
            this.Encoding = Encoding.GetEncoding(encoding);

            using (var watcher = new FileSystemWatcher(path))
            {
                watcher.NotifyFilter = NotifyFilters.Attributes
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.FileName
                                     | NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.Security
                                     | NotifyFilters.Size;

                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;
                watcher.Error += OnError;

                watcher.Filter = "*" + Extension;
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
            }
        }

        #region メソッド

        public abstract T Read<T>();

        public abstract void Write<T>(T obj);

        #endregion メソッド

        #region 内部メソッド

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"Deleted: {e.FullPath}");

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }

        #endregion 内部メソッド
    }
}